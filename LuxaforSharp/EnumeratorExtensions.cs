using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxaforSharp
{
    public static class EnumeratorExtensions
    {
        public static Tuple<IEnumerable<T1>, IEnumerable<T1>, IEnumerable<T2>> Differences<T1, T2>(
            this IEnumerable<T1> source1, IEnumerable<T2> source2, Func<T1, T2, bool> matchingCondition)
        {
            var newItems = source2.Where(item2 => !source1.Any(item1 => matchingCondition(item1, item2)));
            var currentItems = source1.Where(item1 => source2.Any(item2 => matchingCondition(item1, item2)));
            var oldItems = source1.Except(currentItems);

            return Tuple.Create(oldItems, currentItems, newItems);
        }
    }
}
