using jan20.Model;
using jan20.Services.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jan20.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        private readonly IReg _ireg;
        public RegisterController(IReg ireg)
        {
         
            _ireg = ireg;
        }

        public ActionResult SignUp(SignUpModel model)
        {
            _ireg.SignUp(model);
            return View();
        }
            

        public ActionResult Index()
        {
            return View(_ireg.GetAll());
        }

        // GET: RegisterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegisterController/Create
        public ActionResult Create()
        {

           
            return View();
        }

        // POST: RegisterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,RegisterModel reg)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _ireg.Create(reg);
                   
                    

                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Edit/5
        public ActionResult Edit(int id)
        {

          
            return View(_ireg.getBYID(id));
        }

        /*
         login action (){
            check for valid login->services
            get login user information->services
            create claimsprinciple-controller
            call context.signin function with claimprinciple

        }
         */
        // POST: RegisterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RegisterModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ireg.Update(collection);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegisterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_ireg.getBYID(id));
        }

        // POST: RegisterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _ireg.Delete(id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
