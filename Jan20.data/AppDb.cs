using jan20.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Jan20.data
{
	public class AppDb : DbContext
	{
		public AppDb(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Item> items { get; set; }
		public DbSet<Items_Image>images { get; set; }

		public DbSet<CheckOutModel> checkouts { get; set; }

		public DbSet<RegisterModel> register { get; set; }
        public DbSet<Login> logins { get; set; }


		public DbSet<Cart> cart { get; set; }
        public DbSet<ShopModel> shop { get; set; }
    }
}
