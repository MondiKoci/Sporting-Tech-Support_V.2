#pragma checksum "D:\Code\Term 4\Web\Assignment2Final\Sporting-Tech-Support_V.2\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "92fc25170c2c40a8f39c6a554df9bde3fdb8c821"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\Code\Term 4\Web\Assignment2Final\Sporting-Tech-Support_V.2\Views\_ViewImports.cshtml"
using GBCSporting2021_TheDevelopers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Code\Term 4\Web\Assignment2Final\Sporting-Tech-Support_V.2\Views\_ViewImports.cshtml"
using GBCSporting2021_TheDevelopers.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92fc25170c2c40a8f39c6a554df9bde3fdb8c821", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61e4678161dafe4c34e24b53fc75ed45f686cebe", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Code\Term 4\Web\Assignment2Final\Sporting-Tech-Support_V.2\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Home Page";
    ViewBag.Heading = "SportsPro Technical Support";
    ViewBag.Desc = "Sports management software for the sports enthusiast";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""wrap"">
    <div id=""homeContents"">
        <div class=""container"">
            <div id=""adminMenu"" class=""homeMenu"">
                <h2 class=""subHeading"">Admin</h2>
                <a href=""/products"">Manage Products</a>
                <a href=""/technicians"">Manage Technicians</a>
                <a href=""/customers"">Manage Customers</a>
                <a href=""/incidents"">Manage Incidents</a>
                <a href=""/registrations"">Manage Registrations</a>
            </div>
            <div id=""techniciansMenu"" class=""homeMenu"">
                <h2 class=""subHeading"">Technicians</h2>
                <a href=""/techincident"">Update Incident</a>
            </div>
        </div>
    </div>
</div>

");
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
