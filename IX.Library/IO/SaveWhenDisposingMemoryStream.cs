namespace IX.Library.IO;

/// <summary>
///     A memory stream that saves when it disposes.
/// </summary>
public class SaveWhenDisposingMemoryStream : MemoryStream
{
    private readonly Action<byte[]> _saveFile;

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(Action<byte[]> saveFile) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="buffer">The array of unsigned bytes from which to create this stream.</param>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(
        byte[] buffer,
        Action<byte[]> saveFile)
        : base(buffer) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="capacity">The initial size of the internal array in bytes.</param>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(
        int capacity,
        Action<byte[]> saveFile)
        : base(capacity) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="buffer">The array of unsigned bytes from which to create this stream.</param>
    /// <param name="writable">
    ///     The setting of the <see cref="MemoryStream.CanWrite" /> property, which determines
    ///     whether the stream supports writing.
    /// </param>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(
        byte[] buffer,
        bool writable,
        Action<byte[]> saveFile)
        : base(
            buffer,
            writable) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="buffer">The array of unsigned bytes from which to create this stream.</param>
    /// <param name="index">The index into buffer at which the stream begins.</param>
    /// <param name="count">The length of the stream in bytes.</param>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(
        byte[] buffer,
        int index,
        int count,
        Action<byte[]> saveFile)
        : base(
            buffer,
            index,
            count) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="buffer">The array of unsigned bytes from which to create this stream.</param>
    /// <param name="index">The index into buffer at which the stream begins.</param>
    /// <param name="count">The length of the stream in bytes.</param>
    /// <param name="writable">
    ///     The setting of the <see cref="MemoryStream.CanWrite" /> property, which determines
    ///     whether the stream supports writing.
    /// </param>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(
        byte[] buffer,
        int index,
        int count,
        bool writable,
        Action<byte[]> saveFile)
        : base(
            buffer,
            index,
            count,
            writable) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Initializes a new instance of the <see cref="SaveWhenDisposingMemoryStream" /> class.
    /// </summary>
    /// <param name="buffer">The array of unsigned bytes from which to create this stream.</param>
    /// <param name="index">The index into buffer at which the stream begins.</param>
    /// <param name="count">The length of the stream in bytes.</param>
    /// <param name="writable">
    ///     The setting of the <see cref="MemoryStream.CanWrite" /> property, which determines
    ///     whether the stream supports writing.
    /// </param>
    /// <param name="publiclyVisible">
    ///     <see langword="true" /> to enable <see cref="MemoryStream.GetBuffer" />, which returns the unsigned
    ///     byte array from which the stream was created; otherwise, <see langword="false" />.
    /// </param>
    /// <param name="saveFile">The file save action that should be invoked when this instance is correctly disposed.</param>
    /// <exception cref="ArgumentNullException">
    ///     Occurs when the <paramref name="saveFile" /> is
    ///     <see langword="null" /> (<see langword="Nothing" /> in Visual Basic).
    /// </exception>
    public SaveWhenDisposingMemoryStream(
        byte[] buffer,
        int index,
        int count,
        bool writable,
        bool publiclyVisible,
        Action<byte[]> saveFile)
        : base(
            buffer,
            index,
            count,
            writable,
            publiclyVisible) =>
        _saveFile = saveFile ?? throw new ArgumentNullException(nameof(saveFile));

    /// <summary>
    ///     Releases the unmanaged resources used by the <see cref="MemoryStream" /> class and optionally releases
    ///     the managed resources.
    /// </summary>
    /// <param name="disposing">
    ///     <see langword="true" /> to release both managed and unmanaged resources;
    ///     <see langword="false" /> to release only unmanaged resources.
    /// </param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            _saveFile(ToArray());

        base.Dispose(disposing);
    }
}