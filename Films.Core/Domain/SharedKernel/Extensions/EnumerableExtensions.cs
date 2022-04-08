using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Films.Core.Domain.SharedKernel.Extensions;

public static class EnumerableExtensions
{
    public static int GetHashCode<T>(this IEnumerable<T> enumerable)
    {
        const int seed = 487;
        const int modifier = 31;

        return enumerable.Aggregate(seed, (current, item) =>
            (current * modifier) + item.GetHashCode());
    }
}