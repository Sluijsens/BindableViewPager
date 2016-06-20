using Android.Content;
using Android.Views;
using Android.Support.V4.View;
using MvvmCross.Core.ViewModels;
using System.Collections.ObjectModel;

namespace BindableViewPager.Adapters
{
    public class BindableViewPagerAdapter<T> : PagerAdapter
    {
        public delegate ViewGroup LoadView(Context context, IMvxViewModel viewModel, ViewGroup container, T obj);

        private Context _context;
        private Collection<T> _collection;
        private IMvxViewModel _viewModel;
        private LoadView _loadView;

        public BindableViewPagerAdapter(Context context, IMvxViewModel viewModel, Collection<T> collection, LoadView loadView)
        {
            _context = context;
            _collection = collection;
            _viewModel = viewModel;
            _loadView = loadView;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            return _loadView(Context, ViewModel, container, Collection[position]);
        }

        public override void DestroyItem(ViewGroup collection, int position, Java.Lang.Object view)
        {
            collection.RemoveView((View)view);
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object obj)
        {
            return view == obj;
        }

        public override int Count
        {
            get
            {
                return Collection.Count;
            }
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
            }
        }

        public Context Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        public IMvxViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value;
            }
        }
    }
}