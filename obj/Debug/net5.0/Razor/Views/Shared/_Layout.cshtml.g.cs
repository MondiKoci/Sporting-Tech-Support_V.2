#pragma checksum "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efbbe0b323722caeb8dbac1dd0f9587381835957"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#nullable restore
#line 1 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\_ViewImports.cshtml"
using GBCSporting2021_TheDevelopers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\_ViewImports.cshtml"
using GBCSporting2021_TheDevelopers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efbbe0b323722caeb8dbac1dd0f9587381835957", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61e4678161dafe4c34e24b53fc75ed45f686cebe", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/jquery/dist/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/site.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
   
    string ActiveNav(string controller, string action)
    {
        string currentAction = ViewContext.RouteData.Values["Action"].ToString();
        string currentController = ViewContext.RouteData.Values["Controller"].ToString();
        if (controller == currentController && action == currentAction) {
            return "active";
        }
        return "";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efbbe0b323722caeb8dbac1dd0f95873818359575363", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <link rel=""stylesheet"" href=""/css/sportspro.css"">
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"">
    <link href=""https://fonts.googleapis.com/css2?family=Gruppo&display=swap"" rel=""stylesheet"">
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css"">
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/icon?family=Material+Icons"">
    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"">
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"">
    <link href=""https://fonts.googleapis.com/css2?family=Gruppo&display=swap"" rel=""stylesheet"">
    <title> ");
#nullable restore
#line 27 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
       Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
                WriteLiteral(" | SportsPro</title> <!-- CHANGE PAGE TITLE -->\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efbbe0b323722caeb8dbac1dd0f95873818359577551", async() => {
                WriteLiteral(@"
    <div class=""wrap"">
        <header>
            <div class=""container"">
                <div id=""logo"">
                    <img src=""/img/sportsProLogo.png"" alt=""SportsPro"">
                </div>
                <div id=""nav"">
                    <nav>
                        <a");
                BeginWriteAttribute("class", " class=\"", 1667, "\"", 1702, 1);
#nullable restore
#line 38 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1675, ActiveNav("Home", "Index"), 1675, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" href=\"/\">Home</a>\r\n                        <a");
                BeginWriteAttribute("class", " class=\"", 1749, "\"", 1787, 1);
#nullable restore
#line 39 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1757, ActiveNav("Product", "Index"), 1757, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("href=\"/products\">Products</a>\r\n                        <a");
                BeginWriteAttribute("class", " class=\"", 1845, "\"", 1886, 1);
#nullable restore
#line 40 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1853, ActiveNav("Technician", "Index"), 1853, 33, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("href=\"/technicians\">Technicians</a>\r\n                        <a");
                BeginWriteAttribute("class", " class=\"", 1950, "\"", 1989, 1);
#nullable restore
#line 41 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1958, ActiveNav("Customer", "Index"), 1958, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("href=\"/customers\">Customers</a>\r\n                        <a");
                BeginWriteAttribute("class", " class=\"", 2049, "\"", 2088, 1);
#nullable restore
#line 42 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2057, ActiveNav("Incident", "Index"), 2057, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("href=\"/incidents\">Incidents</a>\r\n                        <a");
                BeginWriteAttribute("class", " class=\"", 2148, "\"", 2191, 1);
#nullable restore
#line 43 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2156, ActiveNav("Registration", "Index"), 2156, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" href=\"/registrations\">Registrations</a> <!-- LINK NEEDED -->\r\n                        <a");
                BeginWriteAttribute("class", " class=\"", 2281, "\"", 2316, 1);
#nullable restore
#line 44 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2289, ActiveNav("Home", "About"), 2289, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("href=\"/about\">About</a>\r\n                    </nav>\r\n                </div>\r\n            </div>\r\n        </header>\r\n        <main>\r\n            <div id=\"top\">\r\n                <div class=\"container\">\r\n                    <h1>");
#nullable restore
#line 52 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
                   Write(ViewBag.Heading);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1> <!-- CHANGE HEADING -->\r\n                    <p>");
#nullable restore
#line 53 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
                  Write(ViewBag.Desc);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p> <!-- CHANGE HERE AS WELL -->\r\n                </div>\r\n            </div>\r\n            <div class=\"mainContents\">\r\n                \r\n                <div class=\"container\">\r\n");
#nullable restore
#line 59 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
                     if (TempData["alertMessage"] != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <div");
                BeginWriteAttribute("class", " class=\"", 2910, "\"", 2941, 1);
#nullable restore
#line 61 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 2918, TempData["alertClass"], 2918, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                        <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n                        <strong>");
#nullable restore
#line 63 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
                           Write(TempData["alertMessage"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>.\r\n                    </div>\r\n");
#nullable restore
#line 65 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
#nullable restore
#line 66 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
               Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </main>\r\n    </div>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efbbe0b323722caeb8dbac1dd0f958738183595714557", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efbbe0b323722caeb8dbac1dd0f958738183595715657", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "efbbe0b323722caeb8dbac1dd0f958738183595716757", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 73 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
#nullable restore
#line 74 "C:\OneDrive\OneDrive - George Brown College\Semester IV\Courses\Web Application Development\A2\Views\Shared\_Layout.cshtml"
Write(await RenderSectionAsync("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
