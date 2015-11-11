namespace NodusOperandi.Modules
{

    using Nancy;
    using Data;

    public class Api : NancyModule
    {

        public Api(IDeviceRepository deviceRepository, IClientRepository clientRepository)
            : base("/api")
        {
        
            Get["/clients"] = parameters => Negotiate.WithModel(clientRepository.GetAll());
            Get["/devices"] = parameters => Negotiate.WithModel(deviceRepository.GetAll());

        }

    }

}
