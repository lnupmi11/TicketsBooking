#pragma checksum "D:\Навчання\TicketsBooking\TicketsBooking\Views\Ticket\Home.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0c8f2f8f171f66f1cdeafb8548d83bbd743e1f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ticket_Home), @"mvc.1.0.view", @"/Views/Ticket/Home.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ticket/Home.cshtml", typeof(AspNetCore.Views_Ticket_Home))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0c8f2f8f171f66f1cdeafb8548d83bbd743e1f2", @"/Views/Ticket/Home.cshtml")]
    public class Views_Ticket_Home : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/main.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/icon/user-default.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("header_buttons-login--avatar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\Навчання\TicketsBooking\TicketsBooking\Views\Ticket\Home.cshtml"
  
    ViewData["Title"] = "Home";

#line default
#line hidden
            BeginContext(40, 45, true);
            WriteLiteral("<link rel=\"stylesheet\" href=\"css/main.css\">\r\n");
            EndContext();
            BeginContext(85, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b247dbcd896469ab61deaad08a26448", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(125, 148, true);
            WriteLiteral("\r\n<title>Home</title>\r\n\r\n<header class=\"header\">\r\n    <div class=\"container\">\r\n        <a class=\"header_logotype active\" href=\"/\">\r\n            WG\r\n");
            EndContext();
            BeginContext(414, 944, true);
            WriteLiteral(@"        </a>
        <nav class=""header_menu"">
            <div class=""header_burger"">
                <div class=""header_burger_item""></div>
            </div>
            <ul class=""header_menu-list"">
                <li class=""header_menu-item"">
                    <a class=""header_menu-item--link"" href=""#"">Tickets</a>
                </li>
                <li class=""header_menu-item"">
                    <a class=""header_menu-item--link"" href=""#"">Specials</a>
                </li>
                <li class=""header_menu-item"">
                    <a class=""header_menu-item--link"" href=""#"">Companies</a>
                </li>
                <li class=""header_menu-item"">
                    <a class=""header_menu-item--link"" href=""#"">About</a>
                </li>
            </ul>
        </nav>
        <div class=""header_buttons"">
            <a class=""header_buttons-login"" href=""/signin"">
                ");
            EndContext();
            BeginContext(1358, 83, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e93882aa8150428fa81774545dcbb3aa", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1441, 3196, true);
            WriteLiteral(@"
                <span>login</span>
            </a>
        </div>
    </div>
</header>
<div class=""home-page"">
    <div class=""container main_block"">
        <h1 class=""main_block-header1"">WeGo</h1>
        <h2 class=""main_block-header2"">Unleash the traveler inside you</h2>

        <form class=""form_tickets-wrapper tickets"">
            <div class=""form_tickets-block"">
                <div class=""form_tickets-group"">
                    <input type=""text""
                           class=""form_tickets-group-input""
                           name=""from""
                           placeholder=""From"">
                </div>
                <button class=""form_tickets-group-change"">
                    <img src=""img/icon/repeat.svg""/>
                </button>
                <div class=""form_tickets-group"">
                    <input type=""text""
                           class=""form_tickets-group-input""
                           name=""to""
                           placeholder=""To""");
            WriteLiteral(@">
                </div>

                <div class=""form_tickets-group"">
                    <input type=""date""
                           class=""form_tickets-group-input""
                           name=""date""
                           placeholder=""Date"">
                </div>

                <div class=""form_tickets-group validation "">
                    <input type=""number""
                           class=""form_tickets-group-input""
                           name=""count""
                           placeholder=""Tickets count"">
                </div>
                <button class=""form_tickets-group-button"">Search now</button>
            </div>

        </form>

    </div>
</div>
<footer class=""footer"">
    <div class=""container footer-wrapper"">
        <div class="" main_block-header1 footer-logotype"">
            WeGo
        </div>
        <div class=""footer-menu"">
            <div class=""footer-title"">Links</div>
            <nav class=""footer-menu-nav"">
            ");
            WriteLiteral(@"    <ul>
                    <li>
                        <a href=""#"">Tickets</a>
                    </li>
                    <li>
                        <a href=""#"">Special</a>
                    </li>
                    <li>
                        <a href=""#"">Companies</a>
                    </li>
                    <li>
                        <a href=""#"">About</a>
                    </li>
                </ul>
            </nav>
        </div>
        <div class=""footer-contact"">
            <div class=""footer-title"">Contact</div>
            <div class=""footer-contact-wrapper"">
                <a class=""footer-contact-col-line"" target=""_blank"" href=""tel:+380931234567"">+380931234567</a>
                <a class=""footer-contact-col-line"" target=""_blank"" href=""test@gmail.com"">test@gmail.com</a>

            </div>
        </div>
        <div class=""footer-socials"">
            <div class=""footer-title"">Socials</div>
            <div class=""footer-socials-wrapper"">
       ");
            WriteLiteral("         <a href=\"#\" title=\"Facebook\"\r\n                   class=\"footer-socials-item\"\r\n                   target=\"_blank\">\r\n");
            EndContext();
            BeginContext(4727, 112, true);
            WriteLiteral("                </a>\r\n                <a href=\"#\" title=\"Twitter\" class=\"footer-socials-item\" target=\"_blank\">\r\n");
            EndContext();
            BeginContext(4928, 114, true);
            WriteLiteral("                </a>\r\n                <a href=\"#\" title=\"Instagram\" class=\"footer-socials-item\" target=\"_blank\">\r\n");
            EndContext();
            BeginContext(5131, 79, true);
            WriteLiteral("                </a>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</footer>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
