#pragma checksum "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9be03b625a50c9fe84a1e369a94863d732893fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Friendship_Friends), @"mvc.1.0.view", @"/Views/Friendship/Friends.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Friendship/Friends.cshtml", typeof(AspNetCore.Views_Friendship_Friends))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\5term\IGI\ASociator\ASociator\Views\_ViewImports.cshtml"
using ASociator;

#line default
#line hidden
#line 2 "D:\5term\IGI\ASociator\ASociator\Views\_ViewImports.cshtml"
using ASociator.Models;

#line default
#line hidden
#line 3 "D:\5term\IGI\ASociator\ASociator\Views\_ViewImports.cshtml"
using ASociator.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9be03b625a50c9fe84a1e369a94863d732893fc", @"/Views/Friendship/Friends.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3eb65a07f3c77d23cae6743a8e1987d7211ab415", @"/Views/_ViewImports.cshtml")]
    public class Views_Friendship_Friends : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ASociator.ViewModels.FriendshipViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Page", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
  
    ViewData["Title"] = ViewData["Friends"];
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(155, 108, true);
            WriteLiteral("\r\n<style>\r\n    .users-list {\r\n        list-style-type: none;\r\n        padding: 0px;\r\n    }\r\n</style>\r\n\r\n<h2>");
            EndContext();
            BeginContext(264, 19, false);
#line 14 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
Write(ViewData["Friends"]);

#line default
#line hidden
            EndContext();
            BeginContext(283, 4, true);
            WriteLiteral(" <i>");
            EndContext();
            BeginContext(288, 11, false);
#line 14 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
                       Write(Model.Count);

#line default
#line hidden
            EndContext();
            BeginContext(299, 38, true);
            WriteLiteral("</i></h2>\r\n\r\n<ul class=\"users-list\">\r\n");
            EndContext();
#line 17 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
     for (int i = 0; i < Model.Count; i++)
    {

#line default
#line hidden
            BeginContext(388, 28, true);
            WriteLiteral("        <li data-friend-id=\"");
            EndContext();
            BeginContext(417, 17, false);
#line 19 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
                       Write(Model[i].FriendId);

#line default
#line hidden
            EndContext();
            BeginContext(434, 11, true);
            WriteLiteral("\" data-id=\"");
            EndContext();
            BeginContext(446, 11, false);
#line 19 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
                                                    Write(Model[i].ID);

#line default
#line hidden
            EndContext();
            BeginContext(457, 16, true);
            WriteLiteral("\">\r\n            ");
            EndContext();
            BeginContext(473, 174, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "394c7d947b79421982c86c63e5db69f3", async() => {
                BeginContext(553, 18, true);
                WriteLiteral("\r\n                ");
                EndContext();
                BeginContext(572, 57, false);
#line 21 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
           Write(await Html.PartialAsync("FriendPartial", Model[i].Friend));

#line default
#line hidden
                EndContext();
                BeginContext(629, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 20 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
                                                            WriteLiteral(Model[i].FriendId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(647, 17, true);
            WriteLiteral("\r\n        </li>\r\n");
            EndContext();
#line 24 "D:\5term\IGI\ASociator\ASociator\Views\Friendship\Friends.cshtml"
    }

#line default
#line hidden
            BeginContext(671, 5, true);
            WriteLiteral("</ul>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ASociator.ViewModels.FriendshipViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
