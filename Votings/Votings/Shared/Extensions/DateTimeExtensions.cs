using System;
using System.Collections.Generic;
using System.Text;

namespace Votings.Shared.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetBlazorNow() => DateTime.Now.AddHours(2);
    }
}
