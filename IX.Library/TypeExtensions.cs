using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace IX.Library;

/// <summary>
///     Extensions for <see cref="Type" />.
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    ///     Gets the attribute data by type without version binding.
    /// </summary>
    /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
    /// <typeparam name="TReturn">The type of the return.</typeparam>
    /// <param name="typeInfo">The type information.</param>
    /// <param name="value">The value.</param>
    /// <returns><c>true</c> if the attribute was recognized and has data, <c>false</c> otherwise.</returns>
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    public static bool GetAttributeDataByTypeWithoutVersionBinding<TAttribute, TReturn>(
        this Type typeInfo,
        out TReturn? value) =>
        typeInfo.GetTypeInfo().GetAttributeDataByTypeWithoutVersionBinding<TAttribute, TReturn>(out value);

    /// <summary>
    ///     Gets a method with exact parameters, if one exists.
    /// </summary>
    /// <param name="typeInfo">The type information.</param>
    /// <param name="name">The name of the method to find.</param>
    /// <param name="parameters">The parameters list, if any.</param>
    /// <returns>
    ///     A <see cref="MethodInfo" /> object representing the found method, or <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic), if none is found.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="typeInfo" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable.")]
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    public static MethodInfo? GetMethodWithExactParameters(
        this Type typeInfo,
        string name,
        params Type[] parameters)
    {
        MethodInfo? mi = null;

        foreach (MethodInfo p in (typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).GetRuntimeMethods())
        {
            if (p.Name != name)
            {
                continue;
            }

            ParameterInfo[] ps = p.GetParameters();

            if ((parameters?.Length ?? 0) != ps.Length)
            {
                continue;
            }

            if (parameters?.SequenceEqual(ps.Select(q => q.ParameterType)) ?? true)
            {
                if (mi != null)
                {
                    throw new InvalidOperationException(Resources.SingleOrDefaultMultipleElements);
                }

                mi = p;
            }
        }

        return mi;
    }

    /// <summary>
    ///     Gets a method with exact parameters, if one exists.
    /// </summary>
    /// <param name="typeInfo">The type information.</param>
    /// <param name="name">The name of the method to find.</param>
    /// <param name="parameters">The parameters list, if any.</param>
    /// <returns>
    ///     A <see cref="MethodInfo" /> object representing the found method, or <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic), if none is found.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="typeInfo" /> is <see langword="null" /> (
    ///     <see langword="Nothing" /> in Visual Basic).
    /// </exception>
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    public static MethodInfo? GetMethodWithExactParameters(
        this Type typeInfo,
        string name,
        params TypeInfo[] parameters) =>
        typeInfo.GetMethodWithExactParameters(
            name,
            parameters.Select(p => p.AsType()).ToArray());

    /// <summary>
    ///     Determines whether a type has a public parameter-less constructor.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns><see langword="true" /> if there is a parameter-less constructor; otherwise, <see langword="false" />.</returns>
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    public static bool HasPublicParameterlessConstructor(this Type type) =>
        type.GetTypeInfo().HasPublicParameterlessConstructor();

    /// <summary>
    ///     Instantiates an object of the specified type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>An instance of the object to instantiate.</returns>
    [RequiresUnreferencedCode("This method uses Activator.CreateInstance")]
    public static object? Instantiate(this Type type) => Activator.CreateInstance(type);

    /// <summary>
    ///     Instantiates an object of the specified type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="parameters">The parameters to pass through to the constructor.</param>
    /// <returns>An instance of the object to instantiate.</returns>
    [RequiresUnreferencedCode("This method uses Activator.CreateInstance")]
    public static object? Instantiate(
        this Type type,
        params object[] parameters) =>
        Activator.CreateInstance(
            type,
            parameters);
}