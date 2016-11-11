namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Devices : NancyModule
    {

        public Devices()
        {
            
            this.RequiresAuthentication();

            Get["/devices"] = parameters => {
                
                return View["Devices"];

            };

        }

    }

}

