using System.ComponentModel;

namespace CadastroUsuario.Domain.Models.Enums
{
    public enum EducationalDegrees
    {
        [Description("Ensino Fundamental 1")]
        ElementarySchool = 1,

        [Description("Ensino Fundamental 2")]
        MiddleSchool = 2,

        [Description("Ensino Médio")]
        HighSchool = 3,

        // Equivalente ao Ensino Médio Técnico Brasileiro.
        [Description("Ensino Médio Técnico")]
        Technical = 4,

        [Description("Ensino Superior")]
        BachelorOrAssociateDegree = 5,

        [Description("Pós-Graduação")]
        GraduateDegree = 6,

        [Description("Mestrado")]
        Master = 7,

        [Description("Doutorado")]
        Doctorate = 8
    }
}
