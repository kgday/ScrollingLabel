using ReactiveUI;

using ScrollingLabel.Models;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;

namespace ScrollingLabel.ViewModels
{
    public interface ICustomerListViewModel : IRoutableViewModel
    {
        ObservableCollection<ICustomerListItemViewModel> Customers { get; set; }
        ReactiveCommand<Unit, List<Customer>> Load { get; }
    }
}