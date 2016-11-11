namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Clients : NancyModule
    {

        public Clients()
        {
            this.RequiresAuthentication();

            Get["/clients"] = parameters =>
            {
                return View["Clients"];
            };
            
            Delete["/clients/{id}"] = parameters =>
            {
                //clientRepo.DeleteById((string)parameters.id);

                return Response.AsRedirect("~/clients");
            };

            Post["/clients/refresh"] = parameters =>
            {
                //var model = clientRepo.GetAll();

                //clientRepo.DeleteAll();

                //var clients = clientModelFactory.Discover();
                //foreach (var client in clients) {
                //    clientRepo.Persist(client);
                //}

                return Response.AsRedirect("~/clients");
            };

        }

    }

}

