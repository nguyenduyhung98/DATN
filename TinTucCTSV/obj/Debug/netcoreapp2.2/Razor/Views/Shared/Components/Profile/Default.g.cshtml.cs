#pragma checksum "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7cc937a5f5cdda9dd9c26b88589acc493d6d1dee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Profile_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Profile/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Profile/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Profile_Default))]
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
#line 1 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\_ViewImports.cshtml"
using TinTucCTSV;

#line default
#line hidden
#line 2 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\_ViewImports.cshtml"
using TinTucCTSV.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7cc937a5f5cdda9dd9c26b88589acc493d6d1dee", @"/Views/Shared/Components/Profile/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b4af31c441364a59078504488c5833bda85762d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Profile_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TinTucCTSV.Models.Account.ProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default btn-flat"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Account/Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 129, true);
            WriteLiteral("<li class=\"dropdown user user-menu\">\r\n            <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">\r\n              <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 180, "\"", 229, 2);
            WriteAttributeValue("", 186, "\\updated/images/profile/", 186, 24, true);
#line 4 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
WriteAttributeValue("", 210, Model.ImageProfile, 210, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", "  alt=\"", 230, "\"", 248, 1);
#line 4 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
WriteAttributeValue("", 237, Model.Name, 237, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(249, 100, true);
            WriteLiteral(" class=\"rounded-circle img-circle\" width=\"50\" height=\"50\" />\r\n              <span class=\"hidden-xs\">");
            EndContext();
            BeginContext(350, 10, false);
#line 5 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
                                 Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(360, 199, true);
            WriteLiteral("</span>\r\n            </a>\r\n            <ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton\">\r\n              <!-- User image -->\r\n              <li class=\"user-header\">\r\n                <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 559, "\"", 608, 2);
            WriteAttributeValue("", 565, "\\updated/images/profile/", 565, 24, true);
#line 10 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
WriteAttributeValue("", 589, Model.ImageProfile, 589, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(609, 34, true);
            WriteLiteral(" class=\"rounded-circle img-circle\"");
            EndContext();
            BeginWriteAttribute("alt", " alt=\"", 643, "\"", 660, 1);
#line 10 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
WriteAttributeValue("", 649, Model.Name, 649, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(661, 67, true);
            WriteLiteral(" width=\"50\" height=\"50\" />\r\n                <p>\r\n                  ");
            EndContext();
            BeginContext(729, 10, false);
#line 12 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
             Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(739, 27, true);
            WriteLiteral("\r\n                  <small>");
            EndContext();
            BeginContext(767, 13, false);
#line 13 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
                    Write(Model.Created);

#line default
#line hidden
            EndContext();
            BeginContext(780, 223, true);
            WriteLiteral("</small>\r\n                </p>\r\n              </li>\r\n              <!-- Menu Body -->\r\n\r\n              <!-- Menu Footer-->\r\n              <li class=\"user-footer\">\r\n                <div class=\"pull-left\">\r\n                  ");
            EndContext();
            BeginContext(1003, 117, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7cc937a5f5cdda9dd9c26b88589acc493d6d1dee9129", async() => {
                BeginContext(1109, 7, true);
                WriteLiteral("Profile");
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
#line 21 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
                                                                    WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1120, 86, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"pull-right\">\r\n                  ");
            EndContext();
            BeginContext(1206, 267, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7cc937a5f5cdda9dd9c26b88589acc493d6d1dee11881", async() => {
                BeginContext(1356, 110, true);
                WriteLiteral("\r\n                    <button type=\"submit\" class=\"btn btn-default btn-flat\">Logout</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Page = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 24 "D:\Developer\Projects\ForumTinTuc\TinTucCTSV\Views\Shared\Components\Profile\Default.cshtml"
                                                                                                    WriteLiteral(Url.Action("Index", "Home", new { area = "Student" }));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1473, 81, true);
            WriteLiteral("\r\n                </div>\r\n              </li>\r\n            </ul>\r\n          </li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TinTucCTSV.Models.Account.ProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
