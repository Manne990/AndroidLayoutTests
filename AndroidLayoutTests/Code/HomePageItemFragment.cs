using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AndroidLayoutTests.Code
{
    public class HomePageItemFragment : Fragment
    {
        private readonly HomePageItem _item;

        public HomePageItemFragment(HomePageItem item)
        {
            _item = item;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.HomePageItemFragmentLayout, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var titleTextView = view.FindViewById<TextView>(Resource.Id.titleTextView);
            titleTextView.Text = _item.Content;
        }
    }
}