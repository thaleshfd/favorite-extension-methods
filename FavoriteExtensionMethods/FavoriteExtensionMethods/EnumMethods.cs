using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FavoriteExtensionMethods
{
    public static class EnumMethods
    {
        public static short ToShort(this Enum value)
        {
            return (short)value.GetHashCode();
        }

        public static int ToInt(this Enum value)
        {
            return value.GetHashCode();
        }

        public static string GetDescricao(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes == null || attributes.Length == 0)
            {
                return value.ToString();
            }

            return string.IsNullOrEmpty(attributes[0].Description) ? string.Empty : attributes[0].Description;
        }

        public static T GetEnumByDescription<T>(string description, bool matchExact)
        {
            T value = default(T);
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    var found = matchExact ? attribute.Description.Equals(description) : attribute.Description.Contains(description);
                    if (found)
                    {
                        value = (T)field.GetValue(null);
                    }
                }
                else
                {
                    var found = matchExact ? field.Name.Equals(description) : field.Name.Contains(description);
                    if (found)
                    {
                        value = (T)field.GetValue(null);
                    }
                }
            }

            return value;
        }

        public static SortedList<int, string> SortedList(Type enumerator)
        {
            var lista = new SortedList<int, string>();

            var values = Enum.GetValues(enumerator);

            foreach (Enum value in values)
            {
                int cod = value.GetHashCode();

                lista.Add(cod, GetDescricao(value));
            }

            return lista;
        }
    }
}
