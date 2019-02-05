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
using ASociator.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASociator.Controllers
{
    public class AdministrationController : Controller
    {
        public IConfiguration configuration { get; set; }

        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IStringLocalizer _localizer;

        public AdministrationController(IUserRepository userRepository, IRoleRepository roleRepository, IFriendshipRepository friendshipRepository, IConfiguration config, IStringLocalizer localizer)
        {
            configuration = config;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _localizer = localizer;
            _friendshipRepository = friendshipRepository;
        }

        // GET: Users
        public IActionResult Index(string FirstName, string LastName, string Sex, string Country, string City)
        {
            var users = _userRepository.Users;
            ViewData["admin_email"] = configuration["admin_email"];

            if (!string.IsNullOrEmpty(FirstName))
            {
                users = users.Where(u => u.FirstName.Contains(FirstName));
            }


            if (!string.IsNullOrEmpty(LastName))
            {
                users = users.Where(u => u.LastName.Contains(LastName));
            }

            if (!string.IsNullOrEmpty(Country))
            {
                users = users.Where(u => u.Country.Contains(Country));
            }

            if (!string.IsNullOrEmpty(City))
            {
                users = users.Where(u => u.City.Contains(City));
            }

            if (!string.IsNullOrEmpty(Sex) && Sex != "All")
            {
                users = users.Where(u => u.Sex == Sex);
            }

            List<string> genders = new List<string>()
            {
                new string("All"),
                new string("Male"),
                new string("Female")
            };

            var userVMs = new List<UserProfileViewModel>();
            var iam = _userRepository.GetUserByEmail(User.Identity.Name).Result;
            var myId = iam.Id;
            foreach (var user in users.ToList())
            {
                bool isFriends = _friendshipRepository.GetFriendshipIfExists(user.Id, myId) != null;
                userVMs.Add(new UserProfileViewModel(user, isFriends));
            }

            UsersListViewModel viewModel = new UsersListViewModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Users = userVMs,
                Sex = new SelectList(genders),
                City = City,
                Country = Country
            };
            return View(viewModel);
        }

        public IActionResult Messages()
        {
            return View();
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

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            var result = context.Result as ViewResult;
            if (result != null)
            {
                result.ViewData["Title"] = _localizer["Header"];
                result.ViewData["Home"] = _localizer["Home"];
                result.ViewData["Friends"] = _localizer["Friends"];
                result.ViewData["Dialogs"] = _localizer["Dialogs"];
                result.ViewData["Search"] = _localizer["Search"];
                result.ViewData["Logout"] = _localizer["Logout"];
                result.ViewData["Login"] = _localizer["Login"];
                result.ViewData["Register"] = _localizer["Register"];
                result.ViewData["Dialog"] = _localizer["Dialog"];
                result.ViewData["Remove"] = _localizer["Remove"];
                result.ViewData["View"] = _localizer["View"];
                result.ViewData["ÄddFriend"] = _localizer["AddFriend"];
                result.ViewData["RemoveFriend"] = _localizer["RemoveFriend"];
            }
        }
    }
}
