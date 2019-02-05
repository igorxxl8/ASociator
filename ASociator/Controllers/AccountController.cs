using ASociator.Data;
using ASociator.Data.Interfaces;
using ASociator.Data.Repositories;
using ASociator.Models;
using ASociator.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASociator.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IStringLocalizer _localizer;

        public AccountController(IUserRepository userRepository, IRoleRepository roleRepository, IStringLocalizer stringLocalizer)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _localizer = stringLocalizer;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile avatar)
        {
            if (ModelState.IsValid)
            {
                User user = await _userRepository.GetUserByEmail(model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    if (avatar != null)
                    {
                        if (avatar.Length > 0)
                        {
                            byte[] imageBytes = null;
                            using (var fsi = avatar.OpenReadStream())
                            {
                                using(var msi = new MemoryStream())
                                {
                                    fsi.CopyTo(msi);
                                    imageBytes = msi.ToArray();
                                }
                            }
                            model.Avatar = imageBytes;
                        }
                    }

                    user = new User { Email = model.Email, Password = model.Password, FirstName = model.FirstName, LastName = model.LastName, BirdthDay = model.BirdthDay, Country = model.Country, City = model.City, Sex = model.Sex, Avatar = model.Avatar};
                    UserRole userRole = await _roleRepository.GetRole("user");
                    if (userRole != null)
                        user.Role = userRole;

                    await _userRepository.AddUser(user);
             
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "User with this email already exists!");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userRepository.GetUserByPasswordEmail(model.Password, model.Email);
                if (user != null)
                {
                    await Authenticate(user); 
                    return RedirectToAction("MyPage", "Profile");
                }
                ModelState.AddModelError("", "Incorrect login and(or) password!");
            }
            return View(model);
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        { 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
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
