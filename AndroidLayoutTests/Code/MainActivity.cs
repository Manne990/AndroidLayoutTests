using System;
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
        private NestedScrollView _bottomSheetScrollView;


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
            _bottomSheetScrollView = coordinatorLayout.FindViewById<NestedScrollView>(Resource.Id.bottomSheetScrollView);
            var bottomSheetBehavior = BottomSheetBehavior.From(_bottomSheetScrollView);

            //bottomSheetBehavior.PeekHeight = 0;
            bottomSheetBehavior.SetBottomSheetCallback(new CustomBottomSheetCallback(_bottomSheetHeaderLayout, _bottomSheetBodyTextView, _bottomSheetScrollView));

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
            private readonly View _container;

            public CustomBottomSheetCallback(View headerView, View bodyView, View container)
            {
                _headerView = headerView;
                _bodyView = bodyView;
                _container = container;
            }

            public override void OnStateChanged(View bottomSheet, int newState)
            {
                if (newState == BottomSheetBehavior.StateHidden)
                {
                    return;
                }

                if (newState == BottomSheetBehavior.StateDragging)
                {
                    return;
                }

                if (newState == BottomSheetBehavior.StateExpanded)
                {
                    return;
                }

                if (newState == BottomSheetBehavior.StateSettling)
                {
                    return;
                }

                if (newState == BottomSheetBehavior.StateCollapsed)
                {
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
                _container.SetBackgroundColor(new Android.Graphics.Color(68, 68, 68, (int)Math.Round(255 * slideOffset)));
            }
        }
    }
}