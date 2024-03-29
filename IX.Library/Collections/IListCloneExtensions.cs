using System.Diagnostics.CodeAnalysis;

namespace IX.Library.Collections;

/// <summary>
///     Extensions for IList.
/// </summary>
[SuppressMessage(
    "ReSharper",
    "InconsistentNaming",
    Justification = "These are extensions for IList, so we must allow this.")]
public static partial class IListCloneExtensions
{
    /// <summary>
    ///     Shallow clones all elements of a list into another list.
    /// </summary>
    /// <typeparam name="T">The type of shallow-cloneable item in the list.</typeparam>
    /// <param name="list">The list to act on.</param>
    /// <returns>
    ///     A list .
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="list" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public static List<T> CopyWithShallowClones<T>(this List<T> list)
        where T : IShallowCloneable<T>
    {
        if (list is null) throw new ArgumentNullException(nameof(list));

        return list.Select(item => item.ShallowClone()).ToList();
    }

    /// <summary>
    ///     Deep clones the list.
    /// </summary>
    /// <typeparam name="T">The type of deep-cloneable item in the list.</typeparam>
    /// <param name="list">The list to clone.</param>
    /// <returns>
    ///     A cloned list.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="list" /> is <see langword="null" /> (<see langword="Nothing" />
    ///     in Visual Basic).
    /// </exception>
    public static List<T> DeepClone<T>(this List<T> list)
        where T : IDeepCloneable<T>
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list));
        }

        return list.Select(item => item.DeepClone()).ToList();
    }
}