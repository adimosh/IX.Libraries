namespace IX.Math.Generators;

internal static class OperatorSequenceGenerator
{

    internal static List<Tuple<int, int, string>> GetOperatorsInOrderInExpression(
        string expression,
        IEnumerable<KeyValuePair<int, string[]>> operators)
    {
        var indexes = new List<Tuple<int, int, string>>();

        foreach (KeyValuePair<int, string[]> level in operators)
        {
            foreach (var op in level.Value)
            {
                var index = 0 - op.Length;

                restartFindProcess:
                index = expression.IndexOf(
                    op,
                    index + op.Length,
                    StringComparison.Ordinal);

                if (index != -1)
                {
                    indexes.Add(
                        new(
                            level.Key,
                            index,
                            op));

                    goto restartFindProcess;
                }
            }
        }

        return indexes;
    }
}