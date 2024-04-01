using jan20.Model;
using jan20.Services.Iservices;
using Jan20.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services
{
    public class ItemImages : IimageService
	{
		private readonly AppDb _appDb;
		public ItemImages(AppDb _db) {
		
				_appDb = _db;
		}
		public int create(Items_Image img)
		{

			_appDb.images.Add(img);
			int i=_appDb.SaveChanges();
			return i;

		}

        public Items_Image GetImage(int id)
        {
		
			Items_Image img =_appDb.images.Find(id);
			return img;
		
        }

        public SelectList ItemId()
        {
            throw new NotImplementedException();
        }

        public List<Items_Image> listofImages()
        {


			List<Items_Image> lst= _appDb.images.Include(s => s.Item).ToList();

			return lst;

        }

        public int RemoveImage(int id)
        {
			
			_appDb.images.Remove(GetImage(id));
			return _appDb.SaveChanges();
        }

        public Items_Image Update(Items_Image img)
        {
			
			

		 var  items=_appDb.images.Update(img);

			Items_Image obj = GetImage(0);
			return obj;
		
        }

        List<Items_Image> listofGetImages()
		{
			List<Items_Image> its = _appDb.images.Include(u => u.ImageID).ToList();
			return its;
		}

		// Dictionary<int, string> ItemId()
		//{
		//			return new Dictionary<int, string>()
		//			{1,"1"
		//			};
		//}




    }
}
