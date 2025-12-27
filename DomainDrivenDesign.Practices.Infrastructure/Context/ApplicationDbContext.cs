using DomainDrivenDesign.Practices.Domain.Abstractions;
using DomainDrivenDesign.Practices.Domain.Categories;
using DomainDrivenDesign.Practices.Domain.Orders;
using DomainDrivenDesign.Practices.Domain.Products;
using DomainDrivenDesign.Practices.Domain.Shared;
using DomainDrivenDesign.Practices.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Practices.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext, IunitOfWork 
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DDDUdemyDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        public DbSet<User> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderLine> orderLines { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Name).HasConversion(name => name.Value, value => new Name(value));
            modelBuilder.Entity<User>()
                .Property(p => p.Email).HasConversion(email => email.Value, value => new Email(value));
            modelBuilder.Entity<User>()
                .Property(p => p.Password).HasConversion(password => password.Value, value => new Password(value));
            modelBuilder.Entity<User>()
                .OwnsOne(u => u.Address);

            modelBuilder.Entity<Category>()
              .Property(c => c.Name).HasConversion(name => name.Value, value => new Name(value));


            modelBuilder.Entity<Order>()
                .Property(o => o.Status).HasConversion(
                    status => status.ToString(),
                    value => (OrderStatusEnum)Enum.Parse(typeof(OrderStatusEnum), value));


            modelBuilder.Entity<Product>()
                .Property(p => p.Name).HasConversion(name => name.Value, value => new Name(value));
            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, moneyBuilder =>
                {
                    moneyBuilder
                    .Property(m => m.Amount)
                    .HasColumnType("money");

                    moneyBuilder
                    .Property(m => m.Currency)
                    .HasConversion(
                            currency => currency.Code,
                            value => Currency.FromCode(value));
                });

            modelBuilder.Entity<OrderLine>()
                .OwnsOne(ol => ol.Price, moneyBuilder =>
                {
                    moneyBuilder
                    .Property(m => m.Amount)
                    .HasColumnType("money");

                    moneyBuilder
                    .Property(m => m.Currency)
                    .HasConversion(
                            currency => currency.Code,
                            value => Currency.FromCode(value));
                });




        }
    }
}
