using System.Diagnostics.CodeAnalysis;

namespace IX.Core.Collections;

[SuppressMessage(
    "StyleCop.CSharp.DocumentationRules",
    "SA1601:Partial elements should be documented",
    Justification = "This conflicts with how XML documentation works.")]
public partial class ConcurrentDictionary<TKey, TValue>
{
    #if !FRAMEWORK_ADVANCED && !FRAMEWORK_GT_471
        [ThreadStatic]
        [SuppressMessage(
            "ReSharper",
            "StaticMemberInGenericType",
            Justification = "This field is used exclusively under lock, so this is safe.")]
        private static object? threadStaticAddFactory;

        private static TValue AddInternal<TState>(TKey key)
        {
            var innerState = (TState)_threadStaticMethods!;
            var innerAdd = (Func<TKey, TState, TValue>)threadStaticAddFactory!;

            return innerAdd(
                key,
                innerState);
        }

        /// <summary>
        ///     Uses the specified functions to add a key/value pair to the <see cref="Core.Collections.ConcurrentDictionary{TKey,TValue}" /> if the
        ///     key does not already exist, or to update a key/value pair in the <see cref="Core.Collections.ConcurrentDictionary{TKey,TValue}" />
        ///     if the key already exists.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="key">The key to be added or whose value should be updated.</param>
        /// <param name="addValueFactory">The function used to generate a value for an absent key.</param>
        /// <param name="updateValueFactory">
        ///     The function used to generate a new value for an existing key based on the key's
        ///     existing value.
        /// </param>
        /// <param name="state">The state object.</param>
        /// <returns>
        ///     The new value for the key. This will be either be the result of addValueFactory (if the key was absent) or the
        ///     result of updateValueFactory (if the key was present).
        /// </returns>
        public TValue AddOrUpdate<TState>(
            TKey key,
            Func<TKey, TState, TValue> addValueFactory,
            Func<TKey, TValue, TState, TValue> updateValueFactory,
            TState state)
        {
            _threadStaticMethods = state;
            threadStaticAddFactory = addValueFactory;
            _threadStaticUpdateFactory = updateValueFactory;

            try
            {
                return AddOrUpdate(
                    key,
                    AddInternal<TState>,
                    UpdateInternal<TState>);
            }
            finally
            {
                _threadStaticMethods = null;
                threadStaticAddFactory = null;
                _threadStaticUpdateFactory = null;
            }
        }

        /// <summary>
        ///     Adds a key/value pair to the <see cref="Core.Collections.ConcurrentDictionary{TKey,TValue}" /> by using the specified function, if
        ///     the key does not already exist.
        /// </summary>
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="key">The key of the element to add.</param>
        /// <param name="valueFactory">The function used to generate a value for the key.</param>
        /// <param name="state">The state object.</param>
        /// <returns>
        ///     The value for the key. This will be either the existing value for the key if the key is already in the
        ///     dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
        /// </returns>
        public TValue GetOrAdd<TState>(
            TKey key,
            Func<TKey, TState, TValue> valueFactory,
            TState state)
        {
            _threadStaticMethods = state;
            threadStaticAddFactory = valueFactory;

            try
            {
                return GetOrAdd(
                    key,
                    AddInternal<TState>);
            }
            finally
            {
                _threadStaticMethods = null;
                threadStaticAddFactory = null;
                _threadStaticUpdateFactory = null;
            }
        }
    #endif
}