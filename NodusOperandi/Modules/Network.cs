namespace NodusOperandi.Modules
{

    using Nancy;
    using Nancy.Security;

    public class Network : NancyModule
    {

        public Network()
        {
            
            this.RequiresAuthentication();

            Get ["/network"] = parameters => {
             
                return View ["Network"];

            };

        }

    }

}

