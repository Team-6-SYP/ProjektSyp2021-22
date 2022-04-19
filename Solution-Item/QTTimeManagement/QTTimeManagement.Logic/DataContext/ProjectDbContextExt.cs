using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTTimeManagement.Logic.Entities;

namespace QTTimeManagement.Logic.DataContext
{
    partial class ProjectDbContext
    {
        public DbSet<CollectiveAgreement> CollectiveAgreements { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceTemplate> ServiceTemplates { get; set; }
        public DbSet<TimeBlock> TimeBlocks { get; set; }

        partial void GetDbSet<E>(ref DbSet<E>? dbSet, ref bool handled) where E : IdentityEntity
        {
            if(typeof(E) == typeof(CollectiveAgreement))
            {
                dbSet = CollectiveAgreements as DbSet<E>;
                handled = true;
            }
            else if(typeof(E) == typeof(Employee))
            {
                dbSet = Employees as DbSet<E>;
                handled = true;
            }
            else if (typeof(E) == typeof(Holiday))
            {
                dbSet = Holidays as DbSet<E>;
                handled = true;
            }
            else if (typeof(E) == typeof(Rate))
            {
                dbSet = Rates as DbSet<E>;
                handled = true;
            }
            else if (typeof(E) == typeof(Service))
            {
                dbSet = Services as DbSet<E>;
                handled = true;
            }
            else if (typeof(E) == typeof(ServiceTemplate))
            {
                dbSet = ServiceTemplates as DbSet<E>;
                handled = true;
            }
            else if (typeof(E) == typeof(TimeBlock))
            {
                dbSet = TimeBlocks as DbSet<E>;
                handled = true;
            }
        }

    }
}
