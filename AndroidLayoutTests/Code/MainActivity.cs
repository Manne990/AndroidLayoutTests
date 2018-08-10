using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace AndroidLayoutTests.Code
{
    [Activity(Label = "AndroidLayoutTests", MainLauncher = false, Icon = "@mipmap/icon")]
    public class MainActivity : AppCompatActivity
    {
        // Private Members
        private BottomNavigationView _bottomNavigationView;


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
            _bottomNavigationView = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);

            _bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

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
    }
}