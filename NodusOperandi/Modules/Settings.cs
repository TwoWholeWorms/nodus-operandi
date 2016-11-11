namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Settings : NancyModule
    {

        public Settings()
        {
            this.RequiresAuthentication();

            Get["/settings"] = parameters =>
            {
                return View["Settings"];
            };

        }

    }

}
