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
using System.Reactive.Linq;

namespace ScrollingLabel.Views
{

    public class CustomerViewBase : ReactiveUserControl<ICustomerListItemViewModel>{}

    /// <summary>
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : CustomerViewBase
    {
        public CustomerView()
        {

            InitializeComponent();
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
                    var topOfCustomerBoxInParentControl = scrollViewValues.ReferenceParent.PointFromScreen(PointToScreen(new Point(0, 0))).Y;

                    if ((topOfCustomerBoxInParentControl + newMargin) < (scrollViewValues.ScrollVerticalOffset + _verticalPadding))
                        newMargin = PointFromScreen(scrollViewValues.ReferenceParent.PointToScreen(new Point(0, scrollViewValues.ScrollVerticalOffset + _verticalPadding))).Y;

                    //what if our calculated margin is below the bottom of the viewport
                    var bottomExtent = scrollViewValues.ScrollVerticalOffset + scrollViewValues.ViewPortHeight;
                    if ((topOfCustomerBoxInParentControl + newMargin) > (bottomExtent - CustomerName.ActualHeight - _bottomBuffer))
                        newMargin = PointFromScreen(
                            scrollViewValues.ReferenceParent.PointToScreen(new Point(0, (bottomExtent - CustomerName.ActualHeight - _bottomBuffer)))).Y;


                    //don't let us roll of the end of the folder view
                    if ((newMargin) > (ActualHeight - CustomerName.ActualHeight - _bottomBuffer))
                        newMargin = ActualHeight - CustomerName.ActualHeight - _bottomBuffer;

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
            return (ActualHeight - CustomerName.ActualHeight) / 2;
        }
    }
}
