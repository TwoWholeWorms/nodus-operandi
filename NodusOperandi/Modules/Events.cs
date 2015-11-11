namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Events : NancyModule
    {

        public Events(IDeviceModelFactory deviceModelFactory, IDeviceRepository deviceRepository)
        {
            this.RequiresAuthentication();

            Get["/events"] = parameters =>
            {
                deviceRepository.GetAll();

                return View["Events"];
            };

        }

    }

}

