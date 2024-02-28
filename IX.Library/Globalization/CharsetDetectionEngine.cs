using IX.Library.Globalization.CharsetDetection.Probers;
using IX.Library.Collections;
using IX.Library.Globalization.CharsetDetectionContrib;

using System.Text;

namespace IX.Library.Globalization;

/// <summary>
/// A character set detection engine.
/// </summary>
/// <seealso cref="ICharsetDetectionEngine"/>
public class CharsetDetectionEngine : ICharsetDetectionEngine
{
    private static readonly Dictionary<string, string> FixedToSupportCodepageName =
        new()
        {
            // CP949 is superset of ks_c_5601-1987 (see https://github.com/CharsetDetector/UTF-unknown/pull/74#issuecomment-550362133)
            { CodepageName.CP949, CodepageName.KS_C_5601_1987 },
            { CodepageName.ISO_2022_CN, CodepageName.X_CP50227 },
        };

    private static readonly ObjectPool<CharsetProber[]> UnicodeProbersPool = new(
        () => new CharsetProber[]
        {
            new PureProber(),
            new EscCharsetProber(),
            new MBCSGroupProber(),
            new SBCSGroupProber(),
            new Latin1Prober()
        });

    /// <summary>
    /// Gets a compatible encoding (if any is applicable) based on its short name.
    /// </summary>
    /// <param name="encodingShortName">The short name of the encoding.</param>
    /// <returns>The encoding, if one is found.</returns>
    public static Encoding? GetCompatibleEncodingByShortName(string? encodingShortName)
    {
        if (encodingShortName == null)
        {
            return Encoding.ASCII;
        }

        var encodingName = FixedToSupportCodepageName.TryGetValue(
            encodingShortName,
            out var supportCodepageName)
            ? supportCodepageName
            : encodingShortName;
        try
        {
            return Encoding.GetEncoding(encodingName);
        }
        catch (NotSupportedException)
        {
#if STANDARD_GT_20
            try
            {
                return CodePagesEncodingProvider.Instance.GetEncoding(encodingName);
            }
            catch
            {
                return null;
            }
#else
            return null;
#endif
        }
        catch (ArgumentException)
        {
#if STANDARD_GT_20
            try
            {
                return CodePagesEncodingProvider.Instance.GetEncoding(encodingName);
            }
            catch
            {
                return null;
            }
#else
            return null;
#endif
        }
    }

