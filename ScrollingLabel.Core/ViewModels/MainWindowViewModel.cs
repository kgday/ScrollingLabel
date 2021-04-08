using ReactiveUI;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingLabel.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase,  IMainWindowViewModel
    {
        public MainWindowViewModel(Func<ICustomerListViewModel> customerListViewModelFactory)
        {
            Load = ReactiveCommand.CreateFromObservable(() =>
           {
               var customerListViewModel = customerListViewModelFactory();
               return Router.Navigate.Execute(customerListViewModel);
           });
        }

        public RoutingState Router { get; } = new RoutingState();
        public ReactiveCommand<Unit, IRoutableViewModel> Load { get; }
    }
}
