using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
   public class Schedule
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<Group> Groups { get; set; }

        public Schedule()
        {
            Groups = new List<Group>();
        }
    }
}
