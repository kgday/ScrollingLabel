using ScrollingLabel.Dataservice;
using ScrollingLabel.ViewModels;

using Splat;

using System;
using System.Collections.Generic;
using System.Text;

namespace ScrollingLabel
{
    public abstract class IOCBase
    {
        private readonly IReadonlyDependencyResolver _resolver;

        protected IOCBase()
        {
            _resolver = Locator.Current;
            Container = Locator.CurrentMutable;
        }

        protected IMutableDependencyResolver Container { get; }

        public void RegisterDependencies()
        {
            RegisterServices();
            RegisterViewModels();
            RegisterViews();
        }

        public T GetService<T>(string? contract = null)
        {
            var service = _resolver.GetService<T>(contract);
            if (service == null)
            {
                var sb = new StringBuilder(typeof(T).Name);
                if (!string.IsNullOrWhiteSpace(contract))
                    sb.Append($" (keyed: {contract})");
                throw new ServiceNotFound($"Unable to locate service {sb}");
            }
            return service;
        }

        protected virtual void RegisterServices()
        {
            Container.Register<ICustomerService>(() => new CustomerService());
        }

        protected virtual void RegisterViewModels()
        {
            var mainViewModel = new MainWindowViewModel(() => GetService<ICustomerListViewModel>());
            Container.RegisterConstant<IMainWindowViewModel>(mainViewModel);
            Container.Register<ICustomerListItemViewModel>(() => new CustomerListItemViewModel());
            Container.Register<ICustomerListViewModel>(() => new CustomerListViewModel(GetService<ICustomerService>(),
               mainViewModel,
               () => GetService<ICustomerListItemViewModel>()));
        }

        protected abstract void RegisterViews();
    }

    public class ServiceNotFound : Exception
    {
        public ServiceNotFound(string? message) : base(message)
        {
        }
    }
}