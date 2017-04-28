using ghostshockey.it.model.Poco;
using System;
using System.Threading;
using UIKit;

namespace ghostshockey.it.app.iOS
{
	public partial class ViewController : UIViewController
	{
		int count = 1;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += Button_TouchUpInside;  
		}

        private async void Button_TouchUpInside(object sender, EventArgs e)
        {
            CancellationTokenSource _cts0 = new CancellationTokenSource();
            //await AppController.GetAllYears(
            //    // Service call success                 
            //    (data) =>
            //    {
            //        ODataList<Year> s = data as ODataList<Year>;
            //            //AppController.Settings.LastLoginUsernameUsed = _email;
            //            //AppController.Settings.AuthAccessToken = data.AuthAccessToken;
            //            //AppController.Settings.AuthExpirationDate = data.AuthExpirationDate.GetValueOrDefault().ToLocalTime();

            //            //((ChattyApplication)this.Activity.Application).RegisterToNotificationsHub();

            //            //var f = new ChatFragment();
            //            //f.Arguments = new Bundle();
            //            //f.Arguments.PutString("Email", _email);
            //            //this.FragmentManager.BeginTransaction()
            //            //    .AddToBackStack("BeforeChatFragment")
            //            //    .Replace(Resource.Id.ContentLayout, f, "ChatFragment")
            //            //    .Commit();
            //        },
            //    // Service call error
            //    (error) =>
            //    {
            //        var er = error;
            //            //if (error.Contains("confirm"))
            //            //    this.VerifyButton.Visibility = ViewStates.Visible;

            //            //Toast.MakeText(this.Activity.Application, error, ToastLength.Long).Show();
            //        },
            //    // Service call finished 
            //    (exception) =>
            //    {
            //            //    _isLogginUser = false;
            //            var ex = exception;
            //            //// Allow user to tap views
            //            //((MainActivity)this.Activity).UnblockUI();
            //        });

            //var title = string.Format("{0} clicks!", count++);
            //Button.SetTitle(title, UIControlState.Normal);            
        }

        public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

