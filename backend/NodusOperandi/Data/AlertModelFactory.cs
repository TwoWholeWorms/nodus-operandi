namespace NodusOperandi.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Default implementation of the <see cref="IAlertModelFactory"/> interface.
    /// </summary>
    public class AlertModelFactory : IAlertModelFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AlertModelFactory"/>
        /// </summary>
        public AlertModelFactory()
        {
            // …
        }

        #region IAlertModelFactory implementation
        public IEnumerable<AlertModel> Discover()
        {
            throw new NotImplementedException();
        }
        #endregion
    
    }

}
