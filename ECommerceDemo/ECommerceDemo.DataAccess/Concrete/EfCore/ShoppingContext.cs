using ECommerceDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDemo.DataAccess.Concrete.EfCore
{
	public class ShoppingContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
		{
			optionsBuilder.UseSqlServer(@"(localdb)\MSSQLLocalDB;Database=ShopDb;integrated security=true");
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}
