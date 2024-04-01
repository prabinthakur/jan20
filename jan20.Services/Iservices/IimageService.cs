using jan20.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace jan20.Services.Iservices
{
    public interface IimageService
    {
        int create(Items_Image img);
        List<Items_Image> listofImages();

        Items_Image GetImage(int id);

        int RemoveImage(int id);
        Items_Image Update(Items_Image img);
       //Dictionary<int,string> ItemId();

    }
}
