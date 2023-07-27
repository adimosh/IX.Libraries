using IX.Core.Collections;
using IX.Core.System;

using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using IX.Math.Extensibility;
using IX.Math.Nodes;

namespace IX.Math.Generators;

internal static class FunctionsDictionaryGenerator
{
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    internal static void GenerateInternalNonaryFunctionsDictionary(
        this IEnumerable<Assembly> assemblies,
        Dictionary<string, Type> typeDictionary) =>
        GenerateTypeAssignableFrom<NonaryFunctionNodeBase>(
            assemblies,
            typeDictionary);

    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    internal static void GenerateInternalUnaryFunctionsDictionary(
        this IEnumerable<Assembly> assemblies,
        Dictionary<string, Type> typeDictionary) =>
        GenerateTypeAssignableFrom<UnaryFunctionNodeBase>(
            assemblies,
            typeDictionary);

    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    internal static void GenerateInternalBinaryFunctionsDictionary(
        this IEnumerable<Assembly> assemblies,
        Dictionary<string, Type> typeDictionary) =>
        GenerateTypeAssignableFrom<BinaryFunctionNodeBase>(
            assemblies,
            typeDictionary);

    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    internal static void GenerateInternalTernaryFunctionsDictionary(
        this IEnumerable<Assembly> assemblies,
        Dictionary<string, Type> typeDictionary) =>
        GenerateTypeAssignableFrom<TernaryFunctionNodeBase>(
            assemblies,
            typeDictionary);

    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "This is how LINQ works")]
    [RequiresUnreferencedCode("This method uses reflection to get in-depth type information.")]
    private static void GenerateTypeAssignableFrom<T>(
        IEnumerable<Assembly> assemblies,
        Dictionary<string, Type> typeDictionary)
        where T : FunctionNodeBase
    {
        // TODO: Do this in parallel
        assemblies.GetTypesAssignableFrom<T>().ForEach(
            AddToTypeDictionary,
            typeDictionary);

        void AddToTypeDictionary(
            TypeInfo p,
            Dictionary<string, Type> td)
        {
            CallableMathematicsFunctionAttribute attr;

            try
            {
                attr = p.GetCustomAttribute<CallableMathematicsFunctionAttribute>();
            }
            catch
            {
                return;
            }

            if (attr == null)
            {
                return;
            }

            foreach (var q in attr.Names)
            {
                if (td.ContainsKey(q))
                {
                    continue;
                }

                td.Add(
                    q,
                    p.AsType());
            }
        }
    }
}