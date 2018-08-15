using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AndroidLayoutTests.Code
{
    [Activity(Label = "AndroidLayoutTests", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        // Private Members
        private BottomNavigationView _bottomNavigationView;
        private LinearLayout _bottomSheetHeaderLayout;
        private TextView _bottomSheetBodyTextView;


        // -----------------------------------------------------------------------------

        // Lifecycle
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Init
            SetContentView(Resource.Layout.Main);
            Title = "Layout Test";

            // Toolbar
            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar));

            // Controls
            _bottomSheetHeaderLayout = FindViewById<LinearLayout>(Resource.Id.bottomSheetHeaderLayout);
            _bottomSheetBodyTextView = FindViewById<TextView>(Resource.Id.bottomSheetBodyTextView);

            _bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            _bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            var coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.mainLayout);
            var colorBottomSheet = coordinatorLayout.FindViewById<NestedScrollView>(Resource.Id.bottomSheetScrollView);
            var bottomSheetBehavior = BottomSheetBehavior.From(colorBottomSheet);

            //bottomSheetBehavior.PeekHeight = 0;
            bottomSheetBehavior.SetBottomSheetCallback(new CustomBottomSheetCallback(_bottomSheetHeaderLayout, _bottomSheetBodyTextView));

            // Coordinator Layout
            //var coordinatorLayout = FindViewById<CoordinatorLayout>(Resource.Id.mainLayout);
            //var colorBottomSheet = coordinatorLayout.FindViewById<NestedScrollView>(Resource.Id.bottomSheetScrollView);
            //var bottomSheetBehavior = BottomSheetBehavior.From(colorBottomSheet);
            //var effects = FindViewById<Button>(Resource.Id.effects);
            //effects.Click += (sender, e) => 
            //{
            //    bottomSheetBehavior.State = BottomSheetBehavior.StateExpanded;
            //};

            // Load the first fragment on creation
            LoadFragment(new HomeFragment());
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (_bottomNavigationView != null)
            {
                _bottomNavigationView.NavigationItemSelected -= BottomNavigation_NavigationItemSelected;
            }

            _bottomNavigationView = null;
        }


        // -----------------------------------------------------------------------------

        // Private Methods
        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e?.Item?.ItemId)
            {
                case Resource.Id.action_home:
                    LoadFragment(new HomeFragment());
                    break;
                case Resource.Id.action_item_2:
                    LoadFragment(new ItemFragment("Item 2"));
                    break;
                case Resource.Id.action_item_3:
                    LoadFragment(new ItemFragment("Item 3"));
                    break;
                case Resource.Id.action_item_4:
                    LoadFragment(new ItemFragment("Item 4"));
                    break;
                case Resource.Id.action_item_5:
                    LoadFragment(new ItemFragment("Item 5"));
                    break;
            }
        }

        private void LoadFragment(Android.Support.V4.App.Fragment fragment)
        {
            if (fragment == null)
            {
                return;
            }

            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.container, fragment)
                                  .Commit();
        }


        // -----------------------------------------------------------------------------

        // Classes
        public class CustomBottomSheetCallback : BottomSheetBehavior.BottomSheetCallback
        {
            private readonly View _headerView;
            private readonly View _bodyView;

            public CustomBottomSheetCallback(View headerView, View bodyView)
            {
                _headerView = headerView;
                _bodyView = bodyView;
            }

            public override void OnStateChanged(View bottomSheet, int newState)
            {
                if (newState == BottomSheetBehavior.StateHidden)
                {
                    System.Diagnostics.Debug.WriteLine("StateHidden");
                    return;
                }

                if (newState == BottomSheetBehavior.StateDragging)
                {
                    System.Diagnostics.Debug.WriteLine("StateDragging");
                    //_view.Visibility = ViewStates.Visible;
                    return;
                }

                if (newState == BottomSheetBehavior.StateExpanded)
                {
                    System.Diagnostics.Debug.WriteLine("StateExpanded");
                    //_view.Visibility = ViewStates.Gone;
                    return;
                }

                if (newState == BottomSheetBehavior.StateSettling)
                {
                    System.Diagnostics.Debug.WriteLine("StateSettling");
                    return;
                }

                if (newState == BottomSheetBehavior.StateCollapsed)
                {
                    System.Diagnostics.Debug.WriteLine("StateCollapsed");
                    return;
                }
            }

            public override void OnSlide(View bottomSheet, float slideOffset)
            {
                var alpha = 1 - (slideOffset * 4f);
                if (alpha < 0)
                {
                    alpha = 0;
                }

                _headerView.Animate().Alpha(alpha).SetDuration(0).Start();
                _bodyView.Animate().Alpha(slideOffset).SetDuration(0).Start();
            }
        }
    }
}