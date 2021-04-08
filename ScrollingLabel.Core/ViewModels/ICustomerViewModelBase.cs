using ScrollingLabel.Models;

namespace ScrollingLabel.ViewModels
{
    public interface ICustomerViewModelBase : IViewModelBase
    {
        int Level { get; set; }
        string LevelDisplay { get; }
        string Name { get; set; }

        void AssignFromModel(Customer model);
    }
}