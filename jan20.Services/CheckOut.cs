using jan20.Model;
using jan20.Services.Iservices;
using Jan20.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services
{
    public class CheckOut : ICheckOut
    {
        private readonly AppDb _db;

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CheckOutModel> GetAll()
        {
            List<CheckOutModel> ck=_db.checkouts.ToList();
            return ck;
        }

        public CheckOutModel GetByid(int id)
        {
        
          CheckOutModel ck =  _db.checkouts.Find(id);
            return ck;
            

        }

        public CheckOutModel update(CheckOutModel ck)
        {
            throw new Exception();

        }

        public CheckOutModel Create(CheckOutModel ck)
        {
            _db.checkouts.Add(ck);
            _db.SaveChanges();
            return ck;
        }
    }
}
