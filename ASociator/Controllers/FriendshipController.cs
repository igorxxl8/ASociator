using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASociator.Data.Interfaces;
using ASociator.Models;
using ASociator.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;

namespace ASociator.Controllers
{
    public class FriendshipController : Controller
    {
        IUserRepository _usersRepository;
        IFriendshipRepository _friendshipRepository;
        private readonly IStringLocalizer _localizer;
        IMapper _mapper;

        public FriendshipController(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IMapper mapper, IStringLocalizer localizer)
        {
            _usersRepository = userRepository;
            _friendshipRepository = friendshipRepository;
            _localizer = localizer;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Friends()
        {
            var user = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var friendShips = _friendshipRepository.GetUserFriends(user.Id);
            var friendshipsVMs = _mapper.Map <List<FriendshipViewModel>> (friendShips);
            foreach (var f in friendshipsVMs)
            {
                if (f.MeID != user.Id)
                {
                    f.FriendId = f.MeID;
                    f.MeID = user.Id;
                }
                var friendVM = await _usersRepository.GetUserById(f.FriendId);
                f.Friend = _mapper.Map<UsersListItemViewModel>(friendVM);
            }
            return View(friendshipsVMs);
        }

        public async Task<IActionResult> NewFriendship(int id)
        {
            var user = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var myId = user.Id;
            _friendshipRepository.Create(myId, id);
            return RedirectToAction("Friends", "Friendship");
        }

        public IActionResult RemoveFriendship(int id)
        {
            _friendshipRepository.Remove(id);
            return Index();
        }

        public async Task<IActionResult> RemoveFriendshipWithUser(int id)
        {
            var user = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var myId = user.Id;
            _friendshipRepository.RemoveFriendshipIfExists(id, myId);
            return RedirectToAction("Friends", "Friendship");
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