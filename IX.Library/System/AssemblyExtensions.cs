using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace IX.Library.System;

/// <summary>
///     Extensions for <see cref="Assembly" />.
/// </summary>
public static class AssemblyExtensions
{
    /// <summary>
    ///     Gets the types assignable from a specified type from an assembly.
    /// </summary>
    /// <typeparam name="T">The type that all fetched types must be assignable from.</typeparam>
    /// <param name="assembly">The assembly to search.</param>
    /// <returns>An enumeration of types that are assignable from the given type.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unfortunately, this is not avoidable.")]
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    public static IEnumerable<TypeInfo> GetTypesAssignableFrom<T>(this Assembly assembly)
    {
        return Requires.NotNull(assembly)
            .DefinedTypes.Where(Filter);

        static bool Filter(TypeInfo p) =>
            typeof(T).GetTypeInfo()
                     .IsAssignableFrom(p);
    }

    /// <summary>
    ///     Gets the types assignable from a specified type from an enumeration of assemblies.
    /// </summary>
    /// <typeparam name="T">The type that all fetched types must be assignable from.</typeparam>
    /// <param name="assemblies">The assemblies to search.</param>
    /// <returns>An enumeration of types that are assignable from the given type.</returns>
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unfortunately, this is not avoidable.")]
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    public static IEnumerable<TypeInfo> GetTypesAssignableFrom<T>(this IEnumerable<Assembly> assemblies)
    {
        return Requires.NotNull(assemblies)
            .SelectMany(GetAssignableTypes);

        static IEnumerable<TypeInfo> GetAssignableTypes(Assembly p) => p.GetTypesAssignableFrom<T>();
    }
}