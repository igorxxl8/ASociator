#pragma checksum "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e791d9df886cd2007f3e2454ea3efb421a77bc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_SearchUserFilterPartial), @"mvc.1.0.view", @"/Views/Shared/SearchUserFilterPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/SearchUserFilterPartial.cshtml", typeof(AspNetCore.Views_Shared_SearchUserFilterPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e791d9df886cd2007f3e2454ea3efb421a77bc0", @"/Views/Shared/SearchUserFilterPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3eb65a07f3c77d23cae6743a8e1987d7211ab415", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_SearchUserFilterPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UsersListViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml"
  
    ViewData["Title"] = "SearchUserFilterPartial";

#line default
#line hidden
            BeginContext(88, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(90, 956, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4f93dceef7314ab382bbecd6bd57d7a5", async() => {
                BeginContext(109, 99, true);
                WriteLiteral("\r\n    <div class=\"form-group\">\r\n        <label class=\"control-label\">First name: </label>\r\n        ");
                EndContext();
                BeginContext(209, 91, false);
#line 10 "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml"
   Write(Html.TextBox("FirstName", Model.FirstName, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(300, 70, true);
                WriteLiteral("\r\n\r\n        <label class=\"control-label\">Last name: </label>\r\n        ");
                EndContext();
                BeginContext(371, 89, false);
#line 13 "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml"
   Write(Html.TextBox("LastName", Model.LastName, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(460, 68, true);
                WriteLiteral("\r\n\r\n        <label class=\"control-label\">Country: </label>\r\n        ");
                EndContext();
                BeginContext(529, 87, false);
#line 16 "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml"
   Write(Html.TextBox("country", Model.Country, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(616, 65, true);
                WriteLiteral("\r\n\r\n        <label class=\"control-label\">City: </label>\r\n        ");
                EndContext();
                BeginContext(682, 81, false);
#line 19 "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml"
   Write(Html.TextBox("city", Model.City, htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(763, 64, true);
                WriteLiteral("\r\n\r\n        <label class=\"control-label\">Sex: </label>\r\n        ");
                EndContext();
                BeginContext(828, 115, false);
#line 22 "D:\5term\IGI\ASociator\ASociator\Views\Shared\SearchUserFilterPartial.cshtml"
   Write(Html.DropDownList("sex", Model.Sex as SelectList,
                htmlAttributes: new { @class = "form-control" }));

#line default
#line hidden
                EndContext();
                BeginContext(943, 96, true);
                WriteLiteral("\r\n        \r\n\r\n\r\n    </div>\r\n    <input type=\"submit\" value=\"Filter\" class=\"btn btn-success\" />\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1046, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UsersListViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
