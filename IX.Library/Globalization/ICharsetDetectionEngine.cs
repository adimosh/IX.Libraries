using System.Text;

namespace IX.Core.Globalization;

/// <summary>
/// A service contract for a character set detection engine.
/// </summary>
[PublicAPI]
public interface ICharsetDetectionEngine
{
    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <returns>The interpretation result.</returns>
    (Encoding? Encoding, float Confidence) Read(Stream stream);

    /// <summary>
    /// Read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <returns>The interpretation result.</returns>
    (Encoding? Encoding, float Confidence) Read(Stream stream, int limit);

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    (Encoding? Encoding, float Confidence) Read(
        byte[] buffer,
        int offset,
        int count);

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <returns>The interpretation result.</returns>
    (Encoding? Encoding, float Confidence) Read(
        byte[] buffer,
        int count);

    /// <summary>
    /// Read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <returns>The interpretation result.</returns>
    (Encoding? Encoding, float Confidence) Read(
        byte[] buffer);

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously read data from a stream and feed it into the recognition engine.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="limit">The limit on the number of bytes to read, if available.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        Stream stream,
        int limit,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="offset">The offset within the buffer to start reading from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        int offset,
        int count,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="count">The number of bytes to read.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        int count,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously read data from a byte array and feed it into the recognition engine.
    /// </summary>
    /// <param name="buffer">The buffer to read from.</param>
    /// <param name="cancellationToken">The cancellation token for this operation.</param>
    /// <returns>A task representing this asynchronous operation, containing the interpretation result.</returns>
    Task<(Encoding? Encoding, float Confidence)> ReadAsync(
        byte[] buffer,
        CancellationToken cancellationToken = default);
}