namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Statistics : NancyModule
    {

        public Statistics(IStatisticsModelFactory statisticsModelFactory, IStatisticsRepository statisticsRepository)
        {
            this.RequiresAuthentication();

            Get["/statistics"] = parameters =>
            {
                statisticsRepository.GetAll();

                return View["statistics"];
            };

        }

    }

}

