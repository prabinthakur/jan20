using jan20.Model;
using jan20.Services.Iservices;
using Jan20.data;
using Jan20.data.Migrations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services
{
	public class LoginService : IloginService
	{

		private readonly AppDb _AppDb;
		public LoginService(AppDb appDb)
		{

			_AppDb = appDb;
		}
		public (RegisterModel user, bool status) CheckLogin(Login md)
		{
			md.Password = GetStringSha256Hash(md.Password);
			var user = _AppDb.register.FirstOrDefault(x => x.Email == md.UserName && x.Password == md.Password);
			return (user, user != null);


		}
		internal static string GetStringSha256Hash(string text)
		{
			if (String.IsNullOrEmpty(text))
				return String.Empty;

			using (var sha = new System.Security.Cryptography.SHA256Managed())
			{
				byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
				byte[] hash = sha.ComputeHash(textData);
				return BitConverter.ToString(hash).Replace("-", String.Empty);
			}
		}



	}
}
