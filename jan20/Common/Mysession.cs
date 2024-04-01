using jan20.Model;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;

namespace jan20.Common
{
	public class Mysession
	{

		IHttpContextAccessor _httpContextAccessor;
		public Mysession(IHttpContextAccessor httpContextAccessor) {


			_httpContextAccessor = httpContextAccessor;
		}

        public int ShopId { get { return _httpContextAccessor.HttpContext?.Session.GetInt32("ShopId")??0; }

            set
            {
                _httpContextAccessor.HttpContext?.Session.SetInt32("ShopId",(value));




            }


        }


        public List<Item> AddtoCart
		{
			
			get
			{

				var cartItems= new List<Item>();
		
				var ItemInSession = _httpContextAccessor.HttpContext?.Session.GetString("AddtoCart");
				if (ItemInSession != null)
				{
					cartItems = JsonConvert.DeserializeObject<List<Item>>(ItemInSession) ?? new List<Item>();
				}

				return cartItems;
			}

			set
			{
				_httpContextAccessor.HttpContext.Session.SetString("AddtoCart", Serialize(value));


					

			}
			



			

		
		}

		private string Serialize(object? value)
		{
			return JsonConvert.SerializeObject(value);

		}

	
	}
}
