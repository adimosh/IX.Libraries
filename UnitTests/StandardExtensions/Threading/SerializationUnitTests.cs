using IX.Core.DataGeneration;

using System.Runtime.Serialization;
using System.Text;

using UnitTests.StandardExtensions.Threading.Helpers;

namespace UnitTests.StandardExtensions.Threading;

/// <summary>
///     Serialization unit tests.
/// </summary>
public class SerializationUnitTests
{
    /// <summary>
    ///     Tests the push down stack serialization.
    /// </summary>
    [Fact(DisplayName = "Serialization tests for inherited ReaderWriterSynchronizedBase")]
    public void TestInheritedReaderWriterSynchronizedBaseSerialization()
    {
        // ARRANGE
        // =======
        var item1 = DataGenerator.RandomNonNegativeInteger();
        using var l1 = new BasicSynchronizedSerializationClass
        {
            Setty = item1,
        };

        // The serializer
        var dcs = new DataContractSerializer(typeof(BasicSynchronizedSerializationClass));

        // The deserialization variable
        BasicSynchronizedSerializationClass l2;

        // The serialization content
        string content;

        // ACT
        // ===
        using (var ms = new MemoryStream())
        {
            dcs.WriteObject(
                ms,
                l1);

            _ = ms.Seek(
                0,
                SeekOrigin.Begin);

            using (var textReader = new StreamReader(
                       ms,
                       Encoding.UTF8,
                       false,
                       32768,
                       true))
            {
                content = textReader.ReadToEnd();
            }

            _ = ms.Seek(
                0,
                SeekOrigin.Begin);

            l2 = dcs.ReadObject(ms) as BasicSynchronizedSerializationClass;
        }

        try
        {
            // ASSERT
            // ======
            const string threadingNs = "http://ns.ixiancorp.com/IX/IX.Core.Threading";

            // Serialization content is OK
            Assert.False(string.IsNullOrWhiteSpace(content));
            Assert.Equal(
                $@"<BasicSynchronizedSerializationClass xmlns=""http://test.namespaces.org/butter"" xmlns:i=""http://www.w3.org/2001/XMLSchema-instance""><lockerTimeout xmlns=""{threadingNs}"">PT0.1S</lockerTimeout><Setty>{item1}</Setty></BasicSynchronizedSerializationClass>",
                content);

            // Deserialized object is OK
            Assert.NotNull(l2);
            Assert.Equal(
                l1.Setty,
                l2.Setty);
        }
        finally
        {
            l2?.Dispose();
        }
    }
}