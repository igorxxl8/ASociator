using ASociator.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace ASociator.Components
{
    public class UserDetailsViewComponent: ViewComponent
    {
        private readonly IStringLocalizer _localizer;

        public UserDetailsViewComponent(IStringLocalizer localizer)
        {
            _localizer = localizer;
        }

        public HtmlContentBuilder Invoke(User user)
        {
            HtmlContentBuilder htmlResult = new HtmlContentBuilder();
            var output = new (string key, string value)[]
            {
                ($"First name", $"{user.FirstName}"),
                ($"Last name", $"{user.LastName}"),
            };

            htmlResult.AppendHtml(@"<table align='left' style='width: 40%; text-align: left; margin-bottom: 30px;'>");

            foreach (var line in output)
            {
                htmlResult.AppendFormat("<tr><td style='text-align: left;'> {0} </td> <td style='text-align: left;'> {1} </td> </tr>", line.key, line.value);
            }

            htmlResult.AppendHtml("<table>");

            return htmlResult;

        }
    }
}
