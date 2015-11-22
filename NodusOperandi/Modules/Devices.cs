namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Devices : NancyModule
    {

        public Devices(IDeviceModelFactory deviceModelFactory, IDeviceRepository deviceRepo)
        {
            this.RequiresAuthentication();

            Get["/devices"] = parameters =>
            {
                deviceRepo.GetAll();

                return View["Devices"];
            };
            
            Delete["/devices/{id}"] = parameters =>
            {
                deviceRepo.DeleteById((string)parameters.id);

                return Response.AsRedirect("~/devices");
            };

            Post["/devices/refresh"] = parameters =>
            {
                var model = deviceRepo.GetAll();

                deviceRepo.DeleteAll();

                var devices = deviceModelFactory.Discover();
                foreach (var device in devices) {
                    deviceRepo.Persist(device);
                }

                return Response.AsRedirect("~/devices");
            };

        }

    }

}

