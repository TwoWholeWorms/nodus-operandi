namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.Security;

    public class Settings : NancyModule
    {

        public Settings(ISettingModelFactory settingModelFactory, ISettingRepository settingRepository)
        {
            this.RequiresAuthentication();

            Get["/settings"] = parameters =>
            {
                settingRepository.GetAll();

                return View["settings"];
            };

        }

    }

}
