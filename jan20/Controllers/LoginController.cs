using jan20.Common;
using jan20.Model;
using jan20.Services.Iservices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Claims;

namespace jan20.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {




        private readonly IloginService _loginService;

        Mysession _session;
        public LoginController(IloginService loginService, Mysession session)
        {

            _loginService = loginService;
            _session = session;
        }


        public IActionResult Login()

        {
            return View();
        }

        [AllowAnonymous]

        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = _loginService.CheckLogin(model);
                if (result.status)
                {
                    HttpContext.Session.SetString("UserName", result.user.Name);
                    _session.ShopId = result.user.ShopId ?? 0;
                    HttpContext.Response.Cookies.Append("mycookies", "prabin,brijesh,aasish");

                    addClaims(model);

                    //sininmanager->identity
                    //success
                    return RedirectToAction("Index", "Item");
                }


            }
            else
            {
                ModelState.AddModelError("Password doesnot mathch", "password doesnot match");
            }
            return View();
        }

        public void addClaims(Login model)
        {

            var claims = new List<Claim>()
            {

                new Claim(ClaimTypes.Email,model.UserName),
                new Claim("Usernmae",model.UserName),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"User")






            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
            HttpContext.SignInAsync(claimsPrinciple);



        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("login", "login");
        }



    }
}
