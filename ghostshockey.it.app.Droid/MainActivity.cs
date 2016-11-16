using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;
using System.Collections.Generic;
using ghostshockey.it.model.Poco;

namespace ghostshockey.it.app.Droid
{
	[Activity (Label = "ghostshockey.it.app.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        Button button;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			button = FindViewById<Button> (Resource.Id.myButton);

            button.Click += Button_Click;
                
               
		}

        private async void Button_Click(object sender, EventArgs e)
        {

                CancellationTokenSource _cts0 = new CancellationTokenSource();
                await AppController.GetAllYears(
                    // Service call success                 
                    (data) =>
                    {
                        ODataList<Year> s = data as ODataList<Year>;
                        //AppController.Settings.LastLoginUsernameUsed = _email;
                        //AppController.Settings.AuthAccessToken = data.AuthAccessToken;
                        //AppController.Settings.AuthExpirationDate = data.AuthExpirationDate.GetValueOrDefault().ToLocalTime();

                        //((ChattyApplication)this.Activity.Application).RegisterToNotificationsHub();

                        //var f = new ChatFragment();
                        //f.Arguments = new Bundle();
                        //f.Arguments.PutString("Email", _email);
                        //this.FragmentManager.BeginTransaction()
                        //    .AddToBackStack("BeforeChatFragment")
                        //    .Replace(Resource.Id.ContentLayout, f, "ChatFragment")
                        //    .Commit();
                    },
                    // Service call error
                    (error) =>
                    {
                        var er = error;
                        //if (error.Contains("confirm"))
                        //    this.VerifyButton.Visibility = ViewStates.Visible;

                        //Toast.MakeText(this.Activity.Application, error, ToastLength.Long).Show();
                    },
                    // Service call finished 
                    (exception) =>
                    {
                        //    _isLogginUser = false;
                        var ex = exception;
                        //// Allow user to tap views
                        //((MainActivity)this.Activity).UnblockUI();
                    });


                button.Text = string.Format("{0} clicks!", count++);
            }
    }
}


