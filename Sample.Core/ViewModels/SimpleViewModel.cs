using Cirrious.MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Core.ViewModels
{
    public class SimpleViewModel
        : MvxNotifyPropertyChanged
    {
        private string _name;
        private string _description;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        private List<string> items;
        public List<string> Items
        {
            get
            {
                if ( null == items )
                {
                    items = new List<string>();
                    items.Add( "First entry" );
                    items.Add( "Second entry" );
                    items.Add( "Third entry" );
                    items.Add( "Fourth entry" );
                    items.Add( "Fifth entry" );
                }
                return items;
            }
            set
            {
                items = value;
                Sort ( 0 );
            }
        }

        public void Sort (int sortCode)
        {
            // in real use case there will be more sort codes etc
            switch ( sortCode )
            {
                case 1:
                   items = items.OrderBy( j => j.ToLowerInvariant() ).ToList<string>();
                    break;
                default:
                    // no sort
                    break;
            }
            RaisePropertyChanged( () => Items );
        }

    }
}
