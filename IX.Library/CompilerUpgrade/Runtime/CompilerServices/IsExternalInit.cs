#if !NET6_0_OR_GREATER

// ReSharper disable once CheckNamespace
namespace System.Runtime.CompilerServices;

/// <summary>
///     Dummy class for allowing init-only properties in pre-.NET 5.0 frameworks.
/// </summary>
[PublicAPI]
public class IsExternalInit { }
#endif