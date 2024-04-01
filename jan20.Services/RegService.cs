using jan20.Model;
using jan20.Services.Iservices;
using Jan20.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jan20.Services
{
    public class RegService : IReg
    {


        private readonly AppDb _db;
        public RegService(AppDb db)
        {

            _db = db;
        }
        public RegisterModel Create(RegisterModel reg)
        {
            reg.Password = GetStringSha256Hash(reg.Password);
            _db.register.Add(reg);
            _db.SaveChanges();
            return reg;
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
        public int Delete(int id)
        {



            _db.register.Remove(getBYID(id));
            int i = _db.SaveChanges();
            return i;





        }

        public List<RegisterModel> GetAll()
        {
            List<RegisterModel> reg = _db.register.ToList();
            return reg;
        }

        public RegisterModel getBYID(int id)
        {
            return _db.register.Find(id);

        }

        public RegisterModel Update(RegisterModel reg)
        {
            _db.register.Update(reg);
            _db.SaveChanges();
            return reg;

        }

        public SignUpModel SignUp(SignUpModel model)
        {
            //starting transaction
            _db.Database.BeginTransaction();
            try
            {
                ShopModel shop = new ShopModel()
                {
                    Address = model.Address,
                    Description = model.Description,
                    Id = model.Id,
                    Name = model.Name

                };

                _db.shop.Add(shop);
                var result = _db.SaveChanges();
                if (result > 0)
                {
                    RegisterModel registerModel = new RegisterModel()
                    {
                        Name = model.UserName,
                        Id = model.Id,
                        Email = model.Email,
                        Password = model.Password,
                        ShopId = shop.Id,
                        CommparePassword = model.CommparePassword,


                    };
                    _db.Add(registerModel);
                    var regResult = _db.SaveChanges();
                    if (regResult > 0)
                        _db.Database.CommitTransaction();
                    else _db.Database.RollbackTransaction();
                }
                else _db.Database.RollbackTransaction();
            }
            catch (Exception ex)
            {

                _db.Database.RollbackTransaction();
            }

            finally
            {
               
            }
            return model;

        }
    }
}
