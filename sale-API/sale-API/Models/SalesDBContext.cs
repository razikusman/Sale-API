using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace sale_API.Models
{
    public partial class SalesDBContext : DbContext
    {
        public SalesDBContext()
        {
        }

        public SalesDBContext(DbContextOptions<SalesDBContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } //customer model
        public DbSet<Invoice> Invoices { get; set; } //Invice model
        public DbSet<Item> Items { get; set; } //Item model
        public DbSet<Order> Ordders { get; set; } //Order model

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name = SalesDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            //modelBuilder.Entity<Customer>().Property(u => u.CustomerID).Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
