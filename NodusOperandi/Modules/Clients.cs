namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Clients : NancyModule
    {

        public Clients(IClientModelFactory clientModelFactory, IClientRepository clientRepository)
        {
            this.RequiresAuthentication();

            Get["/clients"] = parameters =>
            {
                clientRepository.GetAll();

                return View["Clients"];
            };
            
            Delete["/clients/{id}"] = parameters =>
            {
                clientRepository.DeleteById((string)parameters.id);

                return Response.AsRedirect("~/clients");
            };

            Post["/clients/refresh"] = parameters =>
            {
                var model = clientRepository.GetAll();

                clientRepository.DeleteAll();

                var clients = clientModelFactory.Discover();
                foreach (var client in clients) {
                    clientRepository.Persist(client);
                }

                return Response.AsRedirect("~/clients");
            };

        }

    }

}

