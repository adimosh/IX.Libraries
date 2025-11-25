using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace IX.Library;

/// <summary>
///     Extensions for <see cref="TypeInfo" />.
/// </summary>
public static class TypeInfoExtensions
{
    /// <param name="typeInfo">The type information.</param>
    extension(TypeInfo typeInfo)
    {
        /// <summary>
        ///     Gets the attribute data by type without version binding.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to get data for.</typeparam>
        /// <typeparam name="TReturn">The type of data to return.</typeparam>
        /// <param name="value">The output value.</param>
        /// <returns><see langword="true" /> if the attribute exists and has data, <see langword="false" /> otherwise.</returns>
        [SuppressMessage(
            "Performance",
            "HAA0401:Possible allocation of reference type enumerator",
            Justification = "Expected.")]
        [SuppressMessage(
            "Performance",
            "HAA0303:Lambda or anonymous method in a generic method allocates a delegate instance",
            Justification = "Expected.")]
        [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
        public bool GetAttributeDataByTypeWithoutVersionBinding<TAttribute, TReturn>(out TReturn? value)
        {
            CustomAttributeData? attributeData =
                (typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).CustomAttributes.FirstOrDefault(
                    attribute => attribute.AttributeType.FullName == typeof(TAttribute).FullName);

            if (attributeData == null)
            {
                value = default!;

                return false;
            }

            using (IEnumerator<CustomAttributeTypedArgument> arguments = attributeData.ConstructorArguments
                                                                                      .Where(p => p.ArgumentType == typeof(TReturn)).GetEnumerator())
            {
                if (arguments.MoveNext())
                {
                    value = (TReturn?)arguments.Current.Value;

                    if (!arguments.MoveNext())
                    {
                        return true;
                    }
                }
            }

            using IEnumerator<CustomAttributeTypedArgument> namedArguments = attributeData.NamedArguments
                                                                                          .Where(p => p.TypedValue.ArgumentType == typeof(TReturn))
                                                                                          .Select(p => p.TypedValue)
                                                                                          .GetEnumerator();

            if (namedArguments.MoveNext())
            {
                value = (TReturn?)namedArguments.Current.Value;

                if (!namedArguments.MoveNext())
                {
                    return true;
                }
            }

            value = default!;

            return false;
        }

        /// <summary>
        ///     Gets a method with exact parameters, if one exists.
        /// </summary>
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
        public MethodInfo? GetMethodWithExactParameters(
            string name,
            params Type[] parameters) =>
            (typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).AsType().GetMethodWithExactParameters(
                name,
                parameters);

        /// <summary>
        ///     Gets a method with exact parameters, if one exists.
        /// </summary>
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
        public MethodInfo? GetMethodWithExactParameters(
            string name,
            params TypeInfo[] parameters) =>
            (typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).AsType().GetMethodWithExactParameters(
                name,
                parameters.Select(p => p.AsType()).ToArray());

        /// <summary>
        ///     Determines whether a type has a public parameter-less constructor.
        /// </summary>
        /// <returns><see langword="true" /> if there is a parameter-less constructor; otherwise, <see langword="false" />.</returns>
        [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
        public bool HasPublicParameterlessConstructor() =>
            !(typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).IsInterface && typeInfo is { IsAbstract: false, IsGenericTypeDefinition: false } &&
            typeInfo.DeclaredConstructors.Any(
                p => !p.IsStatic && p is { IsPublic: true, IsGenericMethodDefinition: false } && p.GetParameters().Length == 0);

        /// <summary>
        ///     Instantiates an object of the specified type.
        /// </summary>
        /// <returns>An instance of the object to instantiate.</returns>
        [RequiresUnreferencedCode("This method uses Activator.CreateInstance")]
        public object Instantiate() =>
            Activator.CreateInstance((typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).AsType()) ??
            throw new InvalidOperationException("Could not instantiate the object.");

        /// <summary>
        ///     Instantiates an object of the specified type.
        /// </summary>
        /// <param name="parameters">The parameters to pass through to the constructor.</param>
        /// <returns>An instance of the object to instantiate.</returns>
        [RequiresUnreferencedCode("This method uses Activator.CreateInstance")]
        public object Instantiate(params object[] parameters) =>
            Activator.CreateInstance(
                (typeInfo ?? throw new ArgumentNullException(nameof(typeInfo))).AsType(),
                parameters) ??
            throw new InvalidOperationException("Could not instantiate the object.");
    }
}