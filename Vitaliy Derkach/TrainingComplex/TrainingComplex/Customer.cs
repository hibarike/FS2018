using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }

        public ICollection<CustomerSubscription> Subscriptions { get; set; }
        public ICollection<Group> Groups { get; set; }

        public Customer()
        {
            Groups = new List<Group>();
            Subscriptions = new List<CustomerSubscription>();
        }
    }
}
