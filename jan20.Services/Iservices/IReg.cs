using jan20.Model;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services.Iservices
{
    public interface IReg
    {
        RegisterModel Create(RegisterModel reg);
        RegisterModel Update(RegisterModel reg);
        int Delete(int id);

        RegisterModel getBYID(int id);
        List<RegisterModel> GetAll();
        SignUpModel SignUp(SignUpModel model);
    }
}
