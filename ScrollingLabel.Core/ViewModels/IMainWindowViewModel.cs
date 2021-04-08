using ReactiveUI;

using System.Reactive;

namespace ScrollingLabel.ViewModels
{
    public interface IMainWindowViewModel : IScreen
    {
        ReactiveCommand<Unit, IRoutableViewModel> Load { get; }
    }
}