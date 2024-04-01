using jan20.Model;
using jan20.Services;
using jan20.Services.Iservices;
using Jan20.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace jan20.Controllers
{
	public class ItemImageController : Controller
	{
		private readonly IimageService _imageService;
		

        public ItemImageController(IimageService imageService)
        {
            _imageService = imageService;
           
        }
        public ActionResult Index()
		{
			var images= _imageService.listofImages();
			
			return View(images);
		}

		// GET: ItemImageController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ItemImageController/Create
		public ActionResult Create()
		{

			//ViewData["ItemId"] = new SelectList(_appDb.items, "Id", "Name");
		
			return View();
		}

		// POST: ItemImageController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Items_Image obj)
		{

			try
			{
				if (ModelState.IsValid)
				{
					_imageService.create(obj);
					return RedirectToAction("Index");


				}


               // ViewData["ItemId"] = new SelectList(_db.items, "Id", "Name");
                return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: ItemImageController/Edit/5
		public ActionResult Edit(int id)
		{
			var ids= _imageService.GetImage(id);
			return View(ids);
		}

		// POST: ItemImageController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Items_Image img)
		{
			try
			{

				if (ModelState.IsValid)
				{
				_imageService.Update(img);
					return RedirectToAction("Index");

				}
                return RedirectToAction("Index");

            }
			catch
			{
				return View();
			}
		}

		// GET: ItemImageController/Delete/5
		public ActionResult Delete(int id)
		{

			var items=_imageService.GetImage(id);

			return View(items);
		}

		// POST: ItemImageController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				_imageService.RemoveImage(id);
				return RedirectToAction("Index");
			}
		
			catch
			{
				return View();
			}
		}



		public SelectList listofItem()
		{

			SelectList sl = new SelectList(_imageService.listofImages(), "Id", "Name");
			return sl;
				
		}
	}
}
