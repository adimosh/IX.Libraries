namespace IX.Library.ComponentModel;

/// <summary>
///     An abstract base class for correctly implementing the disposable pattern.
/// </summary>
/// <seealso cref="IDisposable" />
public abstract partial class DisposableBase
{
    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1>(
        Action<TParam1> action,
        TParam1 param1)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TReturn>(
        Func<TParam1, TReturn> func,
        TParam1 param1)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2>(
        Action<TParam1, TParam2> action,
        TParam1 param1,
        TParam2 param2)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TReturn>(
        Func<TParam1, TParam2, TReturn> func,
        TParam1 param1,
        TParam2 param2)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2, TParam3>(
        Action<TParam1, TParam2, TParam3> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2,
                param3);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TParam3, TReturn>(
        Func<TParam1, TParam2, TParam3, TReturn> func,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2,
                param3);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4>(
        Action<TParam1, TParam2, TParam3, TParam4> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2,
                param3,
                param4);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TReturn>(
        Func<TParam1, TParam2, TParam3, TParam4, TReturn> func,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2,
                param3,
                param4);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5>(
        Action<TParam1, TParam2, TParam3, TParam4, TParam5> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TReturn>(
        Func<TParam1, TParam2, TParam3, TParam4, TParam5, TReturn> func,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(
        Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5,
                param6);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturn>(
        Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TReturn> func,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5,
                param6);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(
        Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5,
                param6,
                param7);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturn>(
        Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TReturn> func,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5,
                param6,
                param7);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="action" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected void InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(
        Action<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> action,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        ThrowIfCurrentObjectDisposed();

        (action ?? throw new ArgumentNullException(nameof(action)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5,
                param6,
                param7,
                param8);
    }

    /// <summary>
    ///     Invokes an action if the current instance is not disposed.
    /// </summary>
    /// <typeparam name="TParam1">The type of parameter to be passed to the invoked method at index 0.</typeparam>
    /// <typeparam name="TParam2">The type of parameter to be passed to the invoked method at index 1.</typeparam>
    /// <typeparam name="TParam3">The type of parameter to be passed to the invoked method at index 2.</typeparam>
    /// <typeparam name="TParam4">The type of parameter to be passed to the invoked method at index 3.</typeparam>
    /// <typeparam name="TParam5">The type of parameter to be passed to the invoked method at index 4.</typeparam>
    /// <typeparam name="TParam6">The type of parameter to be passed to the invoked method at index 5.</typeparam>
    /// <typeparam name="TParam7">The type of parameter to be passed to the invoked method at index 6.</typeparam>
    /// <typeparam name="TParam8">The type of parameter to be passed to the invoked method at index 7.</typeparam>
    /// <typeparam name="TReturn">The return type of the invoked method.</typeparam>
    /// <param name="func">The function to invoke.</param>
    /// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the invoked method at index 0.</param>
    /// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the invoked method at index 1.</param>
    /// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the invoked method at index 2.</param>
    /// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the invoked method at index 3.</param>
    /// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the invoked method at index 4.</param>
    /// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the invoked method at index 5.</param>
    /// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the invoked method at index 6.</param>
    /// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the invoked method at index 7.</param>
    /// <returns>A return value, as defined by the invoked method.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="func" /> is <see langword="null"/> (
    ///     <see langword="Nothing"/> in Visual Basic).
    /// </exception>
    protected TReturn InvokeIfNotDisposed<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturn>(
        Func<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TReturn> func,
        TParam1 param1,
        TParam2 param2,
        TParam3 param3,
        TParam4 param4,
        TParam5 param5,
        TParam6 param6,
        TParam7 param7,
        TParam8 param8)
    {
        ThrowIfCurrentObjectDisposed();

        return (func ?? throw new ArgumentNullException(nameof(func)))
            .Invoke(
                param1,
                param2,
                param3,
                param4,
                param5,
                param6,
                param7,
                param8);
    }
}