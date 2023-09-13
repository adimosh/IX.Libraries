using IX.Library.Globalization;

using System.Text;
using UtfUnknown.Core;

namespace UnitTests.StandardExtensions.Globalization;

public class CharsetDetectorSimpleUnitTests
{
    private static MemoryStream AsciiToStream(string s) => new(Encoding.ASCII.GetBytes(s));

    [Fact(DisplayName = "Pure ASCII")]
    public void TestAscii()
    {
        const string text = "The Documentation of the libraries is not complete " +
                         "and your contributions would be greatly appreciated " +
                         "the documentation you want to contribute to and " +
                         "click on the [Edit] link to start writing";
        var stream = AsciiToStream(text);
        using (stream)
        {
            var result = new CharsetDetectionEngine().Read(stream);
            Assert.Equal(Encoding.ASCII, result.Encoding);
            Assert.Equal(1.0f, result.Confidence);
        }
    }

    [Fact(DisplayName = "Escaped ASCII with HZ sequence")]
    public void TestAscii_with_HZ_sequence()
    {
        const string text = "virtual ~{{NETCLASS_NAME}}();";
        var stream = AsciiToStream(text);
        using (stream)
        {
            var result = new CharsetDetectionEngine().Read(stream);
            Assert.Equal(Encoding.ASCII, result.Encoding);
            Assert.Equal(1.0f, result.Confidence);
        }
    }

    [Theory(DisplayName = "Test reading from stream with a specified maximum number of bytes.")]
    [InlineData(1024, 1024)]
    [InlineData(2048, 2048)]
    [InlineData(20, 20)]
    [InlineData(20, 30, 10)]
    [InlineData(null, 10000)]
    [InlineData(1000000, 10000)]
    [InlineData(null, 10000, 10)]
    public void DetectFromStreamMaxBytes(int? maxBytes, int expectedPosition, int start = 0)
    {
        // Arrange
        var text = new string('a', 10000);
        var stream = AsciiToStream(text);
        stream.Position = start;

        // Act
        if (maxBytes == null)
        {
            _ = new CharsetDetectionEngine().Read(stream);
        }
        else
        {
            _ = new CharsetDetectionEngine().Read(
                stream,
                maxBytes.Value);
        }

        // Assert
        Assert.Equal(expectedPosition, stream.Position);
    }

