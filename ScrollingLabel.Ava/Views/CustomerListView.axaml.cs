using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ReactiveUI;

using ScrollingLabel.ViewModels;

using System;
using System.Reactive.Disposables;

namespace ScrollingLabel.Views
{
    public class CustomerListView : ReactiveUserControl<ICustomerListViewModel>
    {
        public ScrollViewer CustomersScrollViewer { get; }
        public ItemsControl CustomersListControl { get; }

        public CustomerListView()
        {
            InitializeComponent();
            CustomersScrollViewer = this.FindControl<ScrollViewer>("CustomersScrollViewer");
            CustomersListControl = this.FindControl<ItemsControl>("CustomersListControl");
            
            this.WhenActivated(d =>
            {
                this.WhenAnyValue(x => x.ViewModel)
                 .BindTo(this, x => x.DataContext)
                 .DisposeWith(d);

                MessageBus
                 .Current
                 .RegisterMessageSource(
                    CustomersScrollViewer.WhenAnyValue(x => x.Offset.Y, x => x.Viewport.Height,
                        (cvo, vh) => new ScrollViewValues(cvo, vh, CustomersListControl))
                   );

                ViewModel?
                  .Load
                  .Execute()
                  .Subscribe()
                  .DisposeWith(d);
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
