using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;

namespace MVC_CRUD.Controllers
{
    public class LoginController : Controller
    {
        private readonly CompanyContext _db;

        public LoginController(CompanyContext db)
        {
            _db = db;
        }

        public IActionResult Login()
        {
            var res = new UserTable()
            {
                UserAccount = "MuMu",
                UserName = "QQ"
            };
            return View(res);
        }
    }
}
