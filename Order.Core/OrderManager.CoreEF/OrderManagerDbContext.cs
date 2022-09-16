using System;
using OrderManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Contracts;
using Microsoft.Data.SqlClient.DataClassification;

namespace OrderManager.CoreEF
{
    public class OrderManagerDbContext : DbContext
    {
        public OrderManagerDbContext()
        {
            this.Database.EnsureCreated();
        }

        public OrderManagerDbContext(DbContextOptions<OrderManagerDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Data Source=WINAPRB8MS1MC2O;Initial Catalog=OrderManager;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Client>().ToTable(nameof(Client));

            builder.Entity<Client>().Property(x => x.FirstName)
                .IsRequired()
                .HasColumnType("varchar(100)")
            .HasMaxLength(100);

            builder.Entity<Client>().Property(x => x.LastName)
                .IsRequired()
                .HasColumnType("varchar(100)")
            .HasMaxLength(100);

            builder.Entity<Client>().Property(x => x.CodeClient)
                .IsRequired()
                .HasColumnType("varchar(20)")
            .HasMaxLength(20);
            builder.Entity<Client>().HasIndex(x => x.CodeClient).IsUnique();


            builder.Entity<Order>().ToTable(nameof(Order));

            builder.Entity<Order>().HasKey(x => x.Id);
            builder.Entity<Order>().Property(x => x.Id)
                .IsRequired();

            builder.Entity<Order>().Property(x => x.OrderDate)
                .IsRequired()
                .HasColumnType("date");
              
            builder.Entity<Order>().HasIndex(x => x.OrderCode).IsUnique();
            builder.Entity<Order>().Property(x => x.OrderCode)
                .IsRequired()
                .HasColumnType("char(5)");

            builder.Entity<Order>().HasOne(x => x.Client)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ClientId);

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}




        
