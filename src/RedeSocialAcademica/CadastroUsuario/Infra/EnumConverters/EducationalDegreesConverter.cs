using CadastroUsuario.Domain.Models.Enums;
using CadastroUsuario.Infra.EnumConverters.Base;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;

namespace CadastroUsuario.Infra.EnumConverters
{
    public class EducationalDegreesConverter : EnumConverterBase
    {
        public EducationalDegreesConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type type) : base(type)
        {
        }
    }
}
