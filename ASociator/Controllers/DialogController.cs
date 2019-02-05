using ASociator.Data.Interfaces;
using ASociator.Models;
using ASociator.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Controllers
{
    public class DialogController : Controller
    {
        IUserRepository _usersRepository;
        IDialogRepository _dialogRepository;
        IMessageRepository _messageRepository;
        private readonly IStringLocalizer _localizer;
        IMapper _mapper;

        public DialogController(IUserRepository userRepository, IDialogRepository dialogRepository, IMessageRepository messageRepository, IMapper mapper, IStringLocalizer localizer)
        {
            _messageRepository = messageRepository;
            _dialogRepository = dialogRepository;
            _usersRepository = userRepository;
            _localizer = localizer;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var iam = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var myId = iam.Id;
            _dialogRepository.GetUserDialogs(myId);
            return View(_dialogRepository.GetUserDialogs(myId));
        }

        public async Task<IActionResult> NewDialog(int id)
        {
            var iam = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var myId = iam.Id;
            var existingDialog = _dialogRepository.GetDialogBetweenUsersIfExists(myId, id);
            if (existingDialog != null)
                return await Dialog(existingDialog.ID);

            var newDialog = new Dialog
            {
                InitiatorID = myId,
                AddresseeID = id,
                DialogName = "Dialog",
            };

            _dialogRepository.CreateDialog(newDialog);
            return await Dialog(newDialog.ID);
        }

        public async Task<IActionResult> NewMessage(int id, MessageViewModel newMessage)
        {
            var iam = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var myId = iam.Id;

            newMessage.DateSent = DateTime.Now;
            newMessage.AuthorID = myId;
            newMessage.ID = 0;
            _messageRepository.SendMessage(_mapper.Map<Message>(newMessage));
            return await Dialog(id);
        }

        public IActionResult RemoveDialog(int id)
        {
            _dialogRepository.RemoveDialog(id);
            return RedirectToAction("Index", "Dialog");
        }

        public async Task<IActionResult> Dialog(int id)
        {
            var iam = await _usersRepository.GetUserByEmail(User.Identity.Name);
            var myId = iam.Id;
            var dialog = _dialogRepository.GetDialogWithMessages(id);
            var messageVMs = _mapper.Map<List<MessageViewModel>>(dialog.Messages)
                                    .OrderBy(m => m.DateSent)
                                    .ToList();

            int addresseeID = (dialog.AddresseeID.Value == myId) ? dialog.InitiatorID.Value : dialog.AddresseeID.Value;
            string addressee = "";

            if (dialog.AddresseeID.Value == myId)
            {
                addresseeID = dialog.InitiatorID.Value;
                addressee = dialog.Initiator.FirstName;
            }
            else
            {
                addresseeID = dialog.AddresseeID.Value;
                addressee = dialog.Addressee.FirstName;
            }

            var dialogViewModel = new DialogViewModel
            {
                ID = id,
                Messages = messageVMs,
                AddresseeID = addresseeID,
                Addressee = addressee,
                MyID = myId,
                Me = User.Identity.Name
            };

            return View("Dialog", dialogViewModel);
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
                result.ViewData["Send"] = _localizer["Send"];
                result.ViewData["DialogWith"] = _localizer["DialogWith"];
                result.ViewData["Messages"] = _localizer["Messages"];
            }
        }
    }
}