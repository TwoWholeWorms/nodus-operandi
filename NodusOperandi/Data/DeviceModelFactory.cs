namespace NodusOperandi.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Default implementation of the <see cref="IDeviceModelFactory"/> interface.
    /// </summary>
    public class DeviceModelFactory : IDeviceModelFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceModelFactory"/>
        /// </summary>
        public DeviceModelFactory()
        {
            // …
        }

        #region IDeviceModelFactory implementation
        public IEnumerable<DeviceModel> Discover()
        {
            throw new NotImplementedException();
        }
        #endregion
    
    }

}
