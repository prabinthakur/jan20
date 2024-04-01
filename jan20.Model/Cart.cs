using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Model
{
	public class Cart
	{
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }

		[Column(TypeName ="decimal(10,2)")]
		public float  Rate { get; set; }
		[Column(TypeName = "decimal(10,2)")]
		public float amount { get; set; }

		public virtual Item Item { get; set; }

      

		
		
	}

	
}
