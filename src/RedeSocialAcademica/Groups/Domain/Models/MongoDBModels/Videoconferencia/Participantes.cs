namespace Groups.Domain.Models.MongoDBModels.Videoconferencia
{
    public class Participantes
    {
        public Guid UserId { get; set; }
        public DateTime JuntouSe { get; set; }
        public DateTime? Saiu { get; set; }
    }
}
