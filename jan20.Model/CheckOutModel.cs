using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Model
{
    public class CheckOutModel
    {


        public int Id { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public  string ? companyname { get; set; }
        public string? address { get; set; }
        [EmailAddress]

        public string Email { get; set; }

        public string phone { get; init; }

        public string notes { get; set; }

        [Column(TypeName ="Decimal(10,2)")]
        public float amount { get; set; }




    }
}
