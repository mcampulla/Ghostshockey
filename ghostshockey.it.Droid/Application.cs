using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AdMaiora.AppKit;
using ghostshockey.it.core;

namespace ghostshockey.it.Droid
{

#if DEBUG
    [Application(Name = "ghostshockey.it.droid.GhostsApplication")]
#else
    [Application(Name = "ghostshockey.it.droid.GhostsApplicationn", Debuggable = false)]
#endif
    public class GhostsApplication : AppKitApplication
    {
        #region Constants and Fields

        #endregion

        #region Events


        #endregion

        #region Constructors

        public GhostsApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties
               
        #endregion

        #region Application Methods

        public override void OnCreate()
        {
            base.OnCreate();

            // Setup Application
            AppController.EnableSettings(new AdMaiora.AppKit.Data.UserSettingsPlatformAndroid());
            AppController.EnableUtilities(new AdMaiora.AppKit.Utils.ExecutorPlatformAndroid());
            AppController.EnableServices(new AdMaiora.AppKit.Services.ServiceClientPlatformAndroid());

            // Setup push notifications
            RegisterForRemoteNotifications(AppController.Globals.GoogleGcmSenderID);
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnLowMemory()
        {
            base.OnLowMemory();
        }   

        #endregion

        #region Azure Methods

      
        #endregion
    }
}