    [Theory(DisplayName = "ASCII and UTF8 Korean")]
    [InlineData(0, 10, CodepageName.ASCII)]
    [InlineData(0, 100, CodepageName.UTF8)]
    [InlineData(10, 100, CodepageName.UTF8)]
    public void DetectFromByteArray(int offset, int len, string detectedCodepage)
    {
        // Arrange
        string s = "UTF-Unknown은 파일, 스트림, 그 외 바이트 배열의 캐릭터 셋을 탐지하는 라이브러리입니다." +
            "대한민국 (大韓民國, Republic of Korea)";
        byte[] bytes = Encoding.UTF8.GetBytes(s);

        // Act
        var result = new CharsetDetectionEngine().Read(bytes, offset, len);

        // Assert
        Assert.Equal(Encoding.GetEncoding(detectedCodepage), result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Theory(DisplayName = "UTF7 with BOM")]
    [InlineData(new byte[] { 0x2B, 0x2F, 0x76, 0x38 })]
    [InlineData(new byte[] { 0x2B, 0x2F, 0x76, 0x39 })]
    [InlineData(new byte[] { 0x2B, 0x2F, 0x76, 0x2B })]
    [InlineData(new byte[] { 0x2B, 0x2F, 0x76, 0x2F })]
    [InlineData(new byte[] { 0x2B, 0x2F, 0x76, 0x38, 0x2D })]
    public void TestCaseBomUtf7(byte[] bufferBytes)
    {
        var result = new CharsetDetectionEngine().Read(bufferBytes);
#pragma warning disable CS0618
#pragma warning disable SYSLIB0001 // Type or member is obsolete
        Assert.Equal(Encoding.UTF7, result.Encoding);
#pragma warning restore SYSLIB0001 // Type or member is obsolete
#pragma warning restore CS0618
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "GB18030 with BOM")]
    public void TestBomGb18030()
    {
        var bufferBytes = new byte[] { 0x84, 0x31, 0x95, 0x33 };
        var result = new CharsetDetectionEngine().Read(bufferBytes);
        Assert.Equal(CharsetDetectionEngine.GetCompatibleEncodingByShortName(CodepageName.GB18030), result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF8 without BOM")]
    public void TestUTF8_1()
    {
        string s = "ウィキペディアはオープンコンテントの百科事典です。基本方針に賛同し" +
                   "ていただけるなら、誰でも記事を編集したり新しく作成したりできます。" +
                   "ガイドブックを読んでから、サンドボックスで練習してみましょう。質問は" +
                   "利用案内でどうぞ。";
        byte[] buf = Encoding.UTF8.GetBytes(s);
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.UTF8, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF8 with BOM")]
    public void TestBomUtf8()
    {
        byte[] buf = { 0xEF, 0xBB, 0xBF, 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x21 };
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.UTF8, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF16 big-endian just BOM")]
    public void Test2byteArrayBomUTF16_BE()
    {
        byte[] buf = { 0xFE, 0xFF, };

        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.GetEncoding(CodepageName.UTF16_BE), result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF16 big-endian with BOM")]
    public void TestBomUTF16_BE()
    {
        byte[] buf = { 0xFE, 0xFF, 0x00, 0x68, 0x00, 0x65 };

        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.GetEncoding(CodepageName.UTF16_BE), result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UCS4 3412 unsupported")]
    public void TestBomX_ISO_10646_UCS_4_3412()
    {
        byte[] buf = { 0xFE, 0xFF, 0x00, 0x00, 0x65 };

        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Null(result.Encoding);
        Assert.Equal(0f, result.Confidence);
    }

    [Fact(DisplayName = "UCS4 2143 unsupported")]
    public void TestBomX_ISO_10646_UCS_4_2143()
    {
        byte[] buf = { 0x00, 0x00, 0xFF, 0xFE, 0x00, 0x65 };

        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Null(result.Encoding);
        Assert.Equal(0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF16 little-endian only BOM")]
    public void Test2byteArrayBomUTF16_LE()
    {
        byte[] buf = { 0xFF, 0xFE, };
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.Unicode, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF16 little-endian with BOM")]
    public void TestBomUTF16_LE()
    {
        byte[] buf = { 0xFF, 0xFE, 0x68, 0x00, 0x65, 0x00 };
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.Unicode, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF32 big-endian")]
    public void TestBomUTF32_BE()
    {
        byte[] buf = { 0x00, 0x00, 0xFE, 0xFF, 0x00, 0x00, 0x00, 0x68 };
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.GetEncoding(CodepageName.UTF32_BE), result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF32 little-endian")]
    public void TestBomUTF32_LE()
    {
        byte[] buf = { 0xFF, 0xFE, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00 };
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.GetEncoding(CodepageName.UTF32_LE), result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "UTF8 ASCII-only characters")]
    public void TestIssue3()
    {
        byte[] buf = Encoding.UTF8.GetBytes("3");
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.ASCII, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "ASCII out-of-range")]
    public void TestOutOfRange2()
    {
        byte[] buf = Encoding.UTF8.GetBytes("1234567890");
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.ASCII, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }

    [Fact(DisplayName = "ASCII single-char")]
    public void TestSingleChar()
    {
        byte[] buf = Encoding.UTF8.GetBytes("3");
        var result = new CharsetDetectionEngine().Read(buf);
        Assert.Equal(Encoding.ASCII, result.Encoding);
        Assert.Equal(1.0f, result.Confidence);
    }
}