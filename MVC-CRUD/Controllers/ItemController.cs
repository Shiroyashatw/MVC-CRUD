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
    public class ItemController : Controller
    {
        private readonly CompanyContext _db;

        public ItemController(CompanyContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var res = from i in _db.ItemTables
                      select i;
            List<ItemTable> data = res.ToList();
            return View(data);
        }
        // 新增資料的頁面
        public ActionResult Insert()
        {
            return View();
        }
        // 接受新增資料的Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(ItemTable items)
        {
            if (ModelState.IsValid)
            {
                var insert = new ItemTable
                {
                    ItemName = items.ItemName,
                    ItemInsertTime = DateTime.Now
                };
                _db.ItemTables.Add(insert);
                _db.SaveChanges();
                return Redirect("/Item/Index");
            }
            return Redirect("/Item/Index");
        }
        // 編輯畫面
        public ActionResult Edit(int? id)
        {
            var res = (from i in _db.ItemTables
                       where i.ItemId == id
                       select i
                       ).FirstOrDefault();
            if(res == null) return View("Index");
            return View(res);
        }
        // 編輯送出更新
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ItemTable items)
        {
            var res = _db.ItemTables.Find(items.ItemId);

            res.ItemName = items.ItemName;
            _db.SaveChanges();

            return Redirect("/Item/Index");
        }
        public ActionResult Delete(int? id)
        {
            var res = (from i in _db.ItemTables
                       where i.ItemId == id
                       select i
                       ).FirstOrDefault();
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int itemId)
        {
            var res = _db.ItemTables.Find(itemId);
            _db.ItemTables.Remove(res);
            _db.SaveChanges();
            return Redirect("/Item/Index");
        }
    }
}
