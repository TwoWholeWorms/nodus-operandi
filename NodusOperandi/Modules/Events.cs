namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Events : NancyModule
    {

        public Events()
        {
            this.RequiresAuthentication();

            Get["/events"] = parameters =>
            {
                return View["Events"];
            };

        }

    }

}

