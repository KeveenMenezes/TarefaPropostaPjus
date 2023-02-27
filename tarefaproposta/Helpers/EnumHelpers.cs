using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using Microsoft.AspNetCore.Mvc.Rendering;

public static class EnumHelpers
{
    public static IEnumerable<SelectListItem> GetEnumSelectList<TEnum>(Expression<Func<TEnum, bool>> predicate = null) where TEnum : struct, Enum
    {
        var values = Enum.GetValues(typeof(TEnum))
            .Cast<TEnum>()
            .Where(v => predicate == null || predicate.Compile().Invoke(v))
            .ToList();

        var enumSelectList = values.Select(v => new SelectListItem
        {
            Text = v.GetDisplayName(),
            Value = v.ToString()
        });

        return enumSelectList;
    }

    private static string GetDisplayName<TEnum>(this TEnum enumValue) where TEnum : struct, Enum
    {
        var enumType = enumValue.GetType();
        var memberInfo = enumType.GetMember(enumValue.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
        var displayName = ((DisplayAttribute)attributes[0]).Name;

        return displayName;
    }
}
