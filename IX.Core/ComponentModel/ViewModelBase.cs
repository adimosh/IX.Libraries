using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace IX.Core.ComponentModel;

/// <summary>
///     A base class for view models.
/// </summary>
/// <seealso cref="NotifyPropertyChangedBase" />
/// <seealso cref="IDisposable" />
[PublicAPI]
public abstract class ViewModelBase : NotifyPropertyChangedBase, INotifyDataErrorInfo
{
    private readonly BusyScope? _busyScope;
    private readonly Lazy<ConcurrentDictionary<string, List<string>>> _entityErrors;
    private readonly object _validatorLock;

    private int _isBusy;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ViewModelBase" /> class.
    /// </summary>
    protected ViewModelBase()
        : this(
            null,
            null)
    { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ViewModelBase" /> class.
    /// </summary>
    /// <param name="synchronizationContext">The specific synchronization context to use.</param>
    protected ViewModelBase(SynchronizationContext? synchronizationContext)
        : this(
            null,
            synchronizationContext)
    { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ViewModelBase" /> class.
    /// </summary>
    /// <param name="busyScope">The busy scope.</param>
    /// <param name="synchronizationContext">The specific synchronization context to use.</param>
    protected ViewModelBase(
        BusyScope? busyScope,
        SynchronizationContext? synchronizationContext = null)
        : base(synchronizationContext)
    {
        _entityErrors = new();
        _validatorLock = new();
        _busyScope = busyScope;
    }

    /// <summary>
    ///     Gets or sets a value indicating whether this view-model is busy.
    /// </summary>
    /// <value>
    ///     <c>true</c> if this view-model is busy; otherwise, <c>false</c>.
    /// </value>
    public bool IsBusy
    {
        get => _isBusy != 0;
        set
        {
            var intValue = value ? 1 : 0;

            if (Interlocked.Exchange(
                    ref _isBusy,
                    intValue) != intValue)
            {
                RaisePropertyChanged(nameof(IsBusy));
            }
        }
    }

    /// <summary>
    ///     Occurs when the validation errors have changed for a property or for the entire entity.
    /// </summary>
    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

    /// <summary>
    ///     Gets a value indicating whether the entity has validation errors.
    /// </summary>
    /// <value><see langword="true" /> if this instance has errors; otherwise, <see langword="false" />.</value>
    public bool HasErrors =>
        _entityErrors.IsValueCreated && _entityErrors.Value.Values.Any(p => p.Count > 0);

    /// <summary>
    ///     Gets the validation errors for a specified property or for the entire view model.
    /// </summary>
    /// <param name="propertyName">
    ///     The name of the property to retrieve validation errors for; or null or
    ///     <see cref="string.Empty" />, to retrieve entity-level errors.
    /// </param>
    /// <returns>The validation errors for the property or entity.</returns>
    public IEnumerable GetErrors(string? propertyName) =>
        _entityErrors.Value.TryGetValue(
            Requires.NotNull(propertyName),
            out List<string>? propertyErrors)
            ? propertyErrors.ToArray()
            : Array.Empty<string>();

    /// <summary>
    ///     Validates this object.
    /// </summary>
    [SuppressMessage(
        "ReSharper",
        "ParameterTypeCanBeEnumerable.Local",
        Justification = "We lose the possibility to have a value type enumerator.")]
    [SuppressMessage(
        "ReSharper",
        "ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator",
        Justification = "We would lose the performance boost.")]
    [SuppressMessage(
        "Performance",
        "HAA0401:Possible allocation of reference type enumerator",
        Justification = "Unavoidable at these locations.")]
    [SuppressMessage(
        "ReSharper",
        "LoopCanBeConvertedToQuery",
        Justification = "We're trying to avoid closures.")]
    public void Validate()
    {
        lock (_validatorLock)
        {
            var initialHasErrors = HasErrors;

            // We validate the object
            var validationResults = new List<ValidationResult>();

            if (Validator.TryValidateObject(
                    this,
                    new(
                        this,
                        null), validationResults,
                    true))
            {
                if (_entityErrors.IsValueCreated)
                {
                    _entityErrors.Value.Clear();
                }
            }
            else
            {
                // Remove those properties which pass validation
                if (!_entityErrors.IsValueCreated)
                {
                    foreach (var (key, _) in _entityErrors.Value.ToArray())
                    {
                        if (AllDifferent(
                                validationResults,
                                key))
                        {
                            _ = _entityErrors.Value.TryRemove(
                                key,
                                out _);
                            RaiseErrorsChanged(key);
                        }

                        static bool AllDifferent(
                            List<ValidationResult> source,
                            string key)
                        {
                            foreach (ValidationResult r in source)
                            {
                                foreach (var m in r.MemberNames)
                                {
                                    if (m == key)
                                    {
                                        return false;
                                    }
                                }
                            }

                            return true;
                        }
                    }
                }

                // Those properties that currently don't pass validation should have their validation results saved as messages.
                foreach (IGrouping<string, ValidationResult> property in from r in validationResults
                                                                         from m in r.MemberNames
                                                                         group r by m into g
                                                                         select g)
                {
                    var messages = property.Select(r => r.ErrorMessage ?? string.Empty).ToArray();

                    List<string> errorList = _entityErrors.Value.GetOrAdd(
                        property.Key,
                        new List<string>(messages.Length));
                    errorList.Clear();
                    errorList.AddRange(messages);
                    RaiseErrorsChanged(property.Key);
                }
            }

            // Raise property changed for HasErrors, if necessary
            if (HasErrors != initialHasErrors)
            {
                RaisePropertyChanged(nameof(HasErrors));
            }
        }
    }

    /// <summary>
    ///     Sets the backing field for the property.
    /// </summary>
    /// <typeparam name="T">The type of the backing field and value.</typeparam>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void SetPropertyBackingField<T>(
        ref T backingField,
        T value,
        [CallerMemberName] string nameOfProperty = "")
        where T : class
    {
        T? previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChanged(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void SetPropertyBackingField(
        ref int backingField,
        in int value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChanged(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void SetPropertyBackingField(
        ref long backingField,
        in long value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChanged(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification = "We're not interested in precision here.")]
    public void SetPropertyBackingField(
        ref float backingField,
        in float value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChanged(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification = "We're not interested in precision here.")]
    public void SetPropertyBackingField(
        ref double backingField,
        in double value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChanged(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void SetPropertyBackingField(
        ref IntPtr backingField,
        in IntPtr value,
        string nameOfProperty)
    {
        IntPtr previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChanged(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property, with validation.
    /// </summary>
    /// <typeparam name="T">The type of the backing field and value.</typeparam>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void SetPropertyBackingFieldWithValidation<T>(
        ref T backingField,
        T value,
        [CallerMemberName] string nameOfProperty = "")
        where T : class
    {
        T? previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChangedWithValidation(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property, with validation.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void RaisePropertyChangedWithValidation(
        ref int backingField,
        in int value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChangedWithValidation(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property, with validation.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void SetPropertyBackingFieldWithValidation(
        ref long backingField,
        in long value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChangedWithValidation(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property, with validation.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification = "We're not interested in precision here.")]
    public void RaisePropertyChangedWithValidation(
        ref float backingField,
        in float value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChangedWithValidation(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property, with validation.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    [SuppressMessage(
        "ReSharper",
        "CompareOfFloatsByEqualityOperator",
        Justification = "We're not interested in precision here.")]
    public void RaisePropertyChangedWithValidation(
        ref double backingField,
        in double value,
        [CallerMemberName] string nameOfProperty = "")
    {
        var previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChangedWithValidation(nameOfProperty);
        }
    }

    /// <summary>
    ///     Sets the backing field for the property, with validation.
    /// </summary>
    /// <param name="backingField">The backing field.</param>
    /// <param name="value">The value.</param>
    /// <param name="nameOfProperty">The name of property.</param>
    public void RaisePropertyChangedWithValidation(
        ref IntPtr backingField,
        in IntPtr value,
        string nameOfProperty)
    {
        IntPtr previousValue = Interlocked.Exchange(
            ref backingField,
            value);

        if (previousValue != value)
        {
            RaisePropertyChangedWithValidation(nameOfProperty);
        }
    }

    /// <summary>
    ///     Raises the property changed event, followed by with validation.
    /// </summary>
    /// <param name="propertyName">Name of the property.</param>
    [SuppressMessage(
        "Design",
        "CA1030:Use events where appropriate",
        Justification = "This is not a violation, we're actively using an event.")]
    [SuppressMessage(
        "Performance",
        "HAA0603:Delegate allocation from a method group",
        Justification = "Unavoidable, unfortunately.")]
    protected void RaisePropertyChangedWithValidation(string propertyName)
    {
        RaisePropertyChanged(propertyName);

        _ = Work.OnThreadPoolAsync(Validate);
    }

    /// <summary>
    ///     Raises the errors changed event.
    /// </summary>
    /// <param name="propertyName">Name of the property for which the errors have been changed.</param>
    [SuppressMessage(
        "Design",
        "CA1030:Use events where appropriate",
        Justification = "This is not a violation, we're actively using an event.")]
    protected void RaiseErrorsChanged(string propertyName) =>
        Invoke(
            (
                invoker,
                internalPropertyName) => invoker.ErrorsChanged?.Invoke(
                invoker,
                new(internalPropertyName)), this,
            propertyName);

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync(
        Action action,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the invoked action.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to send to the action.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync<TState>(
        Action<TState> action,
        TState state,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(
                state,
                cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync(
        Action<CancellationToken> action,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the invoked action.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to send to the action.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync<TState>(
        Action<TState, CancellationToken> action,
        TState state,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(
                state,
                cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync(
        Func<Task> action,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the invoked action.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to send to the action.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync<TState>(
        Func<TState, Task> action,
        TState state,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(
                state,
                cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <param name="action">The action to invoke.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync(
        Func<CancellationToken, Task> action,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }

    /// <summary>
    ///     Asynchronously runs an operation while setting the busy scope, if one exists.
    /// </summary>
    /// <typeparam name="TState">The type of the state object to pass to the invoked action.</typeparam>
    /// <param name="action">The action to invoke.</param>
    /// <param name="state">The state object to send to the action.</param>
    /// <param name="description">The description to set on the busy scope. This parameter is optional.</param>
    /// <param name="cancellationToken">The cancellation token. This parameter is optional.</param>
    /// <returns>A task that allows monitoring of this operation.</returns>
    protected async Task DoWhileBusyAsync<TState>(
        Func<TState, CancellationToken, Task> action,
        TState state,
        string? description = null,
        CancellationToken cancellationToken = default)
    {
        _busyScope?.IncrementBusyScope(description);

        try
        {
            await action.OnThreadPoolAsync(
                state,
                cancellationToken);
        }
        finally
        {
            _busyScope?.DecrementBusyScope();
        }
    }
}