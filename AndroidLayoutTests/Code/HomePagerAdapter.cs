using System.Collections.Generic;
using Android.Support.V4.App;

namespace AndroidLayoutTests.Code
{
    public class HomePagerAdapter : FragmentStatePagerAdapter
    {
        // Private Members
        private List<HomePageItem> _items;


        // -----------------------------------------------------------------------------

        // Constructors
        public HomePagerAdapter(FragmentManager fm) : base(fm)
        {
        }

        public void Update(List<HomePageItem> items)
        {
            _items = items;
            NotifyDataSetChanged();
        }


        // -----------------------------------------------------------------------------

        // Overrides
        public override int Count => _items?.Count ?? 0;

        public override Fragment GetItem(int position)
        {
            return new HomePageItemFragment(_items[position]);
        }

        public override int GetItemPosition(Java.Lang.Object @object)
        {
            return PositionNone;
        }
    }
}