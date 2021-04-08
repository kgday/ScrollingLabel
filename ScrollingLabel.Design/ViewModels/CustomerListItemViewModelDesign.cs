using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;

using ScrollingLabel.Models;
using ScrollingLabel.ViewModels;
namespace ScrollingLabel.Design.ViewModels
{
    public class CustomerListItemViewModelDesign : ReactiveObject, ICustomerListItemViewModel
    {
        public int Level { get; set; } = 1;
        public string LevelDisplay { get; } = "Level 1";
        public string Name { get; set; } = "Customer Name";

        public void AssignFromModel(Customer model)
        {
            throw new NotImplementedException();
        }


    }
}
