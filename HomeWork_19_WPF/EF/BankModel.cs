using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HomeWork_19_WPF
{
    // класс-потомок DbContext EF 
    public partial class BankModel : DbContext
    {
        public BankModel()
            : base("name=BankModelCon")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Deposit> Deposits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
