using System.ComponentModel;

namespace CadastroUsuario.Domain.Models.Enums
{
    public enum Status
    {
        [Description("Concluído")]
        Concluded = 1,

        [Description("Trancado")]
        OnHold = 2,

        [Description("Cursando")]
        InProgress = 3
    }
}
