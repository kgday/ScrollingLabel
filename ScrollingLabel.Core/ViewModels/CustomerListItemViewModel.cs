using ReactiveUI;

using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ScrollingLabel.ViewModels
{
    internal class CustomerListItemViewModel : CustomerViewModelBase, ICustomerListItemViewModel
    {
        public CustomerListItemViewModel() : base()
        {
        }
    }
}