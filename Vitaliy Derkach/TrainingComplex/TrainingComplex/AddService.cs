using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
    public class AddService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? CustomerSubscriptionId { get; set; }
        public CustomerSubscription Subscription { get; set; }
    }
}
