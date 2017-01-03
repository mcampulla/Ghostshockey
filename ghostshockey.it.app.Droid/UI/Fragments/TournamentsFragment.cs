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

    public class SpacesItemDecoration : RecyclerView.ItemDecoration
    {
        private int mSpace;

        public SpacesItemDecoration(int space)
        {
            this.mSpace = space;
        }
        
        public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state)
        {
            outRect.Left = mSpace;
            outRect.Right = mSpace;
            outRect.Bottom = mSpace;
            // Add top margin only for the first item to avoid double space between items
            if (parent.GetChildAdapterPosition(view) == 0)
                outRect.Top = mSpace;
        }
    }

    #pragma warning disable CS4014
    public class TournamentsFragment : AdMaiora.AppKit.UI.App.Fragment
    {
        #region Inner Classes
		
        class TournamentAdapter : ItemRecyclerAdapter<TournamentAdapter.TournamentViewHolder, Tournament>
        {
            #region Inner Classes

            public class TournamentViewHolder : ItemViewHolder
            {
                [Widget]
                public TextView TitleLabel;

                public TournamentViewHolder(View itemView)
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

            public TournamentAdapter(AdMaiora.AppKit.UI.App.Fragment context, IEnumerable<Tournament> source)
                : base(context, Resource.Layout.CellTournament, source)
            {
            }

            #endregion

            #region Public Methods

            public override void GetView(int postion, TournamentViewHolder holder, View view, Tournament item)
            {
                Color taskColor = ViewBuilder.ColorFromARGB(AppController.Colors.AshGray);
                holder.TitleLabel.Text = item.Name;
                holder.TitleLabel.SetTextColor(taskColor);
            }

            public void Clear()
            {
                this.SourceItems.Clear();
            }

            public void Refresh(IEnumerable<Tournament> items)
            {
                this.SourceItems.Clear();
                this.SourceItems.AddRange(items);
            }

            #endregion

            #region Methods

            protected override void GetViewCreated(RecyclerView.ViewHolder holder, View view, ViewGroup parent)
            {
                var cell = holder as TournamentViewHolder;
            }

            #endregion
        }

        class YearAdapter : ItemRecyclerAdapter<YearAdapter.YearViewHolder, Year>
        {
            #region Inner Classes

            public class YearViewHolder : ItemViewHolder
            {
                [Widget]
                public TextView TitleLabel;

                public YearViewHolder(View itemView)
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

            public YearAdapter(AdMaiora.AppKit.UI.App.Fragment context, IEnumerable<Year> source)
                : base(context, Resource.Layout.CellYear, source)
            {
            }

            #endregion

            #region Public Methods

            public override void GetView(int postion, YearViewHolder holder, View view, Year item)
            {
                Color taskColor = ViewBuilder.ColorFromARGB(AppController.Colors.AshGray);
                holder.TitleLabel.Text = item.Name;
                holder.TitleLabel.SetTextColor(taskColor);
            }

            public void Clear()
            {
                this.SourceItems.Clear();
            }

            public void Refresh(IEnumerable<Year> items)
            {
                this.SourceItems.Clear();
                this.SourceItems.AddRange(items);
            }

            public void SetAsCompleted(int itemId, bool isComplete, DateTime? completionDate = null)
            {
                Year item = this.SourceItems.SingleOrDefault(x => x.YearID == itemId);
            }

            #endregion

            #region Methods

            protected override void GetViewCreated(RecyclerView.ViewHolder holder, View view, ViewGroup parent)
            {
                var cell = holder as YearViewHolder;
            }

            #endregion
        }

        #endregion

        #region Constants and Fields

        private int _userId;

        private TournamentAdapter _tournamentAdapter;
        private YearAdapter _yearAdapter;

        private Year _currentYear;

        // This flag check if we are already calling the login REST service
        private bool _isRefreshingTournaments;
        private bool _isRefreshingYears;
        // This cancellation token is used to cancel the rest send message request
        private CancellationTokenSource _cts0;
        
        #endregion

        #region Widgets

        [Widget]
        private ItemRecyclerView TournamentList;
        [Widget]
        private ItemRecyclerView YearList;

        #endregion

        #region Constructors

        public TournamentsFragment()
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
        }

        public override void OnCreateView(LayoutInflater inflater, ViewGroup container)
        {
            base.OnCreateView(inflater, container);

            #region Desinger Stuff

            SetContentView(Resource.Layout.FragmentTournaments, inflater, container);

            //this.HasOptionsMenu = false;

            #endregion

            //this.Title = "Campionati";

            this.ActionBar.Hide();

            _tournamentAdapter = new TournamentAdapter(this, new Tournament[0]);
            this.TournamentList.SetAdapter(_tournamentAdapter);
            this.TournamentList.ItemSelected += TournamentList_ItemSelected;
            //this.TournamentList.ItemLongPress += TaskList_ItemLongPress;
            //this.TournamentList.ItemCommand += TaskList_ItemCommand;


            //RecyclerView.ItemDecoration itemDecoration = new SpacesItemDecoration(10);
            //this.TournamentList.AddItemDecoration(itemDecoration);

            _yearAdapter = new YearAdapter(this, new Year[0]);
            this.YearList.SetAdapter(_yearAdapter);
            this.YearList.ItemSelected += YearList_ItemSelected;

            LinearLayoutManager layoutManager = new LinearLayoutManager(this.Context, LinearLayoutManager.Horizontal, false);
            //// Optionally customize the position you want to default scroll to
            layoutManager.ScrollToPosition(0);
            // Attach layout manager to the RecyclerView

            this.YearList.SetLayoutManager(layoutManager);
            //this.YearList.ItemLongPress += TaskList_ItemLongPress;
            //this.YearList.ItemCommand += TaskList_ItemCommand;

            RefreshYears();
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
                    QuitAgenda();
                    return true;

                case 1:

                    //var f = new TaskFragment();
                    //f.Arguments = new Bundle();
                    //f.Arguments.PutInt("UserId", _userId);
                    //this.FragmentManager.BeginTransaction()
                    //    .AddToBackStack("BeforeTaskFragment")
                    //    .Replace(Resource.Id.ContentLayout, f, "TaskFragment")
                    //    .Commit();

                    return true;

                default:
                    return base.OnOptionsItemSelected(item); ;
            }            
        }

        public override bool OnBackButton()
        {
            QuitAgenda();
            return true;            
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();

            this.YearList.ItemSelected -= YearList_ItemSelected;
            this.TournamentList.ItemSelected -= TournamentList_ItemSelected;
        }

        #endregion

        #region Public Methods
        #endregion

        #region Methods

        private void RefreshTournaments()
        {
            if (_isRefreshingTournaments)
                return;

            this.TournamentList.Visibility = ViewStates.Gone;

            _isRefreshingTournaments = true;
            ((MainActivity)this.Activity).BlockUI();

            _cts0 = new CancellationTokenSource();
            AppController.GetTournaments(_currentYear,
                (items) =>
                {
                    items = items
                        .OrderByDescending(x => x.DateStart)
                        .ToArray();

                    _tournamentAdapter.Refresh(items);
                    this.TournamentList.ReloadData();
                },
                (error) =>
                {
                    Toast.MakeText(this.Activity.ApplicationContext, error, ToastLength.Long).Show();
                },
                () =>
                {
                    this.TournamentList.Visibility = ViewStates.Visible;

                    _isRefreshingTournaments = false;
                    ((MainActivity)this.Activity).UnblockUI();
                });
        }

        private void RefreshYears()
        {
            if (_isRefreshingYears)
                return;

            this.YearList.Visibility = ViewStates.Gone;

            _isRefreshingYears = true;
            ((MainActivity)this.Activity).BlockUI();

            _cts0 = new CancellationTokenSource();
            AppController.GetYears(
                (items) =>
                {
                    items = items
                        .OrderByDescending(x => x.DateStart)
                        .ToArray();

                    _currentYear = items.FirstOrDefault(y => y.IsCurrent.Value);

                    RefreshTournaments();

                    _yearAdapter.Refresh(items);
                    this.YearList.ReloadData();
                },
                (error) =>
                {
                    Toast.MakeText(this.Activity.ApplicationContext, error, ToastLength.Long).Show();
                },
                () =>
                {
                    this.YearList.Visibility = ViewStates.Visible;

                    _isRefreshingYears = false;
                    ((MainActivity)this.Activity).UnblockUI();
                });
        }

        private void QuitAgenda()
        {
            //(new AlertDialog.Builder(this.Activity))
            //    .SetTitle("Leave the agenda?")
            //    .SetMessage("Press ok to leave the agenda now!")
            //    .SetPositiveButton("Ok",
            //        (s, ea) =>
            //        {
            //            AppController.Settings.AuthAccessToken = null;
            //            AppController.Settings.AuthExpirationDate = null;

            //            this.DismissKeyboard();
            //            this.FragmentManager.PopBackStack();
            //        })
            //    .SetNegativeButton("Take me back",
            //        (s, ea) =>
            //        {
            //        })
            //    .Show();
        }

        #endregion

        #region Event Handlers

        private void YearList_ItemSelected(object sender, ItemListSelectEventArgs e)
        {
            Year item = e.Item as Year;

            _currentYear = item;

            RefreshTournaments();
        }

        private void TournamentList_ItemSelected(object sender, ItemListSelectEventArgs e)
        {
            Tournament item = e.Item as Tournament;

            var f = new MatchesFragment();
            f.Arguments = new Bundle();
            f.Arguments.PutObject("Item", item);
            this.FragmentManager.BeginTransaction()
                .AddToBackStack("BeforeTaskFragment")
                .Replace(Resource.Id.ContentLayout, f, "MatchesFragment")
                .Commit();
        }
        
        //private void TaskList_ItemCommand(object sender, ItemListCommandEventArgs e)
        //{
        //    TodoItem item = e.UserData as TodoItem;
        //    switch (e.Command)
        //    {
        //        case "SetAsDone":
        //            CompleteTodoItem(item, true);
        //            break;

        //        case "SetAsNotDone":
        //            CompleteTodoItem(item, false);
        //            break;
        //    }

        //    this.TaskList.ReloadData();
        //}

        #endregion
    }
}