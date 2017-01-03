namespace ghostshockey.it.app.Droid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;
    using Android.Views;
    using Android.Widget;
    using Android.Graphics;
    using Android.Support.V7.Widget;

    using AdMaiora.AppKit.UI;
    
    using model.Poco;
    using System.Net;

#pragma warning disable CS4014
    public class MatchesFragment : AdMaiora.AppKit.UI.App.Fragment
    {
        #region Inner Classes
		
        class MatchAdapter : ItemRecyclerAdapter<MatchAdapter.MatchViewHolder, Match>
        {
            #region Inner Classes

            public class MatchViewHolder : ItemViewHolder
            {
                [Widget]
                public TextView HomeLabel;

                [Widget]
                public ImageView HomeImage;

                [Widget]
                public TextView HomeScoreLabel;

                [Widget]
                public TextView AwayLabel;

                [Widget]
                public ImageView AwayImage;

                [Widget]
                public TextView AwayScoreLabel;

                [Widget]
                public TextView DateLabel;

                public MatchViewHolder(View itemView)
                    : base(itemView)
                {                    
                }
            }

            #endregion

            #region Costants and Fields

            private Random _rnd;
            private List<string> _palette;
            private Dictionary<string, string> _colors;

            #endregion

            #region Constructors

            public MatchAdapter(AdMaiora.AppKit.UI.App.Fragment context, IEnumerable<Match> source)
                : base(context, Resource.Layout.CellMatch, source)
            {
            }

            #endregion

            #region Public Methods

            public override void GetView(int postion, MatchViewHolder holder, View view, Match item)
            {
                //string checkImage = "image_check_selected";
                Color taskColor = ViewBuilder.ColorFromARGB(AppController.Colors.AshGray);

                //if (!item.IsComplete)
                //{
                //    checkImage = "image_check_empty_green";

                //    DateTime dueDate = item.CreationDate.GetValueOrDefault().Date.AddDays(item.WillDoIn);
                //    int dueDays = (dueDate - DateTime.Now.Date).Days;
                //    taskColor = ViewBuilder.ColorFromARGB(AppController.Colors.Green);
                //    if (dueDays < 2)
                //    {
                //        checkImage = "image_check_empty_red";
                //        taskColor = ViewBuilder.ColorFromARGB(AppController.Colors.Red);
                //    }
                //    else if (dueDays < 4)
                //    {
                //        checkImage = "image_check_empty_orange";
                //        taskColor = ViewBuilder.ColorFromARGB(AppController.Colors.Orange);
                //    }
                //}

                //holder.CheckButton.SetImageResource(checkImage);
                string weburl = "http://web-ghosts.azurewebsites.net/content/teams/";
                holder.HomeLabel.Text = item.HomeTeam.DisplayName;
                holder.HomeScoreLabel.Text = item.HomeTeamScore.ToString();
                holder.AwayLabel.Text = item.AwayTeam.DisplayName;
                holder.AwayScoreLabel.Text = item.AwayTeamScore.ToString();
                holder.DateLabel.Text = item.MatchDate.ToString();
                //AdMaiora.AppKit.Utils.ImageLoader loader = new AdMaiora.AppKit.Utils.ImageLoader(new AdMaiora.AppKit.Utils.ImageLoaderPlatofrmAndroid(), 10);
                //Uri uri = new Uri(weburl + item.HomeTeam.Club.Icon);
                //loader.SetImageForView(uri, "@drawable/icon.png", holder.HomeImage, null, 0, true, (message) =>
                //{
                //    string done = "";
                //});
                //loader.SetImageForView(new Uri(weburl + item.AwayTeam.Club.Icon), "", holder.AwayImage);
                var imageBitmap = GetImageBitmapFromUrl(weburl + item.HomeTeam.Club.Icon);
                holder.HomeImage.SetImageBitmap(imageBitmap);
                imageBitmap = GetImageBitmapFromUrl(weburl + item.AwayTeam.Club.Icon);
                holder.AwayImage.SetImageBitmap(imageBitmap);
                //holder.TitleLabel.SetTextColor(taskColor);
            }

            private Bitmap GetImageBitmapFromUrl(string url)
            {
                Bitmap imageBitmap = null;

                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

                return imageBitmap;
            }

            public void Clear()
            {
                this.SourceItems.Clear();
            }

            public void Refresh(IEnumerable<Match> items)
            {
                this.SourceItems.Clear();
                this.SourceItems.AddRange(items);
            }         

            #endregion

            #region Methods

            protected override void GetViewCreated(RecyclerView.ViewHolder holder, View view, ViewGroup parent)
            {
                var cell = holder as MatchViewHolder;               
            }

            #endregion
        }

        #endregion

        #region Constants and Fields

        private int _userId;
        private Tournament _currentTournament;

        private MatchAdapter _adapter;

        // This flag check if we are already calling the login REST service
        private bool _isRefreshingItems;
        // This cancellation token is used to cancel the rest send message request
        private CancellationTokenSource _cts0;
        
        #endregion

        #region Widgets

        [Widget]
        private ItemRecyclerView MatchList;       

        #endregion

        #region Constructors

        public MatchesFragment()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Fragment Methods

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _userId = 1; // this.Arguments.GetInt("UserId");
            _currentTournament = this.Arguments.GetObject<Tournament>("Item");
        }

        public override void OnCreateView(LayoutInflater inflater, ViewGroup container)
        {
            base.OnCreateView(inflater, container);

            #region Desinger Stuff

            SetContentView(Resource.Layout.FragmentMatches, inflater, container);

            this.HasOptionsMenu = true;

            #endregion

            this.Title = "Agenda";

            this.ActionBar.Show();

            _adapter = new MatchAdapter(this, new Match[0]);
            this.MatchList.SetAdapter(_adapter);
            this.MatchList.ItemSelected += MatchList_ItemSelected; ;

            if (_currentTournament != null)
                RefreshMatches();
        }
        
        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            base.OnCreateOptionsMenu(menu, inflater);

            menu.Clear();
            menu.Add(0, 1, 0, "Add New").SetShowAsAction(ShowAsAction.Always);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
            {
                case Android.Resource.Id.Home:
                    GoBack();
                    return true;

                case 1:

                  

                    return true;

                default:
                    return base.OnOptionsItemSelected(item); ;
            }            
        }

        //public override bool OnBackButton()
        //{
        //    var f = new TournamentsFragment();
        //    f.Arguments = new Bundle();
        //    f.Arguments.PutObject("Item", _currentTournament);
        //    this.FragmentManager.BeginTransaction()
        //        .AddToBackStack("BeforeTaskFragment")
        //        .Replace(Resource.Id.ContentLayout, f, "TournamentsFragment")
        //        .Commit();

        //    return true;            
        //}

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            this.MatchList.ItemSelected -= MatchList_ItemSelected;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Methods

        private void RefreshMatches()
        {
            if (_isRefreshingItems)
                return;

            this.MatchList.Visibility = ViewStates.Gone;

            _isRefreshingItems = true;
            ((MainActivity)this.Activity).BlockUI();

            _cts0 = new CancellationTokenSource();
            AppController.GetMatches(_currentTournament,
                (items) =>
                {
                items = items
                    .OrderBy(x => x.MatchDate)
                    .ToArray();

                _adapter.Refresh(items);
                this.MatchList.ReloadData();
            },
            (error) =>
            {
                Toast.MakeText(this.Activity.ApplicationContext, error, ToastLength.Long).Show();
            },
            () =>
            {
                this.MatchList.Visibility = ViewStates.Visible;

                _isRefreshingItems = false;
                ((MainActivity)this.Activity).UnblockUI();
            });
        }

     

        private void GoBack()
        {
            var f = new TournamentsFragment();
            f.Arguments = new Bundle();
            f.Arguments.PutObject("Item", _currentTournament);
            this.FragmentManager.BeginTransaction()
                .AddToBackStack("BeforeTaskFragment")
                .Replace(Resource.Id.ContentLayout, f, "TournamentsFragment")
                .Commit();
        }

        #endregion

        #region Event Handlers
        private void MatchList_ItemSelected(object sender, ItemListSelectEventArgs e)
        {
            Match item = e.Item as Match;

            var f = new MatchFragment();
            f.Arguments = new Bundle();
            f.Arguments.PutObject("Item", item);
            this.FragmentManager.BeginTransaction()
                .AddToBackStack("BeforeTaskFragment")
                .Replace(Resource.Id.ContentLayout, f, "MatchFragment")
                .Commit();
        }

    

        #endregion
    }
}