using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASociator.Data;
using ASociator.Data.Interfaces;
using ASociator.Models;
using ASociator.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ASociator.Controllers
{
    public class ProfileController : Controller
    {
        public IConfiguration configuration { get; set; }
        private readonly IUserRepository _userRepository;

        public ProfileController(IUserRepository userRepository, IConfiguration config)
        {
            configuration = config;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> MyPage()
        {
            var user = await _userRepository.GetUserByEmail(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            
            return View(new ProfileViewModel(user));
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
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,FirstName,LastName, Birdthday, Country, City")] User user)
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
                return RedirectToAction(nameof(MyPage));
            }
            return View(user);
        }

        private bool UserExists(int id)
        {
            return _userRepository.IsExists(id);
        }
    }
}