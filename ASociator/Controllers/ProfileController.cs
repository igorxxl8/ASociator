using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASociator.Data;
using ASociator.Data.Interfaces;
using ASociator.Models;
using ASociator.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using static System.Net.Mime.MediaTypeNames;

namespace ASociator.Controllers
{
    public class ProfileController : Controller
    {
        public IConfiguration configuration { get; set; }

        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IStringLocalizer _localizer;

        public ProfileController(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IConfiguration config, IStringLocalizer localizer)
        {
            configuration = config;
            _userRepository = userRepository;
            _localizer = localizer;
            _friendshipRepository = friendshipRepository;
        }

        public IActionResult Search(string FirstName, string LastName, string Sex, string Country, string City)
        {
            var users = _userRepository.Users;
            users = users.Where(u => u.Email != User.Identity.Name);
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

        public async Task<IActionResult> Page(int id)
        {
            var iam = await _userRepository.GetUserByEmail(User.Identity.Name);
            var myId = iam.Id;
            if (id != myId)
            {
                var user = await _userRepository.GetUserById(id);
                bool isFriends = _friendshipRepository.GetFriendshipIfExists(id, myId) != null;
                var page = new UserProfileViewModel(user, isFriends);
                return View(page);
            }
            return await MyPage();
        }

        public async Task<IActionResult> MyPage()
        {
            var user = await _userRepository.GetUserByEmail(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            
            return View(new UserProfileViewModel(user, false));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,FirstName,LastName, BirdthDay, Sex, Country, City")] User user, IFormFile avatar)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (avatar != null)
                    {
                        if (avatar.Length > 0)
                        {
                            byte[] imageBytes = null;
                            using (var fsi = avatar.OpenReadStream())
                            {
                                using (var msi = new MemoryStream())
                                {
                                    fsi.CopyTo(msi);
                                    imageBytes = msi.ToArray();
                                }
                            }
                            user.Avatar = imageBytes;
                        }
                    }
                    else
                    {
                    }


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
                result.ViewData["ÄddFriend"] = _localizer["ÄddFriend"];
                result.ViewData["RemoveFriend"] = _localizer["RemoveFriend"];
                result.ViewData["Edit"] = _localizer["Edit"];
                result.ViewData["Save"] = _localizer["Save"];
                result.ViewData["Cancel"] = _localizer["Cancel"];
            }
        }
    }
}