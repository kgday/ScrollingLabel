using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

using ReactiveUI;

using ScrollingLabel.ViewModels;

using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace ScrollingLabel.Views
{
    public class CustomerView : ReactiveUserControl<ICustomerListItemViewModel>
    {
        private TextBlock CustomerName { get; }
        public CustomerView()
        {
            InitializeComponent();
            CustomerName = this.FindControl<TextBlock>("CustomerName");

            this.WhenActivated(d =>
            {
                this.WhenAnyValue(x => x.ViewModel)
                    .BindTo(this, x => x.DataContext)
                    .DisposeWith(d);

                CustomerName.Margin = CustomerNameMargin(DefaultTopMargin());

                MessageBus.Current.Listen<ScrollViewValues>()
                .Select(scrollViewValues => CalculateCustomerNameMargin(scrollViewValues))
                .Select(topMargin => CustomerNameMargin(topMargin))
                .BindTo(this, x => x.CustomerName.Margin)
                .DisposeWith(d);

            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private Thickness CustomerNameMargin(double topMargin)
        {
            return new Thickness(CustomerName.Margin.Left, topMargin, CustomerName.Margin.Right, CustomerName.Margin.Bottom);
        }

        //private double Actual

        const double _verticalPadding = 8.0;
        const double _bottomBuffer = 10.0;
        private double CalculateCustomerNameMargin(ScrollViewValues scrollViewValues)
        {
            var newMargin = DefaultTopMargin();

            if (scrollViewValues.ReferenceParent != null)
            {
                try
                {

                    var topOfCustomerBoxInParentControl = this.TranslatePoint(new Point(0, 0), scrollViewValues.ReferenceParent)?.Y;

                    if ((topOfCustomerBoxInParentControl + newMargin) < (scrollViewValues.ScrollVerticalOffset + _verticalPadding))
                        newMargin = (scrollViewValues.ReferenceParent.TranslatePoint(new Point(0, scrollViewValues.ScrollVerticalOffset + _verticalPadding),this)?.Y).GetValueOrDefault();

                    //what if our calculated margin is below the bottom of the viewport
                    var bottomExtent = scrollViewValues.ScrollVerticalOffset + scrollViewValues.ViewPortHeight;
                    if ((topOfCustomerBoxInParentControl + newMargin) > (bottomExtent - CustomerName.Bounds.Height - _bottomBuffer))
                        newMargin = 
                            (scrollViewValues.ReferenceParent.TranslatePoint(new Point(0, (bottomExtent - CustomerName.Bounds.Height - _bottomBuffer)),this)?.Y).GetValueOrDefault();


                    //don't let us roll of the end of the folder view
                    if ((newMargin) > (Bounds.Height - CustomerName.Bounds.Height - _bottomBuffer))
                        newMargin = Bounds.Height - CustomerName.Bounds.Height - _bottomBuffer;

                    if (newMargin < _verticalPadding)
                        newMargin = _verticalPadding;
                }
                catch
                {

                }
            }

            return newMargin;
        }

        private double DefaultTopMargin()
        {
            return (Bounds.Height - CustomerName.Bounds.Height) / 2;
        }
    }
}
