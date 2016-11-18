using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.OData;
using Microsoft.Azure.Mobile.Server;
using ghostshockey.it.api.Models;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server.Config;
using System.Web.Http.Results;
using System.Web.OData.Routing;
using System.Net;
using System.Web.Security;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Azure.Mobile.Server.Login;

namespace ghostshockey.it.api.Controllers
{
    public class UsersController : ODataController
    {
        GhostsDbContext _ctx = new GhostsDbContext();

        // Authorization token duration (in days)
        public const int AUTH_TOKEN_MAX_DURATION = 1;

        // Numbers of logged user limit 
        public const int USERS_MAX_LOGGED = 50;
        // Interval to consider an user active (in minutes)
        public const int USERS_MAX_INACTIVE_TIME = 30;

        public const string JWT_SECURITY_TOKEN_AUDIENCE = "https://api-ghosts.azurewebsites.net/";
        public const string JWT_SECURITY_TOKEN_ISSUER = "https://api-ghosts.azurewebsites.net/";

        static List<User> users = new List<User>();

        public UsersController()
        {
            users.Add(new User() { UserId = 1, Email = "user1@email.com" });
            users.Add(new User() { UserId = 2, Email = "user2@email.com" });
            users.Add(new User() { UserId = 3, Email = "user3@email.com" });
            users.Add(new User() { UserId = 4, Email = "user4@email.com" });
            users.Add(new User() { UserId = 5, Email = "user5@email.com" });
        }

        //[EnableQuery]
        //public IHttpActionResult GetUsers()
        //{
        //    return Ok(users);
        //}

        //public IHttpActionResult GetUser([FromODataUri]int key)
        //{
        //    var model = users.FirstOrDefault(p => p.UserId == key);

        //    if (model != null)
        //        return Ok(model);
        //    else
        //        return NotFound();
        //}

        [HttpPost]
        [ODataRoute("Users/Ghostshockey.Actions.Login")]
        public IHttpActionResult LoginUser(string username, string password)
        {
            //return Ok(new User());
            //object pusername = "";
            //string username = "";
            //if (!parameters.TryGetValue("username", out pusername))
            //{
            //    return NotFound();
            //}
            //username = pusername as string;

            //object ppassword = "";
            //string password = "";
            //if (!parameters.TryGetValue("username", out ppassword))
            //{
            //    return NotFound();
            //}
            //password = ppassword as string;

            ////if (username != "marco" || password != "password") // user-defined function, checks against a database
            ////{
            ////    JwtSecurityToken token = AppServiceLoginHandler.CreateToken(new Claim[] { new Claim(JwtRegisteredClaimNames.Sub, assertion["username"]) },
            ////        mySigningKey,
            ////        myAppURL,
            ////        myAppURL,
            ////        TimeSpan.FromHours(24));
            ////    return Ok(new LoginResult()
            ////    {
            ////        AuthenticationToken = token.RawData,
            ////        User = new LoginResultUser() { UserId = userName.ToString() }
            ////    });
            ////}
            ////else // user assertion was not valid
            ////{
            ////    return this.Request.CreateUnauthorizedResponse();
            ////}


            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("The email is not valid!");

            if (string.IsNullOrWhiteSpace(password))
                return BadRequest("The password is not valid!");

            try
            {
                if (username != "marco" || password != "password")
                    return Unauthorized();

                //if (!user.IsConfirmed)
                //    return InternalServerError(new InvalidOperationException("You must confirm your email first!"));

                //if (!String.IsNullOrWhiteSpace(user.FacebookId) && user.Password == null)
                //    return InternalServerError(new InvalidOperationException("You must login via Facebook!"));

                //string p1 = FormsAuthentication.HashPasswordForStoringInConfigFile(user.Password, "MD5");
                //string p2 = FormsAuthentication.HashPasswordForStoringInConfigFile(credentials.Password, "MD5");
                //if (p1 != p2)
                //    return Unauthorized();

                var token = GetAuthenticationTokenForUser(username);
                //user.LoginDate = DateTime.Now.ToUniversalTime();
                //user.LastActiveDate = user.LoginDate;
                //user.AuthAccessToken = token.RawData;
                //user.AuthExpirationDate = token.ValidTo;

                User u = new User()
                {
                    UserId = 1,
                    Email = username,
                    LoginDate = DateTime.Now,
                    AuthAccessToken = token.RawData,
                    AuthExpirationDate = token.ValidTo
                };

                return Ok(u);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private JwtSecurityToken GetAuthenticationTokenForUser(string email)
        {
            var claims = new Claim[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, email.Split('@')[0]),
                        new Claim(JwtRegisteredClaimNames.Email, email),
            };

            // The WEBSITE_AUTH_SIGNING_KEY variable will be only available when
            // you enable App Service Authentication in your App Service from the Azure back end
            //https://azure.microsoft.com/en-us/documentation/articles/app-service-mobile-dotnet-backend-how-to-use-server-sdk/#how-to-work-with-authentication

            var signingKey = "cXdlcnF3dmpnYXNkbGl2dWJhc2TDoGZu"; //Environment.GetEnvironmentVariable("WEBSITE_AUTH_SIGNING_KEY"); //  
            var audience = UsersController.JWT_SECURITY_TOKEN_AUDIENCE;
            var issuer = UsersController.JWT_SECURITY_TOKEN_ISSUER;

            var token = AppServiceLoginHandler.CreateToken(
                claims,
                signingKey,
                audience,
                issuer,
                TimeSpan.FromDays(UsersController.AUTH_TOKEN_MAX_DURATION)
                );

            return token;
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }

    }
}
