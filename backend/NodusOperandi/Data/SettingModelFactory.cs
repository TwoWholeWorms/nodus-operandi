namespace NodusOperandi.Data
{

    using System;
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Default implementation of the <see cref="ISettingModelFactory"/> interface.
    /// </summary>
    public class SettingModelFactory : ISettingModelFactory
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingModelFactory"/>
        /// </summary>
        public SettingModelFactory()
        {
            // …
        }

        #region ISettingModelFactory implementation
        public IEnumerable<SettingModel> Discover()
        {
            throw new NotImplementedException();
        }
        #endregion
    
    }

}
