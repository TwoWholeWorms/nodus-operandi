namespace NodusOperandi.Modules
{

    using Data;
    using Nancy;
    using Nancy.ModelBinding;
    using Data.Models.View;
    using System.Linq;

    public class Api : NancyModule
    {

        public Api() : base("/api")
        {
        
            Get ["/dashboard"] = parameters => {
                
                var model = new DashboardView ();
                var dbContext = NodusOperandiDbContext.GetInstance ();

                //model.NumConnectedClients = dbContext.ClientSet.Count ();
                model.NumDevices = dbContext.DeviceSet.Count ();
                model.NumNetworks = dbContext.NetworkSet.Count ();

                return Negotiate.WithModel (model);

            };

            //Get ["/clients"] = parameters => Negotiate.WithModel (clientRepo.GetConnected (true));
            //Get ["/devices"] = parameters => Negotiate.WithModel (deviceRepo.GetConnected (true));

            Post ["/network"] = parameters => {

                var model = this.Bind<Data.Models.Network> ();

                var dbContext = NodusOperandiDbContext.GetInstance ();
                dbContext.NetworkSet.Attach (model);
                dbContext.SaveChanges ();

                return Negotiate.WithModel (model);

            };

            Get ["/network"] = parameters => {
                
                var model = new NetworkView ();

                var dbContext = NodusOperandiDbContext.GetInstance ();
                model.Networks = dbContext.NetworkSet.ToArray ();

                return Negotiate.WithModel (model);

            };

            Get ["/network/{id}"] = parameters => {

                long itemId = parameters.id;

                var dbContext = NodusOperandiDbContext.GetInstance ();
                var model = dbContext.NetworkSet.FirstOrDefault (x => x.Id == itemId);

                return Negotiate.WithModel (model);

            };
                                    
            Delete["/network/{id}"] = parameters => {

                long itemId = parameters.id;

                var dbContext = NodusOperandiDbContext.GetInstance ();
                var model = dbContext.NetworkSet.First(x => x.Id == itemId);

                dbContext.NetworkSet.Remove (model);
                dbContext.SaveChanges ();

                return Negotiate.WithModel (model);

            };

            Post ["/device"] = parameters => {

                var model = this.Bind<Data.Models.Device> ();

                var dbContext = NodusOperandiDbContext.GetInstance ();
                dbContext.DeviceSet.Attach (model);
                dbContext.SaveChanges ();

                return Negotiate.WithModel (model);

            };

            Get ["/device"] = parameters => {

                var model = new DeviceView ();

                var db = SqliteContext.GetInstance ();
                model.Devices = db.Device.GetAll ();

                return Negotiate.WithModel (model);

            };
            
            Get ["/device/{id}"] = parameters => {

                long itemId = parameters.id;

                var dbContext = NodusOperandiDbContext.GetInstance ();
                var model = dbContext.NetworkSet.FirstOrDefault (x => x.Id == itemId);

                return Negotiate.WithModel (model);

            };

            Delete ["/device/{id}"] = parameters => {

                long itemId = parameters.id;

                var dbContext = NodusOperandiDbContext.GetInstance ();
                var model = dbContext.DeviceSet.FirstOrDefault (x => x.Id == itemId);

                if (model != null) {
                    dbContext.DeviceSet.Remove (model);
                    dbContext.SaveChanges ();
                }

                return Negotiate.WithModel (model);

            };

        }

    }

}
