using Android.Views;

namespace Cheesebaron.MvvmCross.Bindings.Droid
{
    public class ChildInflatedEventArgs : System.EventArgs
    {
        public ChildInflatedEventArgs ( View view, object viewModel )
        {
            Child = view;
            ViewModel = viewModel;
        }

        private View child;
        public View Child
        {
            get
            {
                return child;
            }
            private set
            {
                child = value;
            }
        }

        private object viewModel;
        public object ViewModel
        {
            get
            {
                return viewModel;
            }
            private set
            {
                viewModel = value;
            }
        }
    }
}