﻿namespace ghostshockey.it.app.Droid
{
    using System;

    using Android.App;
    using Android.Content;
    using Android.Content.PM;    
    using Android.Views;
    using Android.Widget;
    using Android.OS;           
    using Android.Views.InputMethods;

    using AdMaiora.AppKit.UI;
    using AdMaiora.AppKit.UI.App;

    [Activity(
        Label = "Listy",
        Theme = "@style/AppTheme",        
        LaunchMode = LaunchMode.SingleTask,       
        WindowSoftInputMode = SoftInput.AdjustNothing,             
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AdMaiora.AppKit.UI.App.AppCompactActivity
    {
        #region Inner Classes
        #endregion

        #region Constants and Fields

        private bool _userRestored;
        private int _userId;

        #endregion

        #region Widgets
        
        [Widget]
        private FrameLayout LoadLayout;

        #endregion

        #region Constructors

        public MainActivity()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Activity Methods

        protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

            #region Desinger Stuff

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.ActivityMain, Resource.Id.ContentLayout, Resource.Id.Toolbar);

            this.SupportActionBar.SetDisplayShowHomeEnabled(true);
            this.SupportActionBar.SetDisplayHomeAsUpEnabled(true);            

            #endregion

            this.LoadLayout.Focusable = true;
            this.LoadLayout.FocusableInTouchMode = true;
            this.LoadLayout.Clickable = true;
            this.LoadLayout.Visibility = ViewStates.Gone;

            bool isResuming = this.SupportFragmentManager.FindFragmentById(Resource.Id.ContentLayout) != null;
            if (!isResuming)
            {
                //this.SupportFragmentManager.BeginTransaction()
                //    .Add(Resource.Id.ContentLayout, new LoginFragment(), "LoginFragment")
                //    .Commit();

                this.SupportFragmentManager.BeginTransaction()
                    .Add(Resource.Id.ContentLayout, new TournamentsFragment(), "TournamentsFragment")
                    .Commit();

                _userRestored = this.Arguments.GetBoolean("UserRestored", false);
                if (_userRestored)
                {
                    _userId = this.Arguments.GetInt("UserId");

                    //var f = new AgendaFragment();
                    //f.Arguments = new Bundle();
                    //f.Arguments.PutInt("UserId", _userId);
                    //this.SupportFragmentManager.BeginTransaction()
                    //    .AddToBackStack("BeforeAgendaFragment")
                    //    .Replace(Resource.Id.ContentLayout, f, "AgendaFragment")
                    //    .Commit();
                }
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Block the main UI, preventing user from tapping any view
        /// </summary>
        public void BlockUI()
        {
            if (this.LoadLayout != null)
                this.LoadLayout.Visibility = ViewStates.Visible;
        }

        /// <summary>
        /// Unblock the main UI, allowing user tapping views
        /// </summary>
        public void UnblockUI()
        {
            if (this.LoadLayout != null)
                this.LoadLayout.Visibility = ViewStates.Gone;
        }

        #endregion        

        #region Methods
        #endregion

        #region Event Handlers
        #endregion
    }
}


