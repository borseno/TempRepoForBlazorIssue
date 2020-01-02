using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Shared.Extensions
{
    public static class ObjectExtension
    {
        public static T[] ObjectToArray<T>(this T obj) => new[] { obj };
    }
}
