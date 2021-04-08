using ScrollingLabel.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingLabel.Dataservice
{
    public interface ICustomerService
    {
        IObservable<List<Customer>> GetCustomers();
    }
}
