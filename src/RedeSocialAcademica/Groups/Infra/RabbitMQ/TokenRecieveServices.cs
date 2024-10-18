using Groups.Domain.Models.API;
using Groups.Infra.RabbitMQ.Base;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;

namespace Groups.Infra.RabbitMQ
{
    public class TokenRecieveServices
    {
        public TokenReturn RecieveAuthToken()
        {
            string json = RabbitMQServiceBase.RecieveMessageFromQueue("Token");

            TokenReturn token = JsonConvert.DeserializeObject<TokenReturn>(json)!;

            return token;
        }
    }
}
