using ReactiveUI;

using ScrollingLabel.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reactive.Disposables;

namespace ScrollingLabel.Views
{
    public class CustomerListViewBase : ReactiveUserControl<ICustomerListViewModel> { }

    /// <summary>
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    /// 
    public partial class CustomerListView : CustomerListViewBase
    {
        public CustomerListView()
        {
            InitializeComponent();
            this.WhenActivated(d =>
           {
               this.WhenAnyValue(x => x.ViewModel)
                .BindTo(this, x => x.DataContext)
                .DisposeWith(d);

               MessageBus
                .Current
                .RegisterMessageSource(
                   CustomersScrollViewer.WhenAnyValue(x => x.ContentVerticalOffset, x => x.ViewportHeight,
                       (cvo, vh) => new ScrollViewValues(cvo, vh, CustomersListControl))
                  );

               ViewModel?
                 .Load
                 .Execute()
                 .Subscribe()
                 .DisposeWith(d);
           });
        }
    }
}
