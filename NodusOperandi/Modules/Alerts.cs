namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Alerts : NancyModule
    {

        public Alerts(IAlertModelFactory alertModelFactory, IAlertRepository alertRepository)
        {
            this.RequiresAuthentication();

            Get["/alerts"] = parameters =>
            {
                alertRepository.GetAll();

                return View["alerts"];
            };

        }

    }

}

