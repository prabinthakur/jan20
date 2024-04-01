using jan20.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services.Iservices
{
    public interface IloginService
    {

       ( RegisterModel user,bool status) CheckLogin(Login md);
    }
}
