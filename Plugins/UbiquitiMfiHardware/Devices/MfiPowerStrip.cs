using System;
using NodusOperandi.Data;
using NodusOperandi.Data.Models;

namespace NodusOperandi.Plugins.UbiquitiMfiHardware.Devices
{
    
    public class MfiPowerStrip
    {
        
        public MfiPowerStrip ()
        {
            
        }

        public static void EU3Outlet (Device device, string action)
        {
            
        }

        public static void EUOutlet (Device device, string action)
        {

            var db = SqliteContext.GetInstance ();

            var parentDevice = db.Device.GetById (device.ParentId);
            if (parentDevice == null) {
                throw new Exception ("Parent device `" + device.ParentId + "` of device `" + device.Id + "` does not exist");
            }

        }

    }

}
