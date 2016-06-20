using Android.Content;
using Android.Support.V4.View;
using BindableViewPager.Adapters;
using System.Collections.ObjectModel;

namespace BindableViewPager.Views
{
    public class BindableViewPager<T> : ViewPager
    {
        Collection<T> _collection;

        public BindableViewPager(Context context)
            : base(context)
        {
            _collection = new Collection<T>();
        }

        public BindableViewPager(Context context, Android.Util.IAttributeSet attrs)
            : base(context, attrs)
        {
        }

        public Collection<T> Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                _collection = value;
                var adapter = Adapter;
                (adapter as BindableViewPagerAdapter<T>).Collection = _collection;
                Adapter = null;
                Adapter = adapter;
            }
        }
    }
}