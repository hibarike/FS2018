using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TrainingComplexContext db = new TrainingComplexContext()) {
                Customer cst1 = new Customer { FirstName = "Alex", LastName = "Cherniy", Phone = 999999999 };
                Customer cst2 = new Customer { FirstName = "Alex", LastName = "Beliy", Phone = 000000000};
                db.Customers.Add(cst2);
                db.Customers.Add(cst1);
                db.SaveChanges();

                CustomerSubscription subscription1 = new CustomerSubscription { Name = "Dances", Price = 600, QuaintityOfTrainings = 12, LastDayOfUse = new DateTime(2019, 1, 1), Customer = cst2 };
                CustomerSubscription subscription2 = new CustomerSubscription { Name = "SuperPress", Price = 400, QuaintityOfTrainings = 12, LastDayOfUse = new DateTime(2019, 1, 1), Customer = cst1 };
                db.CustomerSubscriptions.Add(subscription1);
                db.CustomerSubscriptions.Add(subscription2);
                db.SaveChanges();
            }
        }
    }
}
