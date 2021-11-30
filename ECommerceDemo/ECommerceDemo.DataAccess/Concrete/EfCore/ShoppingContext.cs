using ECommerceDemo.Entities;
using ECommerceDemo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class ShoppingContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
		{
			optionsBuilder.UseSqlServer("server=AYTUNC-PC\\SQLEXPRESS;database=ECommerceDemo;integrated security=true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) 
		{
			modelBuilder.Entity<OrderItems>().HasKey(x => new { x.OrderId, x.ProductId });
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItems> OrderItems { get; set; }
		public DbSet<Product> Products { get; set; }

	}
}
