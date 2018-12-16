using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASociator.Data;
using ASociator.Models;
using Microsoft.Extensions.Configuration;
using ASociator.Data.Interfaces;

namespace ASociator.Controllers
{
    public class AdministrationController : Controller
    {
        public IConfiguration configuration { get; set; }

        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public AdministrationController(IUserRepository userRepository, IRoleRepository roleRepository, IConfiguration config)
        {
            configuration = config;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        // GET: Users
        public IActionResult Index()
        {
            //var applicationContext = _context.Users.Include(u => u.Role);
            var users = _userRepository.Users;
            ViewData["admin_email"] = configuration["admin_email"];
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_roleRepository.Roles, "Id", "Id");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password,FirstName,LastName,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_roleRepository.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_roleRepository.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,FirstName,LastName,RoleId")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await _userRepository.UpdateUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            ViewData["RoleId"] = new SelectList(_roleRepository.Roles, "Id", "Id", user.RoleId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userRepository.GetUserById(id);
            await _userRepository.DeleteUser(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _userRepository.IsExists(id);
        }
    }
}
