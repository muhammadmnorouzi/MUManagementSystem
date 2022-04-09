using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUManagementSystem.Common.Extensions
{
    public static class GuardExt
    {
        public static string ThrowIfNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str)
                ? throw new ArgumentNullException(nameof(str))
                : str;
        }

        public static T ThrowIfNull<T>(this T data) where T : class
        {
            return data is null
                ? throw new ArgumentNullException(nameof(data))
                : data;
        }
    }
}
