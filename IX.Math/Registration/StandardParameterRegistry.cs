using IX.Core.Collections;

using System.Globalization;
using IX.Math.Extensibility;

namespace IX.Math.Registration;

internal class StandardParameterRegistry : IParameterRegistry
{
    private readonly ConcurrentDictionary<string, ParameterContext> _parameterContexts;
    private readonly List<IStringFormatter> _stringFormatters;

    public StandardParameterRegistry(List<IStringFormatter> stringFormatters)
    {
        _parameterContexts = new();
        this._stringFormatters = stringFormatters;
    }

    public bool Populated => _parameterContexts.Count > 0;

    public ParameterContext AdvertiseParameter(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return _parameterContexts.GetOrAdd(name, (nameL1, formattersL1) => new(nameL1, formattersL1), _stringFormatters);
    }

    public ParameterContext CloneFrom(ParameterContext previousContext)
    {
        if (previousContext == null)
        {
            throw new ArgumentNullException(nameof(previousContext));
        }

        var name = previousContext.Name;
        if (_parameterContexts.TryGetValue(name, out ParameterContext existingValue))
        {
            if (existingValue.Equals(previousContext))
            {
                return existingValue;
            }

            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ParameterAlreadyAdvertised, name));
        }

        ParameterContext newContext = previousContext.DeepClone();

        _ = _parameterContexts.TryAdd(name, newContext);

        return newContext;
    }

    public ParameterContext[] Dump() => _parameterContexts.ToArray().Select(p => p.Value).OrderBy(p => p.Order).ToArray();

    public bool Exists(string name) => _parameterContexts.ContainsKey(name);
}