
namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Dashboard : NancyModule
    {
        
        public Dashboard(IClientRepository clientRepository, IDeviceRepository deviceRepository)
        {
            this.RequiresAuthentication();

            Get["/"] = parameters =>
            {
                clientRepository.GetAll();
                deviceRepository.GetAll();

                return View["dashboard"];
            };

        }

    }

}

