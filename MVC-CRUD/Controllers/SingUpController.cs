using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class SingUpController : Controller
    {
        private readonly CompanyContext _db;

        public SingUpController(CompanyContext db)
        {
            _db = db;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostSingUpData(UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                var insert = new UserTable
                {
                    UserAccount = userTable.UserAccount,
                    UserPassword = userTable.UserPassword,
                    UserName = userTable.UserName,
                    UserSingupTime = DateTime.Now
                };
                _db.UserTables.Add(insert);
                _db.SaveChanges();
                return RedirectToAction("Index", "HOME");
            }
            return View(userTable);
        }
    }
}
