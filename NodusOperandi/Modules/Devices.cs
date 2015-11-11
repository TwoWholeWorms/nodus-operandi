namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Devices : NancyModule
    {

        public Devices(IDeviceModelFactory deviceModelFactory, IDeviceRepository deviceRepository)
        {
            this.RequiresAuthentication();

            Get["/devices"] = parameters =>
            {
                deviceRepository.GetAll();

                return View["Devices"];
            };
            
            Delete["/devices/{id}"] = parameters =>
            {
                deviceRepository.DeleteById((string)parameters.id);

                return Response.AsRedirect("~/devices");
            };

            Post["/devices/refresh"] = parameters =>
            {
                var model = deviceRepository.GetAll();

                deviceRepository.DeleteAll();

                var devices = deviceModelFactory.Discover();
                foreach (var device in devices) {
                    deviceRepository.Persist(device);
                }

                return Response.AsRedirect("~/devices");
            };

        }

    }

}

