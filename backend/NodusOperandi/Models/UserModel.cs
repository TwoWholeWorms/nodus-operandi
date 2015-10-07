namespace NodusOperandi.Models
{
    
    using System.Collections.Generic;
    using Nancy.Security;

    public class UserModel : IUserIdentity
    {
        
        public string UserName { get; set; }

        public IEnumerable<string> Claims { get; set; }

    }

}
