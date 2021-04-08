using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;

using ScrollingLabel.ViewModels;

namespace ScrollingLabel.Design.ViewModels
{
    public class MainWindowViewModelDesign : IMainWindowViewModel
    {
        public ReactiveCommand<Unit, IRoutableViewModel> Load { get; } = ReactiveCommand.Create(() => (IRoutableViewModel)null);
        public RoutingState Router { get; } = new RoutingState();
    }
}
