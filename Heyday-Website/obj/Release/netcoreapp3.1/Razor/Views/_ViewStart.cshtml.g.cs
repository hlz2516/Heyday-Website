#pragma checksum "D:\MyProject\Heyday-Website\Heyday-Website\Views\_ViewStart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eda30d384db6e30cc192c7ed89e8950476dd89c5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views__ViewStart), @"mvc.1.0.view", @"/Views/_ViewStart.cshtml")]
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
#line 2 "D:\MyProject\Heyday-Website\Heyday-Website\Views\_ViewImports.cshtml"
using Heyday_Website.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eda30d384db6e30cc192c7ed89e8950476dd89c5", @"/Views/_ViewStart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed3150bbcd11dd7e2d49fe5a4f8045899aa7e3ff", @"/Views/_ViewImports.cshtml")]
    public class Views__ViewStart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!--这个注入有点牛逼-->\r\n");
#nullable restore
#line 3 "D:\MyProject\Heyday-Website\Heyday-Website\Views\_ViewStart.cshtml"
  
    if(Context.User != null)
    {
        var user = await userManager.GetUserAsync(Context.User);
        if(user != null)
            ViewBag.UserName = user.UserName;
        if (user == null)
        {
            Layout = "~/Views/Shared/_Layout.cshtml";
        }
        else if (await userManager.IsInRoleAsync(user, "Root"))
        {
            Layout = "~/Views/Shared/Root_Layout.cshtml";
        }
        else if (await userManager.IsInRoleAsync(user, "Admin"))
        {
            Layout = "~/Views/Shared/Admin_Layout.cshtml";
        }
        else if (await userManager.IsInRoleAsync(user, "NormalUser"))
        {
            Layout = "~/Views/Shared/NormalUser_Layout.cshtml";
        }
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Identity.UserManager<Heyday_Website.Models.ApplicationUser> userManager { get; private set; }
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