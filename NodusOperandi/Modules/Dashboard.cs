namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Dashboard : NancyModule
    {
        
        public Dashboard()
        {
            this.RequiresAuthentication();

            Get["/"] = parameters =>
            {
                return View["Dashboard"];
            };

        }

    }

}

