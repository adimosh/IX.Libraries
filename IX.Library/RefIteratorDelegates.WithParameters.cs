namespace IX.Core;

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1>(in TIteratorItem iteratorItem, ref TParam1 param1);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, in TParam2, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, in TParam2>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc2<in TIteratorItem, TParam1, in TParam2, in TParam3, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
[PublicAPI]
public delegate void RefIteratorAction2<TIteratorItem, TParam1, in TParam2, in TParam3>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, TParam2, in TParam3, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, TParam2, in TParam3>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, TParam3, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2, TParam3>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc3<in TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
[PublicAPI]
public delegate void RefIteratorAction3<TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc2<in TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
[PublicAPI]
public delegate void RefIteratorAction2<TIteratorItem, TParam1, TParam2, in TParam3, in TParam4>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, TParam2, TParam3, in TParam4, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, TParam2, TParam3, in TParam4>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2, TParam3, TParam4>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc4<in TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefIteratorAction4<TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc3<in TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefIteratorAction3<TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc2<in TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefIteratorAction2<TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc5<in TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefIteratorAction5<TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc4<in TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefIteratorAction4<TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc3<in TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefIteratorAction3<TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc2<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefIteratorAction2<TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc6<in TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefIteratorAction6<TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc5<in TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefIteratorAction5<TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc4<in TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefIteratorAction4<TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc3<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefIteratorAction3<TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc2<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefIteratorAction2<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc7<in TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction7<TIteratorItem, TParam1, in TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc6<in TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction6<TIteratorItem, TParam1, TParam2, in TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc5<in TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction5<TIteratorItem, TParam1, TParam2, TParam3, in TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc4<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction4<TIteratorItem, TParam1, TParam2, TParam3, TParam4, in TParam5, in TParam6, in TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc3<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction3<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, in TParam6, in TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc2<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction2<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, in TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc1<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, in TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7.</param>
[PublicAPI]
public delegate void RefIteratorAction1<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, in TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, with a return type, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <typeparam name="TResult">The type of the result.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7. This parameter is passed by reference.</param>
/// <returns>The result of the method.</returns>
[PublicAPI]
public delegate TResult RefIteratorFunc<in TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, out TResult>(TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, ref TParam8 param8);

/// <summary>
///     A generic delegate for a method whose parameters are all marked as &quot;ref&quot;, usable with an iterator variable.
/// </summary>
/// <typeparam name="TIteratorItem">The type of the iterator variable.</typeparam>
/// <typeparam name="TParam1">The type of the parameter at index 0.</typeparam>
/// <typeparam name="TParam2">The type of the parameter at index 1.</typeparam>
/// <typeparam name="TParam3">The type of the parameter at index 2.</typeparam>
/// <typeparam name="TParam4">The type of the parameter at index 3.</typeparam>
/// <typeparam name="TParam5">The type of the parameter at index 4.</typeparam>
/// <typeparam name="TParam6">The type of the parameter at index 5.</typeparam>
/// <typeparam name="TParam7">The type of the parameter at index 6.</typeparam>
/// <typeparam name="TParam8">The type of the parameter at index 7.</typeparam>
/// <param name="iteratorItem">A parameter of type <typeparamref name="TIteratorItem" /> to pass to the method as an iterator variable.</param>
/// <param name="param1">A parameter of type <typeparamref name="TParam1" /> to pass to the method at index 0. This parameter is passed by reference.</param>
/// <param name="param2">A parameter of type <typeparamref name="TParam2" /> to pass to the method at index 1. This parameter is passed by reference.</param>
/// <param name="param3">A parameter of type <typeparamref name="TParam3" /> to pass to the method at index 2. This parameter is passed by reference.</param>
/// <param name="param4">A parameter of type <typeparamref name="TParam4" /> to pass to the method at index 3. This parameter is passed by reference.</param>
/// <param name="param5">A parameter of type <typeparamref name="TParam5" /> to pass to the method at index 4. This parameter is passed by reference.</param>
/// <param name="param6">A parameter of type <typeparamref name="TParam6" /> to pass to the method at index 5. This parameter is passed by reference.</param>
/// <param name="param7">A parameter of type <typeparamref name="TParam7" /> to pass to the method at index 6. This parameter is passed by reference.</param>
/// <param name="param8">A parameter of type <typeparamref name="TParam8" /> to pass to the method at index 7. This parameter is passed by reference.</param>
[PublicAPI]
public delegate void RefIteratorAction<TIteratorItem, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(in TIteratorItem iteratorItem, ref TParam1 param1, ref TParam2 param2, ref TParam3 param3, ref TParam4 param4, ref TParam5 param5, ref TParam6 param6, ref TParam7 param7, ref TParam8 param8);