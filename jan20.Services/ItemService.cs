using jan20.Model;
using jan20.Services.Iservices;
using Jan20.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services
{

    public class ItemService : IItemService
    {
        private readonly AppDb _db;


        public ItemService(AppDb db)
        {
            _db = db;
        }


        public int AddItem(Item item)
        {

            _db.items.Add(item);
            _db.SaveChanges();
            int result = _db.SaveChanges();
            return result;

        }

        public int DeleteItem(int Id)
        {
            var result = _db.items.Where(u => u.Id == Id).FirstOrDefault();
            _db.items.Remove(result);
            int i = _db.SaveChanges();

            return i;
        }

        public Item GetItem(int id)
        {
            Item? it = _db.items.FirstOrDefault(u => u.Id == id);
            return it;
        }

        public List<Item> GetItems(int shopId)
        {
            List<Item> lst = _db.items.Where(x => x.ShopId == shopId).ToList();
            return lst;
        }

        public bool isPublished(int itemId, bool ispublished)
        {
            var itemresult = _db.items.Where(u => u.Id == itemId && u.isPublished == ispublished).FirstOrDefault();
            if (ispublished == true)
            {
                itemresult.isPublished = false;

            }
            _db.items.Update(itemresult);
            _db.SaveChanges();
            return itemresult.isPublished;




        }

        public bool ShowInHomePage(int itemId, bool hideShow)
        {
            var itemresult = _db.items.Where(u => u.Id == itemId).FirstOrDefault();
            if (hideShow == true)
            {
                itemresult.isPublished = false;

            }
            _db.items.Update(itemresult);
            _db.SaveChanges();
            return itemresult.isPublished;
        }

        public int UpdateItem(Item obj)
        {
            Item itm = _db.items.Where(u => u.Id == obj.Id).FirstOrDefault();
            _db.items.Update(itm);
            _db.SaveChanges();
            return itm.Id;
        }
    }
}
