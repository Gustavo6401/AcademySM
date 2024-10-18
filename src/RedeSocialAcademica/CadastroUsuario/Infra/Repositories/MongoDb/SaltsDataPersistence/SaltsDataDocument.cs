using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario.Infra.Repositories.MongoDb.SaltsDataPersistence
{
    public class SaltsDataDocument
    {
        public ObjectId Id { get; set; }
        public string? Salt { get; set; }
        public string? Email { get; set; }
    }
}
