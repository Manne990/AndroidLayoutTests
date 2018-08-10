using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;

namespace AndroidLayoutTests.Code
{
    public class HomeFragment : Fragment
    {
        private View _containerView;
        private ViewPager _pager;
        private HomePagerAdapter _adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            _containerView = _containerView ?? inflater.Inflate(Resource.Layout.HomeFragmentLayout, container, false);

            return _containerView;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            if (_pager?.Adapter != null && _adapter != null)
            {
                return;
            }

            _pager = view.FindViewById<ViewPager>(Resource.Id.pager);

            _adapter = new HomePagerAdapter(ChildFragmentManager);
            _pager.Adapter = _adapter;
        }

        public override void OnResume()
        {
            base.OnResume();

            _adapter.Update(new List<HomePageItem>
            {
                new HomePageItem { Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." },
                new HomePageItem { Content = "Vestibulum id ligula porta felis euismod semper." },
                new HomePageItem { Content = "Donec id elit non mi porta gravida at eget metus." }
            });
        }
    }
}