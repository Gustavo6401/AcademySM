namespace Groups.Domain.Models.MongoDBModels.Videoconferencia
{
    public class Videoconferenia
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public List<Participantes>? Participantes { get; set; }
        public string? Responsavel { get; set; }
    }
}
