using ReactiveUI;

using ScrollingLabel.Models;
using ScrollingLabel.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingLabel.Design.ViewModels
{
    public class CustomerListViewModelDesign : ReactiveObject, ICustomerListViewModel
    {
        public ObservableCollection<ICustomerListItemViewModel> Customers { get; set; } = new ObservableCollection<ICustomerListItemViewModel>();
        public ReactiveCommand<Unit, List<Customer>> Load { get; } = ReactiveCommand.Create(() => new List<Customer>());
        public string UrlPathSegment { get; }
        public IScreen HostScreen { get; }
    }
}
