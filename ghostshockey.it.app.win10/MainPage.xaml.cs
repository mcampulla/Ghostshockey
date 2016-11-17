using ghostshockey.it.model.Poco;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ghostshockey.it.app.win10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int count = 0;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void button_Click(System.Object sender, RoutedEventArgs e)
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

            var title = string.Format("{0} clicks!", count++);
            ((Button)sender).Content = title;
        }
    }
}
