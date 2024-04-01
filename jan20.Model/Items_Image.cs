using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Model
{
	public class Items_Image
	{
		[Key]
		public int ImageID { get; set; }
		public string ImageUrl { get; set; }

        public int ItemId { get; set; }
		[ValidateNever]
        public virtual Item Item { get; set; }
	}
}
