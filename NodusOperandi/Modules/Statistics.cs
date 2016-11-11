namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Statistics : NancyModule
    {

        public Statistics()
        {
            this.RequiresAuthentication();

            Get["/statistics"] = parameters =>
            {
                return View["Statistics"];
            };

        }

    }

}

