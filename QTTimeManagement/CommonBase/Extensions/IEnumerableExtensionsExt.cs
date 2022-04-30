using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonBase.Extensions
{
    public static class IEnumerableExtensionsExt
    {
        public static T FirstOrNewInstance<T>(this IEnumerable<T> source, Predicate<T> predicate ) where T : new()
        {
            var result = new T();

            foreach ( var item in source)
            {
                if ( predicate( item ))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }
    }
}
