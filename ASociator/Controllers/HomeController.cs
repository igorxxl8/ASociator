using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASociator.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace ASociator.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; set; }
        private readonly IStringLocalizer _localizer;

        public HomeController(IConfiguration config, IStringLocalizer localizer)
        {
            Configuration = config;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                result.ViewData["admin_email"] = Configuration["admin_email"];
                result.ViewData["Dialog"] = _localizer["Dialog"];
                result.ViewData["Remove"] = _localizer["Remove"];
                result.ViewData["View"] = _localizer["View"];
                result.ViewData["ÄddFriend"] = _localizer["AddFriend"];
                result.ViewData["RemoveFriend"] = _localizer["RemoveFriend"];
            }
        }

    }
}
