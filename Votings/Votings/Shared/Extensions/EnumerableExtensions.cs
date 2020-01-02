using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Votings.Shared.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool In<T>(T elem, IEnumerable<T> source)
            => source.Contains(elem);
    }
}
