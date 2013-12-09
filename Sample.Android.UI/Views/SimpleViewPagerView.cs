using Android.App;
using Cheesebaron.MvvmCross.Bindings.Droid;
using Sample.Core.ViewModels;
using Cirrious.MvvmCross.Droid.Views;

namespace Sample.Droid.UI.Views
{
    [Activity(Label = "ViewPager!!!", LaunchMode = Android.Content.PM.LaunchMode.SingleTop)]
    public class ViewPagerShizzleView
        : MvxActivity
    {
        public new SimpleListViewModel ViewModel
        {
            get { return (SimpleListViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_SimpleViewPagerView);

            var pager = FindViewById<BindableViewPager>(Resource.Id.viewPagerView);
            pager.Adapter.OnChildInflated += Adapter_OnChildInflated;
        }


        void Adapter_OnChildInflated ( object sender, ChildInflatedEventArgs e )
        {
            // Setup sort buttom
            var btn = e.Child.FindViewById( Resource.Id.filter );
            btn.Click += delegate
            {
                Android.Util.Log.Info( "AdapterEvent", "Clicked on the sort button" );
                ShowSortDialog( e.ViewModel as SimpleViewModel );
            };
        }

        private void ShowSortDialog ( SimpleViewModel childViewModel )
        {
            if ( null == childViewModel )
            {
                Android.Util.Log.Info( "AdapterEvent", "Tried to launch dialog with invalid view model" );
                return;
            }          

            AlertDialog.Builder b = new AlertDialog.Builder( this );
            b.SetTitle( "Sort alphabetically?" );
         
            b.SetNegativeButton( Android.Resource.String.Cancel, ( sender, args ) =>
            {
            } );
            b.SetPositiveButton( Android.Resource.String.Ok, ( sender, args ) =>
            {
                childViewModel.Sort( 1 );
            } );
            b.Show();
        }
    }
}
