/**
 * Based on Nancy.Demo.Samples.Modules.Login by Andreas Håkansson
 */

namespace NodusOperandi.Modules
{
    using System;
    using Nancy;
    using Nancy.Authentication.Forms;
    using Data;

    public class Login : NancyModule
    {
        public Login(IUserDatabase userDatabase)
        {

            Get["/login"] = x =>
            {
                return View["Login"];
            };

            Post["/login"] = parameters =>
            {
                var userGuid = userDatabase.ValidateUser((string)this.Request.Form.Password);

                if (userGuid == null)
                {
                    return Response.AsRedirect("/");
                }

                DateTime? expiry = null;

                return this.LoginAndRedirect(userGuid.Value, expiry);
            };

            Get["/logout"] = x =>
            {
                return this.LogoutAndRedirect("~/");
            };
        }
    }
}