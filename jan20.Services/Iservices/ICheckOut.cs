using jan20.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services.Iservices
{
    public interface ICheckOut
    {

        List<CheckOutModel> GetAll();
        CheckOutModel GetByid(int id);

        int Delete(int id);

        CheckOutModel update(CheckOutModel ck);

        CheckOutModel Create(CheckOutModel ck);


       
        
       



       



      

      

        
      
       
       
        

    }
}
