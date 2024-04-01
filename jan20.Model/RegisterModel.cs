using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Model
{
    public class RegisterModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string CommparePassword { get; set; }



        public int? ShopId { get; set; }
        public virtual ShopModel Shop { get; set; }



    }
}