    private static bool CheckByteOrderMark(
        byte[] input,
        long offset,
        long length,
        out Encoding? encoding)
    {
        switch (input[offset])
        {
            case 0xEF:
                // UTF8 with BOM
                if (length >= 3 && input[offset + 1] == 0xBB && input[offset + 2] == 0xBF)
                {
                    // BOM recognized as UTF8
                    encoding = Encoding.UTF8;

                    return true;
                }

                break;
            case 0xFE:
                // Either UCS4 (3412) encoding, or UTF16 big-endian
                if (length >= 2 && input[offset + 1] == 0xFF)
                {
                    if (length >= 4 && input[offset + 2] == 0x00 && input[offset + 3] == 0x00)
                    {
                        // UCS4 (3412) - UNSUPPORTED YET, probably never
                        // encoding = GetCompatibleEncodingByShortName(CodepageName.X_ISO_10646_UCS_4_3412);
                        encoding = null;

                        return true;
                    }

                    // UTF-16 big-endian
                    encoding = Encoding.BigEndianUnicode;

                    return true;
                }

                break;

            case 0xFF:
                // UTF16 little-endian or UTF32 little-endian
                if (length >= 2 && input[offset + 1] == 0xFE)
                {
                    if (length >= 4 && input[offset + 2] == 0x00 && input[offset + 3] == 0x00)
                    {
                        // UTF32 little-endian
                        encoding = Encoding.UTF32;

                        return true;
                    }

                    encoding = Encoding.Unicode;

                    return true;
                }

                break;

            case 0x00:
                // UTF32 big-endian or UCS4 (2143)
                if (length >= 4 && input[offset + 1] == 0x00)
                {
                    if (input[offset + 2] == 0xFE && input[offset + 3] == 0xFF)
                    {
                        // UTF32 big-endian
                        encoding = GetCompatibleEncodingByShortName(CodepageName.UTF32_BE);

                        return true;
                    }

                    if (input[offset + 2] == 0xFF && input[offset + 3] == 0xFE)
                    {
                        // UCS4 (2143) - UNSUPPORTED YET, probably never
                        // encoding = GetCompatibleEncodingByShortName(CodepageName.X_ISO_10646_UCS_4_2143);
                        encoding = null;

                        return true;
                    }
                }

                break;

            case 0x2B:
                // UTF7
                if (length >= 4 &&
                    input[offset + 1] == 0x2F &&
                    input[offset + 2] == 0x76 &&
                    (input[offset + 3] == 0x38 ||
                     input[offset + 3] == 0x39 ||
                     input[offset + 3] == 0x2B ||
                     input[offset + 3] == 0x2F))
                {
#pragma warning disable SYSLIB0001 // Type or member is obsolete - it is still currently in use and can be recognized
#pragma warning disable CS0618
                    encoding = Encoding.UTF7;
#pragma warning restore CS0618
#pragma warning restore SYSLIB0001 // Type or member is obsolete

                    return true;
                }

                break;

            case 0x84:
                // GB18030
                if (length >= 4 && input[offset + 1] == 0x31 && input[offset + 2] == 0x95 && input[offset + 3] == 0x33)
                {
                    encoding = GetCompatibleEncodingByShortName(CodepageName.GB18030);

                    return true;
                }

                break;
        }

        encoding = null;

        return false;
    }

    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(Stream stream) => Interpret(stream);

    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        Stream stream,
        int limit) =>
        Interpret(
            stream,
            limit);

    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        Stream stream,
        long limit) =>
        Interpret(
            stream,
            limit);

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        byte[] buffer,
        int offset,
        int count) =>
        Interpret(
            buffer,
            offset,
            count);

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        byte[] buffer,
        int count) =>
        Interpret(
            buffer,
            0,
            count);

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <returns>The interpretation result.</returns>
    public (Encoding? Encoding, float Confidence) Read(
        byte[] buffer) =>
        Interpret(
            buffer,
            0,
            buffer.LongLength);

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        CancellationToken cancellationToken = default) =>
        InterpretAsync(
            stream,
            cancellationToken: cancellationToken);

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        int limit,
        CancellationToken cancellationToken = default) =>
        InterpretAsync(
            stream,
            limit,
            cancellationToken);

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        long limit,
        CancellationToken cancellationToken = default) =>
        InterpretAsync(
            stream,
            limit,
            cancellationToken);

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        int offset,
        int count,
        CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        return Interpret(
            buffer,
            offset,
            count);
    }

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public async Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        long offset,
        long count,
        CancellationToken cancellationToken = default)
    {
        await Task.Yield();

        return Interpret(
            buffer,
            offset,
            count,
            cancellationToken);
    }

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        int count,
        CancellationToken cancellationToken = default) =>
        ReadAsync(
            buffer,
            0,
            count,
            cancellationToken);

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        long count,
        CancellationToken cancellationToken = default) =>
        ReadAsync(
            buffer,
            0L,
            count,
            cancellationToken);

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    public Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        CancellationToken cancellationToken = default) =>
        ReadAsync(
            buffer,
            0L,
            buffer.LongLength,
            cancellationToken);

    private (Encoding? Encoding, float Confidence) Interpret(byte[] input, long offset, long length, CancellationToken cancellationToken = default)
    {
        Requires.ValidArrayRange(in offset, in length, input);

        #region Check for byte-order mark

        var checkResult = CheckByteOrderMark(
            input,
            offset,
            length,
            out var possibleEncoding);

        if (checkResult)
        {
            return (possibleEncoding, possibleEncoding == null ? 0f : 1f);
        }

        #endregion

        cancellationToken.ThrowIfCancellationRequested();

        using var probers = UnicodeProbersPool.Get();

        try
        {
            byte[]? chunk = null;
            while (length != 0)
            {
                var toRead = length > 1000 ? 1000 : length;

                chunk ??= new byte[toRead];

                Array.Copy(
                    input,
                    offset,
                    chunk,
                    0,
                    toRead);

                if (CheckSmallBuffer(
                        probers.Value,
                        chunk,
                        (int)toRead,
                        out var immediateResult))
                {
                    return immediateResult;
                }

                cancellationToken.ThrowIfCancellationRequested();

                offset += toRead;
                length -= toRead;
            }

            Encoding? finalEncoding = null;
            var finalConfidence = 0f;

            var mostLikelyCharset = probers.Value.Where(p => p.GetState() != ProbingState.NotMe)
                .Select(
                    p => new
                    {
                        Confidence = p.GetConfidence(),
                        Detected = p.GetCharsetName()
                    })
                .Where(p => p.Confidence > 0.2f)
                .OrderByDescending(result => result.Confidence)
                .FirstOrDefault();

            if (mostLikelyCharset != null)
            {
                finalEncoding = GetCompatibleEncodingByShortName(mostLikelyCharset.Detected);
                finalConfidence = mostLikelyCharset.Confidence;
            }

            return finalEncoding == null
                ? (null, 0f)
                : (finalEncoding, finalConfidence >= 0.99f ? 1.0f : finalConfidence);
        }
        finally
        {
            foreach (var prober in probers.Value)
            {
                prober.Reset();
            }
        }
    }

    private (Encoding? Encoding, float Confidence) Interpret(Stream stream, long? length = null, CancellationToken cancellationToken = default)
    {
        if (length != null)
        {
            Requires.Positive(length.Value);
        }

        cancellationToken.ThrowIfCancellationRequested();

        var firstTime = true;

        using var probers = UnicodeProbersPool.Get();

        try
        {
            byte[]? chunk = null;
            while (length != 0)
            {
                var toRead = (length ?? 1001) > 1000 ? 1000 : (int)length!.Value;

                chunk ??= new byte[toRead];

                var readBytes = stream.Read(
                    chunk,
                    0,
                    toRead);

                if (readBytes == 0)
                {
                    break;
                }

                #region Check for byte-order mark

                if (firstTime)
                {
                    var checkResult = CheckByteOrderMark(
                        chunk,
                        0,
                        readBytes,
                        out var possibleEncoding);

                    if (checkResult)
                    {
                        return (possibleEncoding, possibleEncoding == null ? 0f : 1f);
                    }

                    firstTime = false;
                }

                #endregion

                if (CheckSmallBuffer(
                        probers.Value,
                        chunk,
                        readBytes,
                        out var immediateResult))
                {
                    return immediateResult;
                }

                cancellationToken.ThrowIfCancellationRequested();

                length -= readBytes;
            }

            Encoding? finalEncoding = null;
            var finalConfidence = 0f;

            var mostLikelyCharset = probers.Value.Where(p => p.GetState() != ProbingState.NotMe)
                .Select(
                    p => new
                    {
                        Confidence = p.GetConfidence(),
                        Detected = p.GetCharsetName()
                    })
                .Where(p => p.Confidence > 0.2f)
                .OrderByDescending(result => result.Confidence)
                .FirstOrDefault();

            if (mostLikelyCharset != null)
            {
                finalEncoding = GetCompatibleEncodingByShortName(mostLikelyCharset.Detected);
                finalConfidence = mostLikelyCharset.Confidence;
            }

            return finalEncoding == null
                ? (Encoding.ASCII, 0f)
                : (finalEncoding, finalConfidence >= 0.99f ? 1.0f : finalConfidence);
        }
        finally
        {
            foreach (var prober in probers.Value)
            {
                prober.Reset();
            }
        }
    }

    private async Task<(Encoding? Encoding, float Confidence)> InterpretAsync(Stream stream, long? length = null, CancellationToken cancellationToken = default)
    {
        if (length != null)
        {
            Requires.Positive(length.Value);
        }

        await Task.Yield();

        cancellationToken.ThrowIfCancellationRequested();

        var firstTime = true;

        using var probers = UnicodeProbersPool.Get();

        try
        {
            byte[]? chunk = null;
            while (length != 0)
            {
                var toRead = (length ?? 1001) > 1000 ? 1000 : (int)length!.Value;

                chunk ??= new byte[toRead];

                var readBytes = await stream.ReadAsync(
                    chunk,
                    0,
                    toRead,
                    cancellationToken);

                if (readBytes == 0)
                {
                    break;
                }

                #region Check for byte-order mark

                if (firstTime)
                {
                    var checkResult = CheckByteOrderMark(
                        chunk,
                        0,
                        readBytes,
                        out var possibleEncoding);

                    if (checkResult)
                    {
                        return (possibleEncoding, possibleEncoding == null ? 0f : 1f);
                    }

                    firstTime = false;
                }

                #endregion

                if (CheckSmallBuffer(
                        probers.Value,
                        chunk,
                        readBytes,
                        out var immediateResult))
                {
                    return immediateResult;
                }

                cancellationToken.ThrowIfCancellationRequested();

                length -= readBytes;
            }

            Encoding? finalEncoding = null;
            var finalConfidence = 0f;

            var mostLikelyCharset = probers.Value.Where(p => p.GetState() != ProbingState.NotMe)
                .Select(
                    p => new
                    {
                        Confidence = p.GetConfidence(),
                        Detected = p.GetCharsetName()
                    })
                .Where(p => p.Confidence > 0.2f)
                .OrderByDescending(result => result.Confidence)
                .FirstOrDefault();

            if (mostLikelyCharset != null)
            {
                finalEncoding = GetCompatibleEncodingByShortName(mostLikelyCharset.Detected);
                finalConfidence = mostLikelyCharset.Confidence;
            }

            return finalEncoding == null
                ? (null, 0f)
                : (finalEncoding, finalConfidence >= 0.99f ? 1.0f : finalConfidence);
        }
        finally
        {
            foreach (var prober in probers.Value)
            {
                prober.Reset();
            }
        }
    }

    private bool CheckSmallBuffer(
        CharsetProber[] probers,
        byte[] input,
        int length,
        out (Encoding? Encoding, float Confidence) definitiveAnswerResult)
    {
        foreach (var prober in probers.Where(p => p.GetState() != ProbingState.NotMe))
        {
            if (prober.HandleData(
                    input,
                    0,
                    length) !=
                ProbingState.FoundIt)
            {
                // Not a definitive answer yet, keep searching
                continue;
            }

            var encoding = GetCompatibleEncodingByShortName(prober.GetCharsetName());

            if (encoding == null)
            {
                // Encoding may not actually be supported, let's keep searching
                continue;
            }

            var confidence = prober.GetConfidence();

            if (confidence >= 0.99f)
            {
                confidence = 1.0f;
            }

            // We've got a definitive encoding, let's return
            definitiveAnswerResult = (encoding, confidence);

            return true;
        }

        definitiveAnswerResult = default;
        return false;
    }
}