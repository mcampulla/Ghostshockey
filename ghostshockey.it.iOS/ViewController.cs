using System;
using ghostshockey.it.core;
using System.Threading;
using UIKit;

namespace ghostshockey.it.iOS
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
			Button.TouchUpInside += delegate {
				var title = string.Format ("{0} clicks!", count++);
				Button.SetTitle (title, UIControlState.Normal);

                CancellationTokenSource _cts0 = new CancellationTokenSource();
                AppController.GetAllYears(
                    // Service call success                 
                    (data) =>
                    {
                        var s = data;
                    },
                    // Service call error
                    (error) =>
                    {
                        //if (error.Contains("confirm"))
                        //    this.VerifyButton.Visibility = ViewStates.Visible;

                        //Toast.MakeText(this.Activity.Application, error, ToastLength.Long).Show();
                    },
                    // Service call finished 
                    (exception) =>
                    {
                        //    _isLogginUser = false;s

                        //// Allow user to tap views
                        //((MainActivity)this.Activity).UnblockUI();
                    });

            };
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

