using AdMaiora.AppKit.Data;
using AdMaiora.AppKit.Services;
using AdMaiora.AppKit.Utils;
using ghostshockey.it.model;
using ghostshockey.it.model.Poco;
using Ghostshockey;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ghostshockey.it.core
{
    public class AppSettings
    {
        #region Constants and Fields

        private UserSettings _settings;

        #endregion

        #region Constructors

        public AppSettings(UserSettings settings)
        {
            _settings = settings;
        }

        #endregion

        #region Properties

        public string LastLoginUsernameUsed
        {
            get
            {
                return _settings.GetStringValue("LastLoginUsernameUsed");
            }
            set
            {
                _settings.SetStringValue("LastLoginUsernameUsed", value);
            }
        }

        public string AuthAccessToken
        {
            get
            {
                return _settings.GetStringValue("AuthAccesstoken");
            }
            set
            {
                _settings.SetStringValue("AuthAccesstoken", value);
            }
        }

        public DateTime? AuthExpirationDate
        {
            get
            {
                return _settings.GetDateTimeValue("AuthExpirationDate");
            }
            set
            {
                _settings.SetDateTimeValue("AuthExpirationDate", value);
            }
        }

        public int LastMessageId
        {
            get
            {
                return _settings.GetIntValue("LastMessageId");
            }
            set
            {
                _settings.SetIntValue("LastMessageId", value);
            }
        }

        #endregion
    }

    public static class AppController
    {
        #region Inner Classes

        class TokenExpiredException : Exception
        {
            public TokenExpiredException()
                : base("Access Token is expired.")
            {

            }
        }

        #endregion

        #region Constants and Fields
        public static class Globals
        {
            // Splash screen timeout (milliseconds)
            public const int SplashScreenTimeout = 2000;

            // Base URL for service client endpoints
            public const string ServicesBaseUrl = "http://localhost:59736/";
            // Default service client timeout in seconds
            public const int ServicesDefaultRequestTimeout = 60;

            // Google GCM Sender ID (get this from https://console.firebase.google.com)
            public const string GoogleGcmSenderID = "294853768960";

            public const string AzureNHubName = "Chatty";
            public const string AzureNHubConnectionString = "Endpoint=sb://admaiora.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=zLp5bXQbzoPvQ3959bwy01ufXUp95iEY0/U6TE+oCzM=";
        }

        public static class Colors
        {
            public const string PictonBlue = "30BCED";
            public const string Jet = "303036";
            public const string RomanSilver = "858596";
            public const string Snow = "FFFAFF";
            public const string OgreOdor = "FC5130";
            public const string Black = "000000";
            public const string White = "FFFFFF";
        }

        private static AppSettings _settings;

        private static Executor _utility;
        private static ServiceClient _services;

        #endregion

        #region Properties

        public static AppSettings Settings
        {
            get
            {
                return _settings;
            }
        }

        public static Executor Utility
        {
            get
            {
                return _utility;
            }
        }

        public static ServiceClient Services
        {
            get
            {
                return _services;
            }

        }

        public static bool IsUserRestorable
        {
            get
            {
                if (String.IsNullOrWhiteSpace(AppController.Settings.AuthAccessToken))
                    return false;

                if (!(DateTime.Now < AppController.Settings.AuthExpirationDate.GetValueOrDefault()))
                    return false;

                return true;
            }
        }

        #endregion

        #region Initialization Methods

        public static void EnableSettings(IUserSettingsPlatform userSettingsPlatform)
        {
            _settings = new AppSettings(new UserSettings(userSettingsPlatform));
        }

        public static void EnableUtilities(IExecutorPlatform utiltiyPlatform)
        {
            _utility = new Executor(utiltiyPlatform);
        }

        public static void EnableServices(IServiceClientPlatform servicePlatform)
        {
            _services = new ServiceClient(servicePlatform, AppController.Globals.ServicesBaseUrl);
            _services.RequestTimeout = AppController.Globals.ServicesDefaultRequestTimeout;
        }

        #endregion

        #region Users Methods    

        public static async Task RegisterUser(CancellationTokenSource cts,
            string email,
            string password,
            Action<User> success,
            Action<string> error,
            Action finished)
        {
            try
            {
                var response = await _services.Request<Dto.Response<User>>(
                    // Resource to call
                    "users/register",
                    // HTTP method
                    Method.POST,
                    // Cancellation token
                    cts.Token,
                    // Content Type,
                    RequestContentType.ApplicationJson,
                    // Payload
                    new
                    {
                        email = email,
                        password = password
                    });

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (success != null)
                        success(response.Data.Content);
                }
                else
                {
                    if (error != null)
                        error(response.Data.ExceptionMessage ?? response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                if (error != null)
                    error("Internal error :(");
            }
            finally
            {
                if (finished != null)
                    finished();
            }
        }

        public static async Task LoginUser(CancellationTokenSource cts,
            string email,
            string password,
            Action<User> success,
            Action<string> error,
            Action finished)
        {
            try
            {
                var response = await _services.Request<Dto.Response<User>>(
                    // Resource to call
                    "users/login",
                    // HTTP method
                    Method.POST,
                    // Cancellation token
                    cts.Token,
                    // Content Type,
                    RequestContentType.ApplicationJson,
                    // Payload
                    new
                    {
                        email = email,
                        password = password
                    });

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string accessToken = response.Data.Content.AuthAccessToken;
                    DateTime accessExpirationDate = response.Data.Content.AuthExpirationDate.GetValueOrDefault().ToLocalTime();

                    // Refresh access token for further service calls
                    _services.RefreshAccessToken(accessToken, accessExpirationDate);

                    if (success != null)
                        success(response.Data.Content);
                }
                else
                {
                    if (error != null)
                        error(response.Data.ExceptionMessage ?? response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                if (error != null)
                    error("Internal error :(");
            }
            finally
            {
                if (finished != null)
                    finished();
            }
        }

        public static async Task VerifyUser(CancellationTokenSource cts,
            string email,
            string password,
            Action success,
            Action<string> error,
            Action finished)
        {
            try
            {
                var response = await _services.Request<Dto.Response>(
                    // Resource to call
                    "users/verify",
                    // HTTP method
                    Method.POST,
                    // Cancellation token
                    cts.Token,
                    // Content Type,
                    RequestContentType.ApplicationJson,
                    // Payload
                    new
                    {
                        email = email,
                        password = password
                    });

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    if (success != null)
                        success();
                }
                else
                {
                    if (error != null)
                        error(response.Data.ExceptionMessage ?? response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                if (error != null)
                    error("Internal error :(");
            }
            finally
            {
                if (finished != null)
                    finished();
            }
        }

        public static async Task RestoreUser(CancellationTokenSource cts,
            string accessToken,
            Action<User> success,
            Action<string> error,
            Action finished)
        {
            try
            {
                var response = await _services.Request<Dto.Response<User>>(
                    // Resource to call
                    "users/restore",
                    // HTTP method
                    Method.GET,
                    // Cancellation token
                    cts.Token,
                    // Content Type,
                    RequestContentType.ApplicationJson,
                    // Payload
                    new
                    {
                        accessToken = accessToken
                    });

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    DateTime accessExpirationDate = response.Data.Content.AuthExpirationDate.GetValueOrDefault().ToLocalTime();

                    // Refresh access token for further service calls
                    _services.RefreshAccessToken(accessToken, accessExpirationDate);

                    if (success != null)
                        success(response.Data.Content);
                }
                else
                {
                    if (error != null)
                        error(response.Data.ExceptionMessage ?? response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                if (error != null)
                    error("Internal error :(");
            }
            finally
            {
                if (finished != null)
                    finished();
            }
        }

        #endregion

        #region Messages Methods

        //public static async Task SendMessage(CancellationTokenSource cts,
        //    string sender,
        //    string content,
        //    Action<Poco.Message> success,
        //    Action<string> error,
        //    Action finished)
        //{
        //    // Create the rest client
        //    var client = _services.GetRestClient();
        //    // Create the rest request
        //    var request = _services.GetRestRequest(
        //        // Resource to call
        //        "messages/send",
        //        // HTTP method
        //        Method.POST,
        //        // Content Type,
        //        RequestContentType.ApplicationJson,
        //        // Parameters as anonymous object. Will be jsonized
        //        new
        //        {
        //            sender = sender,
        //            content = content
        //        });

        //    try
        //    {
        //        var response = await _services.Request<Dto.Response<Poco.Message>>(
        //            // Resource to call
        //            "messages/send",
        //            // HTTP method
        //            Method.POST,
        //            // Cancellation token
        //            cts.Token,
        //            // Content Type,
        //            RequestContentType.ApplicationJson,
        //            // Payload
        //            new
        //            {
        //                sender = sender,
        //                content = content
        //            });

        //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //        {
        //            if (success != null)
        //                success(response.Data.Content);
        //        }
        //        else
        //        {
        //            if (error != null)
        //                error(response.Data.ExceptionMessage ?? response.StatusDescription);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.ToString());

        //        if (error != null)
        //            error("Internal error :(");
        //    }
        //    finally
        //    {
        //        if (finished != null)
        //            finished();
        //    }
        //}

        public static async Task GetAllYears(Action<object> success, Action<string> fail, Action<Exception> exception = null)
        {
            try
            {
                var context = new GhostshockeyContainer(new Uri("http://api-ghosts.azurewebsites.net/odata"));

                var years = await context.Years.ExecuteAsync();

                ghostshockey.it.api.Models.Year newyear = new ghostshockey.it.api.Models.Year();
                newyear.Year1 = "test";
                newyear.DateStart = DateTime.Now;
                newyear.DateEnd = DateTime.Now.AddDays(30);

                context.AddToYears(newyear);
                var r = await context.SaveChangesAsync();                 

                RestClient svc = new RestClient("http://api-ghosts.azurewebsites.net/");
                svc.IgnoreResponseStatusCode = true;
                RestRequest req = new RestRequest("odata/Years", Method.GET);
                var res = await svc.Execute<List<Year>>(req);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Poco.User user = res.Data.Content;
                    success?.Invoke(res);
                }
                else
                {
                    fail?.Invoke(res.StatusDescription);
                }

            }
            catch (Exception ex)
            {
                exception?.Invoke(ex);
            }
        }


        public static async Task GetYears(CancellationTokenSource cts,
            string me,
            Action<IEnumerable<Year>> success,
            Action<string> error,
            Action finished)
        {
            try
            {

                var response = await _services.Request<Dto.Response<IEnumerable<Year>>>(
                    // Resource to call
                    "odata/Years",
                    // HTTP method
                    Method.GET,
                    // Cancellation token
                    cts.Token,
                    // Content Type,
                    RequestContentType.ApplicationJson,
                    // Payload
                    new
                    {

                    });

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (success != null)
                        success(response.Data.Content);
                }
                else
                {
                    if (error != null)
                        error(response.Data.ExceptionMessage ?? response.StatusDescription);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());

                if (error != null)
                    error("Internal error :(");
            }
            finally
            {
                if (finished != null)
                    finished();
            }
        }

        #endregion

        #region Helper Methods

        #endregion
    }
}
