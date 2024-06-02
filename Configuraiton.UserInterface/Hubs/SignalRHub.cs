using Configuration.Business.Abstract;
using Configuration.Data.Entities;
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
            List<ConfigurationEntity> configurationList = _configurationEntity.TGetAll().ToList();
            await Clients.All.SendAsync("ReceiveConfigurationList", configurationList);

        }
    }
}
