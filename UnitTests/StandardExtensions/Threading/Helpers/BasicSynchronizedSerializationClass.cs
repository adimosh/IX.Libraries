using System.Runtime.Serialization;

namespace UnitTests.StandardExtensions.Threading.Helpers;

[DataContract(Namespace = "http://test.namespaces.org/butter")]
internal class BasicSynchronizedSerializationClass : ReaderWriterSynchronizedBase
{
    [DataMember]
    public int Setty { get; set; }
}