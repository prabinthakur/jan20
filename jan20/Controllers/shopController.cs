using jan20.Common;
using jan20.Model;
using jan20.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace jan20.Controllers
{
	public class shopController : Controller
	{

		private readonly ICart _cart;

		Mysession _session;

		
        public shopController(ICart cart)
        {
				
			_cart = cart;
        }
        // GET: shopController
        public ActionResult Index()
		{
			List<Item> items=_cart.listofItem();
			return View(items);
		}

		// GET: shopController/Details/5
			

		// GET: shopController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: shopController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(int id)
		{
			try
			{
				


				var item = _session.AddtoCart;
				_session.AddtoCart = item;
				return View(_cart);

			}
			catch
			{
				return View();
			}
		}

		// GET: shopController/Edit/5
		

		// GET: shopController/Delete/5
		public ActionResult Delete(int id)
		{
			var item = _session.AddtoCart.Where(x=>x.Id==id).FirstOrDefault();

			var items = _session.AddtoCart;
			items.Remove(item);
			_session.AddtoCart = items;


			return View("Cart",items);
		}

		// POST: shopController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, List<CheckOutModel> itemid)
		{
			try
			{
				if (ModelState.IsValid)
				{
				_cart.CheckOut(itemid);
					return RedirectToAction(nameof(Index));

				}

				
				return View(itemid);
			}
			catch
			{
				return View();
			}
		}

		public string Serialize(object? value)
		{
			return JsonConvert.SerializeObject(value);
		}
	}
}
