using CadastroUsuario.Infra.EnumConverters.Base;
using System.Diagnostics.CodeAnalysis;

namespace CadastroUsuario.Infra.EnumConverters
{
    public class StatusConverter : EnumConverterBase
    {
        public StatusConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor | DynamicallyAccessedMemberTypes.PublicFields)] Type type) : base(type)
        {
        }
    }
}
