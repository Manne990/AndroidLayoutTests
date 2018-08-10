using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AndroidLayoutTests.Code
{
    public class ItemFragment : Fragment
    {
        private readonly string _title;

        public ItemFragment(string title)
        {
            _title = title;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.ItemFragmentLayout, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            var titleTextView = view.FindViewById<TextView>(Resource.Id.titleTextView);
            titleTextView.Text = _title;
        }
    }
}