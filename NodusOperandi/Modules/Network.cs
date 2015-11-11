namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Network : NancyModule
    {

        public Network(IDeviceModelFactory deviceModelFactory, IDeviceRepository deviceRepository)
        {
            this.RequiresAuthentication();

            Get["/network"] = parameters =>
            {
                deviceRepository.GetAll();

                return View["Network"];
            };
            
        }

    }

}

