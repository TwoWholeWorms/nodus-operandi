using Mono.Data.Sqlite;
using NodusOperandi.Data.Models;
using System.Data.Entity;

// When I figure out how the hell I'm supposed ot get EF6 working
// with SQLite on both my Mac and my PC, I'll maybe switch this back over,
// but, for now, this class iz ded.
namespace NodusOperandi.Data
{
    
    public class NodusOperandiDbContext : DbContext
    {

        public static NodusOperandiDbContext instance;
        public static NodusOperandiDbContext GetInstance () {
            
            if (instance == null) {
                instance = new NodusOperandiDbContext();
            }

            return instance;

        }

        public DbSet<Network> NetworkSet { get; set; }
        public DbSet<Device> DeviceSet { get; set; }

    }

}
