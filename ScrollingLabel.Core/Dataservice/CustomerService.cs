using ScrollingLabel.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrollingLabel.Dataservice
{
    public class CustomerService : ICustomerService
    {
        public IObservable<List<Customer>> GetCustomers()
        {
            return Observable.Return(new List<Customer>
            {
                new Customer {Name = "Joe Bloggs" ,Level=1},
                new Customer {Name = "Fredd Smith And Associates", Level=1},
                new Customer {Name= "John Henry", Level=2},
                new Customer {Name = "Albert And Sons", Level=3},
                new Customer {Name= "St Josephs", Level=1}
            });
        }
    }
}
