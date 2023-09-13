using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Xml;

namespace IX.Library.Serialization;

/// <summary>
/// A strongly-typed implementation of <see cref="T:System.Runtime.Serialization.DataContractSerializer"/>, acting as a wrapper over it.
/// </summary>
/// <typeparam name="T">The type of object to serialize or deserialize.</typeparam>
/// <remarks>
/// <para>Since the <see cref="XmlObjectSerializer"/> is a class with its own methods and state, a decision has been made to not implement
/// the strongly-typed Data Contract Serializer as a child of it.</para>
/// </remarks>
[PublicAPI]
public class DataContractSerializer<T>
{
    private const string SerializerTrimmerWarning =
        "Data Contract Serialization and Deserialization might require types that cannot be statically analyzed. Make sure all of the required types are preserved.";
    private readonly DataContractSerializer _serializer;

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type.</summary>
    public DataContractSerializer() => _serializer = new(typeof(T));

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type, and a collection of known types that may be present in the object graph.</summary>
    /// <param name="knownTypes">An <see cref="T:System.Collections.Generic.IEnumerable`1"></see> of <see cref="T:System.Type"></see> that contains the types that may be present in the object graph.</param>
    public DataContractSerializer(IEnumerable<Type> knownTypes) => _serializer = new(typeof(T), knownTypes);

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type and settings.</summary>
    /// <param name="settings">The serializer settings.</param>
    public DataContractSerializer(DataContractSerializerSettings settings) => _serializer = new(typeof(T), settings);

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type using the supplied XML root element and namespace.</summary>
    /// <param name="rootName">The name of the XML element that encloses the content to serialize or deserialize.</param>
    /// <param name="rootNamespace">The namespace of the XML element that encloses the content to serialize or deserialize.</param>
    public DataContractSerializer(
        string rootName,
        string rootNamespace) =>
        _serializer = new(typeof(T), rootName, rootNamespace);

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type. This method also specifies the root XML element and namespace in two string parameters as well as a list of known types that may be present in the object graph.</summary>
    /// <param name="rootName">The root element name of the content.</param>
    /// <param name="rootNamespace">The namespace of the root element.</param>
    /// <param name="knownTypes">An <see cref="T:System.Collections.Generic.IEnumerable`1"></see> of <see cref="T:System.Type"></see> that contains the types that may be present in the object graph.</param>
    public DataContractSerializer(
        string rootName,
        string rootNamespace,
        IEnumerable<Type> knownTypes) =>
        _serializer = new(typeof(T), rootName, rootNamespace, knownTypes);

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type using the XML root element and namespace specified through the parameters of type <see cref="T:System.Xml.XmlDictionaryString"></see>.</summary>
    /// <param name="rootName">An <see cref="T:System.Xml.XmlDictionaryString"></see> that contains the root element name of the content.</param>
    /// <param name="rootNamespace">An <see cref="T:System.Xml.XmlDictionaryString"></see> that contains the namespace of the root element.</param>
    public DataContractSerializer(
        XmlDictionaryString rootName,
        XmlDictionaryString rootNamespace) =>
        _serializer = new(typeof(T), rootName, rootNamespace);

    /// <summary>Initializes a new instance of the <see cref="DataContractSerializer" /> class to serialize or deserialize an object of the specified type. This method also specifies the root XML element and namespace in two <see cref="T:System.Xml.XmlDictionaryString"></see> parameters as well as a list of known types that may be present in the object graph.</summary>
    /// <param name="rootName">An <see cref="T:System.Xml.XmlDictionaryString"></see> that contains the root element name of the content.</param>
    /// <param name="rootNamespace">An <see cref="T:System.Xml.XmlDictionaryString"></see> that contains the namespace of the root element.</param>
    /// <param name="knownTypes">A <see cref="T:System.Collections.Generic.IEnumerable`1"></see> of <see cref="T:System.Type"></see> that contains the known types that may be present in the object graph.</param>
    public DataContractSerializer(
        XmlDictionaryString rootName,
        XmlDictionaryString rootNamespace,
        IEnumerable<Type> knownTypes) =>
        _serializer = new(typeof(T), rootName, rootNamespace, knownTypes);

    /// <summary>
    /// Gets the known types of this serializer.
    /// </summary>
    /// <value>
    /// The known types.
    /// </value>
    public ReadOnlyCollection<Type> KnownTypes => _serializer.KnownTypes;

    /// <summary>
    /// Gets the maximum number of items in the object graph.
    /// </summary>
    /// <value>
    /// The maximum number of items in the object graph.
    /// </value>
    public int MaxItemsInObjectGraph => _serializer.MaxItemsInObjectGraph;

    /// <summary>
    /// Gets a value indicating whether or not to preserve object references.
    /// </summary>
    /// <value>
    ///   <c>true</c> to preserve object references; otherwise, <c>false</c>.
    /// </value>
    public bool PreserveObjectReferences => _serializer.PreserveObjectReferences;

    /// <summary>
    /// Gets a value indicating whether to ignore data supplied by an extension of the class when the class is being serialized or deserialized.
    /// </summary>
    /// <value>
    ///   <c>true</c> to omit the extension data; otherwise, <c>false</c>.
    /// </value>
    public bool IgnoreExtensionDataObject => _serializer.IgnoreExtensionDataObject;

    /// <summary>
    /// Gets the data contract resolver.
    /// </summary>
    /// <value>
    /// The data contract resolver.
    /// </value>
    public DataContractResolver? DataContractResolver => _serializer.DataContractResolver;

    /// <summary>
    /// Gets a value indicating whether to serialize read only types.
    /// </summary>
    /// <value>
    ///   <c>true</c> to serialize read only types; otherwise, <c>false</c>.
    /// </value>
    public bool SerializeReadOnlyTypes => _serializer.SerializeReadOnlyTypes;

