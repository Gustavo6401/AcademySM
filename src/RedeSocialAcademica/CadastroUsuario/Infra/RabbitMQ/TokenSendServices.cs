using CadastroUsuario.Domain.Models.ControllerModels;
using CadastroUsuario.Infra.RabbitMQ.Base;
using Newtonsoft.Json;

namespace CadastroUsuario.Infra.RabbitMQ
{
    public class TokenSendServices
    {
        public void SendTokensViaRabbitMQ(TokenReturn token)
        {
            string json = JsonConvert.SerializeObject(token);

            RabbitMQServiceBase.SendMessageToQueue(json, "Token");
        }
    }
}
