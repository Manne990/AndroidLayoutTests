using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;

namespace AndroidLayoutTests.Code
{
    [Activity(Label = "AndroidLayoutTests", MainLauncher = false, Icon = "@mipmap/icon")]
    public class DynamicToolbarActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Init
            SetContentView(Resource.Layout.DynamicToolbarActivityLayout);
            //Title = "Toolbar Test";
            FindViewById<CollapsingToolbarLayout>(Resource.Id.toolbar_layout).Title = Title;

            // Toolbar
            SetSupportActionBar(FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar));
        }
    }
}