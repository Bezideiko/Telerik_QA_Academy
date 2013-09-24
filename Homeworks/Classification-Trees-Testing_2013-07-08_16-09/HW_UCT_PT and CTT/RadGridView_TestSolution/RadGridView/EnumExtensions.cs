using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RadGridView
{
    public static class EnumHelper
    {
            /// <summary>
            /// Gets the values.
            /// </summary>
            /// <typeparam name="T">The type of the enum.</typeparam>
            /// <returns>All enum value.</returns>
            internal static IEnumerable<T> GetValues<T>() where T : struct
            {
                return EnumHelper.GetValues(typeof(T)).Cast<T>();
            }

            /// <summary>
            /// Gets the values.
            /// </summary>
            /// <param name="enumType">Type of the enum.</param>
            /// <returns>All enum value.</returns>
            /// <exception cref="ArgumentException">Given <c>enumType</c> is not <see cref="Enum"/>.</exception>
            /// <exception cref="ArgumentNullException"><c>enumType</c> is null.</exception>
            public static IEnumerable GetValues(Type enumType)
            {
#if WPF
			return Enum.GetValues(enumType);
#endif

#if SILVERLIGHT
                if (enumType == null)
                {
                    throw new ArgumentNullException("enumType");
                }

                if (!enumType.IsEnum)
                {
                    throw new ArgumentException("Argument must be Enum", "enumType");
                }

                var fields = from field in enumType.GetFields()
                             where field.IsLiteral
                             select field;

                foreach (System.Reflection.FieldInfo field in fields)
                {
                    yield return field.GetValue(enumType);
                }
#endif
            }

            internal static string[] GetNames(Type enumType)
            {
                if (enumType == null)
                {
                    throw new ArgumentNullException("enumType");
                }
                if (!enumType.IsEnum)
                {
                    throw new ArgumentException("Argument must be Enum", "enumType");
                }

                var fields = from field in enumType.GetFields()
                             where field.IsLiteral
                             select field.Name;
                return fields.ToArray<string>();
            }    
    }
}
