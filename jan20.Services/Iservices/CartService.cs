using jan20.Model;
using Jan20.data;
using Jan20.data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services.Iservices
{
	public class CartService : ICart
	{
		private readonly AppDb _appDb;


		


		public CartService(AppDb appDb) {
		
			_appDb = appDb;
			
		}

		public List<Item> cartitems = new List<Item>();
		public List<Item> AddtoCart(int itemid)
		{


			var item=_appDb.items.Find(itemid);
			if (item!=null)
			{
				cartitems.Add(item);


			}
			return cartitems;



		}

		public void CheckOut(List<CheckOutModel> id)
		{


			var itemscheckout = _appDb.checkouts.Where(item => item.Id == item.Id).ToList();
			_appDb.checkouts.RemoveRange(itemscheckout);
			_appDb.SaveChanges();

		}

		public Item GetItemById(int id)
		{
			return _appDb.items.Find(id);
		}

		public List<Item> listofItem()
		{
			return _appDb.items.ToList();
		}

		public List<Item> RemoveFromCart(int id)
		{
			var itemtoremove = cartitems.FirstOrDefault(u => u.Id == id);

			if (itemtoremove!=null)
			{
				cartitems.Remove(itemtoremove);


			}
			return cartitems;
		}
	}
}
