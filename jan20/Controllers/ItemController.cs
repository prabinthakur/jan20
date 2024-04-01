using jan20.Common;
using jan20.Model;
using jan20.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jan20.Controllers
{
   
    public class ItemController : Controller
	{
	
		private readonly IItemService _db;

		public IWebHostEnvironment _webHostEnvironment;
        private Mysession _session;

        public ItemController(IItemService Db, IWebHostEnvironment webHost,Mysession session)
		{

			_db = Db;
			_webHostEnvironment = webHost;
			_session= session;

		}

		public IActionResult Index()
		{

			var items = _db.GetItems(_session.ShopId);
			
			
			return View(items);
		}

		[HttpGet]
		public IActionResult Create()
		{

			

			return View();
		}
		[HttpPost]
		public IActionResult Create(Item item, IFormFile file)
		{


			string upload = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

			if (!Directory.Exists(upload))
			{

				Directory.CreateDirectory(upload);

			}
			String filepath = Path.Combine(upload, file.FileName);
			using (var filestream = new FileStream(filepath, FileMode.Create))
			{
				file.CopyTo(filestream);
				item.ImageURl = "/uploads/" + file.FileName;
			}



			if (ModelState.IsValid)
			{

				_db.AddItem(item);

				
				return RedirectToAction("Index");

			}


			return View();

		}




	}
}
