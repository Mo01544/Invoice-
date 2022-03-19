using System;
using System.Data.Entity;
using System.Linq;

namespace BillPro.models
{
    public class billDB : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BillPro.models.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public billDB()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Typee> Types { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<itemInvoice> ItemInvoices { get; set; }

    }


}