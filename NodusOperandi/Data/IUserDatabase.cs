/**
 * Based on Nancy.Demo.Samples.IUserDatabase by Andreas Håkansson
 */

namespace NodusOperandi.Data
{

    using System;

    public interface IUserDatabase
    {
    
        Guid? ValidateUser(string password);

    }

}
