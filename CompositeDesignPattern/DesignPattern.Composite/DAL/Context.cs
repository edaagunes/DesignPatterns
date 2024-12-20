using Microsoft.EntityFrameworkCore;

namespace DesignPattern.Composite.DAL
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-3OD251U\\SQLEXPRESS;initial catalog=DesignPattern7;integrated security=true;");
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories{ get; set; }
	}
}
