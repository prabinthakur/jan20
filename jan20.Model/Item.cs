using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Model
{
	public class Item
	{
		public int Id { get; set; }

		[StringLength(100)]
		public string Name { get; set; }

		[Precision(10,2)]
		public decimal price { get; set; }


		[Precision(10, 2)]
		public decimal discount { get; set; }
		public bool isDiscount {  get; set; }
		public bool isPublished { get; set; }
		public string ImageURl {  get; set; }	
		public bool showInHomepage {  get; set; }
	
		public string? Desciption { get; set; }

		public int? ShopId { get; set; }
		public virtual ShopModel Shop { get; set; }



        

	}
}
