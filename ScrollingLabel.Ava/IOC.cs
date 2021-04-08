using ScrollingLabel.ViewModels;
using ScrollingLabel.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Splat;
using ReactiveUI;

namespace ScrollingLabel
{
    public class IOC : IOCBase
    {
        public IOC() : base()
        {
        }

        protected override void RegisterViews()
        {
            Container.Register(() => new MainWindow
            {
                ViewModel = GetService<IMainWindowViewModel>()
            });
            Container.Register<IViewFor<ICustomerListViewModel>>(() => new CustomerListView());
            Container.Register<IViewFor<ICustomerListItemViewModel>>(() => new CustomerView());

        }
    }
}
