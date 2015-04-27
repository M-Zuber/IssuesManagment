using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueManagment.Specs.Helpers
{
    public static class EnumExtensions
    {
        public static T Parse<T>(string value, bool ignoreCase = false)
        {
            Type type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException("The generic argument must be an enum.");
            }

            return (T)Enum.Parse(type, value, ignoreCase);
        }
    }
}
