using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TrainingComplex
{
    public class TrainingComplexContext : DbContext
    {
        public TrainingComplexContext()
            :base("DbConnection")
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<AddService> AddServices { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
    }
}
