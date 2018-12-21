using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public int? HallId { get; set; }
        public Hall Hall { get; set; }

        public int? CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Customer> Customers { get; set; }

        public ICollection<Schedule> Schedules { get; set; }

        public Group()
        {
            Customers = new List<Customer>();
            Schedules = new List<Schedule>();
        }
    }
}
