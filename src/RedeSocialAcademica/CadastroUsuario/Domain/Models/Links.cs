using System.Text.Json.Serialization;

namespace CadastroUsuario.Domain.Models
{
    public class Links
    {
        public int Id { get; set; }
        public string? ProfileName { get; set; }
        public string? Origin { get; set; }
        public string? Link { get; set; }

        [JsonIgnore]
        public ApplicationUser? ApplicationUser { get; set; }
        public Guid? UserId { get; set; }
    }
}
