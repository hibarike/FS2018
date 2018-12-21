using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
    public class CustomerSubscription
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime LastDayOfUse { get; set; }
        public int QuaintityOfTrainings { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<AddService> AddServices { get; set; }

        public CustomerSubscription()
        {
            AddServices = new List<AddService>();
        }
    }
}
