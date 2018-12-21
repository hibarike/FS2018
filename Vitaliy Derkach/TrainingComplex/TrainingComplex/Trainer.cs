using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingComplex
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public int Phone { get; set; }
        public int WorkExperience { get; set; }

        public ICollection<Group> Groups { get; set; }

        public Trainer()
        {
            Groups = new List<Group>();
        }

    }
}
