using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mb.Infrastructure.Common;

public class ModelValueComparer<T>
{
    public readonly ValueComparer<List<T>> _comparer;

    public ModelValueComparer()
    {
        _comparer = new ValueComparer<List<T>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a.ToString(), v.GetHashCode())),
            c => c.ToList());
    }

    public ValueComparer<List<T>> StringGuidComparer()
    {
        return new ValueComparer<List<T>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a.ToString(), v.GetHashCode())),
            c => c.ToList());
    }
}