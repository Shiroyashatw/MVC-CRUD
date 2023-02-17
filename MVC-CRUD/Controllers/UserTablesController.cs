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
    public class UserTablesController : Controller
    {
        private readonly CompanyContext _db;

        public UserTablesController(CompanyContext context)
        {
            _db = context;
        }

        // GET: UserTables
        public async Task<IActionResult> Index()
        {
              return View(await _db.UserTables.ToListAsync());
        }
        [HttpGet]
        public ActionResult GetAllUserData()
        {
            return View();
        }
        // GET: UserTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.UserTables == null)
            {
                return NotFound();
            }

            var userTable = await _db.UserTables
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // GET: UserTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserAccount,UserPassword,UserName,UserSingupTime")] UserTable userTable)
        {
            if (ModelState.IsValid)
            {
                _db.Add(userTable);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userTable);
        }

        // GET: UserTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.UserTables == null)
            {
                return NotFound();
            }

            var userTable = await _db.UserTables.FindAsync(id);
            if (userTable == null)
            {
                return NotFound();
            }
            return View(userTable);
        }

        // POST: UserTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserAccount,UserPassword,UserName,UserSingupTime")] UserTable userTable)
        {
            if (id != userTable.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(userTable);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTableExists(userTable.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userTable);
        }

        // GET: UserTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.UserTables == null)
            {
                return NotFound();
            }

            var userTable = await _db.UserTables
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (userTable == null)
            {
                return NotFound();
            }

            return View(userTable);
        }

        // POST: UserTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.UserTables == null)
            {
                return Problem("Entity set 'CompanyContext.UserTables'  is null.");
            }
            var userTable = await _db.UserTables.FindAsync(id);
            if (userTable != null)
            {
                _db.UserTables.Remove(userTable);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserTableExists(int id)
        {
          return _db.UserTables.Any(e => e.UserId == id);
        }
    }
}