    /// <summary>
    /// Writes all the object data (starting XML element, content, and closing element) to an XML document or stream.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    /// <param name="graph">The object that contains the data to serialize.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteObject(XmlWriter writer, T? graph) => _serializer.WriteObject(writer, graph);

    /// <summary>
    /// Writes the opening XML element.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    /// <param name="graph">The object to write.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteStartObject(XmlWriter writer, T? graph) => _serializer.WriteStartObject(writer, graph);

    /// <summary>
    /// Writes the XML content without the wrapping element.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    /// <param name="graph">The object that contains the data to serialize.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteObjectContent(XmlWriter writer, T? graph) => _serializer.WriteObjectContent(writer, graph);

    /// <summary>
    /// Writes the closing XML element.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteEndObject(XmlWriter writer) => _serializer.WriteEndObject(writer);

    /// <summary>
    /// Writes the opening XML element.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    /// <param name="graph">The object to write.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteStartObject(XmlDictionaryWriter writer, T? graph) => _serializer.WriteStartObject(writer, graph);

    /// <summary>
    /// Writes the XML content without the wrapping element.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    /// <param name="graph">The object that contains the data to serialize.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteObjectContent(XmlDictionaryWriter writer, T? graph) => _serializer.WriteObjectContent(writer, graph);

    /// <summary>
    /// Writes the closing XML element.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteEndObject(XmlDictionaryWriter writer) => _serializer.WriteEndObject(writer);

    /// <summary>
    /// Writes all the object data (starting XML element, content, and closing element) to an XML document or stream.
    /// The method includes a resolver for mapping <c>xsi:type</c> declarations at runtime.
    /// </summary>
    /// <param name="writer">The XML writer used to write the stream.</param>
    /// <param name="graph">The object that contains the data to serialize.</param>
    /// <param name="dataContractResolver">
    /// An implementation of the <see cref="DataContractResolver"/> to map <c>xsi:type</c> declarations to
    /// data contract types.
    /// </param>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public void WriteObject(XmlDictionaryWriter writer, T? graph, DataContractResolver? dataContractResolver)
        => _serializer.WriteObject(writer, graph, dataContractResolver);

    /// <summary>
    /// Reads the XML stream with an <see cref="XmlReader"/> and returns the deserialized object.
    /// </summary>
    /// <param name="reader">The XML reader used to read from the stream.</param>
    /// <returns>The deserialized object.</returns>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public T? ReadObject(XmlReader reader) => (T?)_serializer.ReadObject(reader);

    /// <summary>
    /// Reads the XML stream with an <see cref="XmlReader"/> and returns the deserialized object,
    /// and also specifies whether a check is made to verify the object name before reading its value.
    /// </summary>
    /// <param name="reader">The XML reader used to read from the stream.</param>
    /// <param name="verifyObjectName">
    /// <c>true</c> to check whether the name of the object corresponds
    /// to the root name value supplied in the constructor; otherwise, <c>false</c>.
    /// </param>
    /// <returns>The deserialized object.</returns>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public T? ReadObject(XmlReader reader, bool verifyObjectName) => (T?)_serializer.ReadObject(reader, verifyObjectName);

    /// <summary>
    /// Determines whether the reader is positioned on an object that can be deserialized.
    /// </summary>
    /// <param name="reader">The XML reader used to read from the stream.</param>
    /// <returns>
    ///   <c>true</c> if the reader is at the start element of the stream to read; otherwise, <c>false</c>.
    /// </returns>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public bool IsStartObject(XmlReader reader) => _serializer.IsStartObject(reader);

    /// <summary>
    /// Reads the XML stream with an <see cref="XmlDictionaryReader"/> and returns the deserialized object,
    /// and also specifies whether a check is made to verify the object name before reading its value.
    /// </summary>
    /// <param name="reader">The XML reader used to read from the stream.</param>
    /// <param name="verifyObjectName">
    /// <c>true</c> to check whether the name of the object corresponds
    /// to the root name value supplied in the constructor; otherwise, <c>false</c>.
    /// </param>
    /// <returns>The deserialized object.</returns>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public T? ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        => (T?)_serializer.ReadObject(reader, verifyObjectName);

    /// <summary>
    /// Determines whether the reader is positioned on an object that can be deserialized.
    /// </summary>
    /// <param name="reader">The XML reader used to read from the stream.</param>
    /// <returns>
    ///   <c>true</c> if the reader is at the start element of the stream to read; otherwise, <c>false</c>.
    /// </returns>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public bool IsStartObject(XmlDictionaryReader reader) => _serializer.IsStartObject(reader);

    /// <summary>
    /// Reads the XML stream with an <see cref="XmlDictionaryReader"/> and returns the deserialized object.
    /// The method includes a parameter to specify whether the object name is verified is validated, and a
    /// resolver for mapping <c>xsi:type</c> declarations at runtime.
    /// </summary>
    /// <param name="reader">The XML reader used to read from the stream.</param>
    /// <param name="verifyObjectName">
    /// <c>true</c> to check whether the name of the object corresponds
    /// to the root name value supplied in the constructor; otherwise, <c>false</c>.
    /// </param>
    /// <param name="dataContractResolver">
    /// An implementation of the <see cref="DataContractResolver"/> to map <c>xsi:type</c> declarations to
    /// data contract types.
    /// </param>
    /// <returns>The deserialized object.</returns>
    [RequiresUnreferencedCode(SerializerTrimmerWarning)]
    public T? ReadObject(XmlDictionaryReader reader, bool verifyObjectName, DataContractResolver? dataContractResolver)
        => (T?)_serializer.ReadObject(reader, verifyObjectName, dataContractResolver);
}