namespace NodusOperandi.Modules
{

    using Nancy;
    using Data;
    using Models;

    public class Api : NancyModule
    {

        public Api(IDeviceRepository deviceRepo, IClientRepository clientRepo)
            : base("/api")
        {
        
            Get["/dashboard"] = parameters =>
            {
                var model = new DashboardModel();

                model.NumConnectedClients = clientRepo.GetConnectedCount();
                model.NumConnectedDevices = deviceRepo.GetConnectedCount();

                return Negotiate.WithModel(model);
            };

            Get["/clients"] = parameters => Negotiate.WithModel(clientRepo.GetConnected(true));
            Get["/devices"] = parameters => Negotiate.WithModel(deviceRepo.GetConnected(true));

        }

    }

}
