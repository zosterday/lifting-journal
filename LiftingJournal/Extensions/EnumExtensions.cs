using System;
using System.ComponentModel.DataAnnotations;

namespace LiftingJournal.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field?.GetCustomAttributes(false);

            var displayName = attributes?.OfType<DisplayAttribute>().FirstOrDefault()?.GetName();

            return displayName ?? value.ToString();
        }
    }
}

