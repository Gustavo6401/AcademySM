using CadastroUsuario.Domain.Models.Enums;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace CadastroUsuario.Infra.EnumConverters.Base
{
    public class EnumConverterBase : EnumConverter
    {
        public EnumConverterBase([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type type) : base(type)
        {
        }

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                FieldInfo field = value!.GetType().GetField(value.ToString()!)!;
                DescriptionAttribute description = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute))!;
                return description != null ? description.Description : value.ToString();
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string stringValue)
            {
                foreach (FieldInfo field in EnumType.GetFields())
                {
                    DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute))!;

                    if (attribute != null && attribute.Description == stringValue)
                    {
                        return (EducationalDegrees)field.GetValue(null)!;
                    }

                    if (field.Name == stringValue)
                    {
                        return (EducationalDegrees)field.GetValue(null)!;
                    }
                }
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}
