using ECommerceDemo.Entities;
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
			modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.CategoryId, x.ProductId });
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
