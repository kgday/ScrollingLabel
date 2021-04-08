using ReactiveUI;

using ScrollingLabel.Dataservice;
using ScrollingLabel.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingLabel.ViewModels
{
    public class CustomerListViewModel : ViewModelBase, ICustomerListViewModel
    {
        private ObservableCollection<ICustomerListItemViewModel> _customers = new ObservableCollection<ICustomerListItemViewModel>();

        public CustomerListViewModel(ICustomerService customerService, IScreen screen, Func<ICustomerListItemViewModel> customerViewModelFactory)
        {
            HostScreen = screen;
            Customers = new ObservableCollection<ICustomerListItemViewModel>();
            Load = ReactiveCommand.CreateFromObservable(() => customerService.GetCustomers());
            Load
                .Select(customers => customers.Select(customer =>
                {
                    var customerViewModel = customerViewModelFactory();
                    customerViewModel.AssignFromModel(customer);
                    return customerViewModel;
                }))
                .Subscribe(customerViewModels => Customers = new ObservableCollection<ICustomerListItemViewModel>(customerViewModels));
        }

        public ReactiveCommand<Unit, List<Customer>> Load { get; }

        public ObservableCollection<ICustomerListItemViewModel> Customers { get => _customers; set => this.RaiseAndSetIfChanged(ref _customers, value); }
        public string UrlPathSegment { get; } = "CustomerList";
        public IScreen HostScreen { get; }
    }
}
