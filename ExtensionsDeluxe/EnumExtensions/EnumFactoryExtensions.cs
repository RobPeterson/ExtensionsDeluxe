using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumExtensions
{
    public static class EnumFactoryExtensions
    {
        /// <summary>
        /// Lookup the Description of an Enum value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum value)
        {
            if (value == null)
                return null;
            var selectedValue = value.GetType().GetField(value.ToString());
            string description = null;

            if (selectedValue != null)
            {
                DescriptionAttribute[] da = (DescriptionAttribute[])(selectedValue.GetCustomAttributes(typeof(DescriptionAttribute), false));
                description = (da.Length > 0) ? da[0].Description : value.ToString();
            }

            return description != null ? description : value.ToString();
        }

    }
}
