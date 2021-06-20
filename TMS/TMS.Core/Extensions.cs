using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core
{
    public static class Extensions
    {
        public static bool ContainsIgnoreCase(this string src, string comp)
        {
            comp = comp.Trim();
            return src.IndexOf(comp, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
