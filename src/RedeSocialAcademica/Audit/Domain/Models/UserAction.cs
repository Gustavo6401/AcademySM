namespace Audit.Domain.Models
{
    public class UserAction
    {
        public string? Id { get; set; }
        public string? APIName { get; set; }
        public string? Route { get; set; }
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? IPv4 { get; set; }
        public string? IPv6 { get; set; }
        /// <summary>
        /// POST
        /// PUT
        /// GET
        /// DELETE
        /// OPTIONS
        /// </summary>
        public string? Action { get; set; }
        public string? Token { get; set; }
    }
}
