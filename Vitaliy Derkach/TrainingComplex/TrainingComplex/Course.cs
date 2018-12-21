using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
   public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Group> Groups;

        public Course()
        {
            Groups = new List<Group>();
        }
    }
}
