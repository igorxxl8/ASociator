using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ASociator.Localization
{
    public class CustomStringLocalizer : IStringLocalizer
    {
        Dictionary<string, Dictionary<string, string>> resources;
        const string HEADER = "Header";
        const string HOME = "Home";
        const string FRIENDS = "Friends";
        const string DIALOGS = "Dialogs";
        const string SEARCH = "Search";
        const string LOGOUT = "Logout";
        const string LOGIN = "Login";
        const string REGISTER = "Register";
        const string DIALOG = "Dialog";
        const string REMOVE = "Remove";
        const string VIEW = "View";
        const string ADD_FRIEND = "ÄddFriend";
        const string REMOVE_FRIEND = "RemoveFriend";
        const string EDIT = "Edit";
        const string SAVE = "Save";
        const string CANCEL = "Cancel";
        const string SEND = "Send";
        const string MESSAGES = "Messages";
        const string DIALOG_WITH = "DialogWith";

        public CustomStringLocalizer()
        {
            Dictionary<string, string> enDict = new Dictionary<string, string>
            {
                {HEADER, "Home page" },
                {HOME, "Home" },
                {FRIENDS, "Friends" },
                {DIALOGS, "Dialogs" },
                {SEARCH, "Search" },
                {LOGOUT, "Log out" },
                {LOGIN, "Log in" },
                {REGISTER, "Register" },
                {DIALOG, "Dialog" },
                {REMOVE, "Remove" },
                {VIEW, "View" },
                {ADD_FRIEND, "Add Friend" },
                {REMOVE_FRIEND, "Remove Friend" },
                {EDIT, "Edit" },
                {SAVE, "Save" },
                {CANCEL, "Cancel" },
                {SEND, "Send" },
                {MESSAGES, "Messages" },
                {DIALOG_WITH, "Dialog with" }



            };
            // словарь для русского языка
            Dictionary<string, string> ruDict = new Dictionary<string, string>
            {
                {HEADER, "Домашняя страница" },
                {HOME, "Домой" },
                {FRIENDS, "Друзья" },
                {DIALOGS, "Диалоги" },
                {SEARCH, "Поиск" },
                {LOGOUT, "Выйти" },
                {LOGIN, "Войти" },
                {REGISTER, "Зарегестрироваться" },
                {DIALOG, "Диалог" },
                {REMOVE, "Удалить" },
                {VIEW, "Посмотреть" },
                {ADD_FRIEND, "Добавить в друзья" },
                {REMOVE_FRIEND, "Удалить из друзей" },
                {EDIT, "Редактировать" },
                {SAVE, "Сохранить" },
                {CANCEL, "Отмена" },
                {SEND, "Отправить" },
                {MESSAGES, "Сообщения" },
                {DIALOG_WITH, "Диалог с" }
            };

            resources = new Dictionary<string, Dictionary<string, string>>
            {
                {"en", enDict },
                {"ru", ruDict }
            };
        }

        public LocalizedString this[string name]
        {
            get
            {
                var currentCulture = CultureInfo.CurrentUICulture;
                string val = "";
                if (resources.ContainsKey(currentCulture.Name))
                {
                    if (resources[currentCulture.Name].ContainsKey(name))
                    {
                        val = resources[currentCulture.Name][name];
                    }
                }
                return new LocalizedString(name, val);
            }
        }

        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}
