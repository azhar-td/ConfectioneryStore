using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfectioneryStore.Models
{
    public class ConfectioneryDbContext:DbContext
    {
        public DbSet<Confectionery> Confectionery { get; set; }
        public DbSet<ConfectioneryOrder> ConfectioneryOrder { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public ConfectioneryDbContext(DbContextOptions<ConfectioneryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer).HasName("Customer_PK");
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(60).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee).HasName("Employee_PK");
                entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Surname).HasMaxLength(60).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(c => c.Customer)
                      .WithMany(o => o.Orders)
                      .HasForeignKey(io => io.IdCustomer)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("Order_Customer_FK");

                entity.HasOne(e => e.Employee)
                      .WithMany(o => o.Orders)
                      .HasForeignKey(eo => eo.IdEmployee)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("Order_Employee_FK");

                entity.HasKey(e => e.IdOrder).HasName("Order_PK");
                entity.Property(e => e.DateAccepted).IsRequired();
                entity.Property(e => e.DateFinished).IsRequired();
                entity.Property(e => e.Notes).HasMaxLength(255).IsRequired();
            });

            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(c => c.IdConfectionery).HasName("Confectionery_PK");
                entity.Property(c => c.Name).HasMaxLength(200).IsRequired();
                entity.Property(c => c.PricePerItem).IsRequired();
                entity.Property(c => c.Type).HasMaxLength(40).IsRequired();
            });

            modelBuilder.Entity<ConfectioneryOrder>(entity =>
            {
                entity.ToTable("ConfectioneryOrder");
                entity.HasKey(co => new
                {
                    co.IdConfectionery,
                    co.IdOrder
                });

                entity.Property(co => co.Quantity).IsRequired();
                entity.Property(co => co.Notes).HasMaxLength(255).IsRequired();
            });
        }
    }
}
