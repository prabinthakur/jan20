using jan20.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services.Iservices
{
    public interface ICart
    {


        List<Item> listofItem();
        Item GetItemById(int id);
        List<Item> AddtoCart(int itemid);
        List<Item>RemoveFromCart(int id);
        void CheckOut(List<CheckOutModel> id);






    }
}
