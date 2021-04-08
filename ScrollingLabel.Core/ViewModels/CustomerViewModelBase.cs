using ReactiveUI;
using ScrollingLabel.Models;
using System.Reactive.Linq;

namespace ScrollingLabel.ViewModels
{
    internal class CustomerViewModelBase : ViewModelBase, ICustomerViewModelBase
    {
        private string _name = string.Empty;
        private int _level;
        private readonly ObservableAsPropertyHelper<string> _levelDisplay;

        public CustomerViewModelBase()
        {
            _levelDisplay = this.WhenAnyValue(x => x.Level)
               .Select(level => $"Level {level}")
               .ToProperty(this, x => x.LevelDisplay);
        }

        public string Name { get => _name; set => this.RaiseAndSetIfChanged(ref _name, value); }
        public int Level { get => _level; set => this.RaiseAndSetIfChanged(ref _level, value); }
        public string LevelDisplay => _levelDisplay.Value;

        public void AssignFromModel(Customer model)
        {
            if (model is null)
            {
                throw new System.ArgumentNullException(nameof(model));
            }

            Name = model.Name;
            Level = model.Level;
        }
    }
}