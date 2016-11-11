namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Alerts : NancyModule
    {

        public Alerts()
        {
            this.RequiresAuthentication();

            Get["/alerts"] = parameters =>
            {
                return View["Alerts"];
            };

        }

    }

}
