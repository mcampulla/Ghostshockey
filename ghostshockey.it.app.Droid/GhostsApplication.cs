﻿namespace ghostshockey.it.app.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.Runtime;
    using Android.Widget;
    using Android.OS;
    using Android.Gms.Common;
    using Android.Gms.Gcm.Iid;
    using Android.Gms.Gcm;
    using Android.Support.V4.App;
    
    using AdMaiora.AppKit;

#if DEBUG
    [Application(Name = "ghostshockey.it.app.droid.GhostsApplication")]
#else
    [Application(Name = "ghostshockey.it.app.droid.GhostsApplication", Debuggable = false)]
#endif
    
    #pragma warning disable CS4014
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
            //AppController.EnableSettings(new AdMaiora.AppKit.Data.UserSettingsPlatformAndroid());
            AppController.EnableUtilities(new AdMaiora.AppKit.Utils.ExecutorPlatformAndroid());
            //AppController.EnableFileSystem(new AdMaiora.AppKit.IO.FileSystemPlatformAndroid());
            //AppController.EnableDataStorage(new AdMaiora.AppKit.Data.DataStoragePlatformAndroid());
            //AppController.EnableServices(new AdMaiora.AppKit.Services.ServiceClientPlatformAndroid());                                    
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
    }
}
