namespace NodusOperandi.Plugins.UbiquitiNetworkHardware.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Default implementation of the <see cref="IUbiquitiDeviceModelFactory"/> interface.
    /// </summary>
    public class UbiquitiDeviceModelFactory : IUbiquitiDeviceModelFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UbiquitiDeviceModelFactory"/>
        /// </summary>
        public UbiquitiDeviceModelFactory()
        {
            // …
        }

        #region IDeviceModelFactory implementation
        public IEnumerable<UbiquitiDeviceModel> Discover()
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}
