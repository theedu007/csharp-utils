using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Edu.Utils
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumValue)
        {
            if (enumValue == null)
            {
                return string.Empty;
            }
            return enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()
                .Description;
        }
    }
}
