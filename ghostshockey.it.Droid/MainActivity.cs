using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ghostshockey.it.core;
using System.Threading;
//using System.Threading;
//using ghostshockey.it.core;

namespace ghostshockey.it.Droid
{
	[Activity (Label = "ghostshockey.it.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
        EditText text;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
            Button button1 = FindViewById<Button>(Resource.Id.myButton1);
            text = FindViewById<EditText>(Resource.Id.editText1);

            button.Click += Button_Click;
            button1.Click += Button1_Click;
		}

        private async void Button1_Click(object sender, EventArgs e)
        {
            CancellationTokenSource _cts0 = new CancellationTokenSource();
            await AppController.AddYear(text.Text,
                // Service call success                 
                (data) =>
                {
                    var s = data;
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
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            // Create a new cancellation token for this request                
            CancellationTokenSource _cts0 = new CancellationTokenSource();
            await AppController.GetAllYears(
                // Service call success                 
                (data) =>
                {
                    var s = data;
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
        }
    }
}


