using Configuration.Business.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace Configuration.UserInterface.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IConfigurationService _configurationEntity;

        public SignalRHub(IConfigurationService configurationEntity)
        {
            _configurationEntity = configurationEntity;
        }

        public async Task SendConfigurationList()
        {
            var configurationList = _configurationEntity.TGetAll();
            await Clients.All.SendAsync("ReceiveConfigurationList", configurationList);

        }
    }
}
