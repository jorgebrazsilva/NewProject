using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scouter.ApplicationCore.Enumerators.Helper
{
    public class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            if (value == null)
                return null;

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
                return null;

            return fieldInfo.CustomAttributes.First().NamedArguments.First().TypedValue.Value.ToString();
        }

        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            return Enum.TryParse<T>(str, true, out var val) ? val : default;
        }
    }
}
