namespace NodusOperandi.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Default implementation of the <see cref="IDeviceModelFactory"/> interface.
    /// </summary>
    public class ClientModelFactory : IClientModelFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientModelFactory"/>
        /// </summary>
        public ClientModelFactory()
        {
            // …
        }

        #region IClientModelFactory implementation
        public IEnumerable<ClientModel> Discover()
        {
            throw new NotImplementedException();
        }
        #endregion
    
    }

}
