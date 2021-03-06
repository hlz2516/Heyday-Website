#pragma checksum "E:\Heyday-Website\Heyday-Website\Views\Article\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16d3a16ea3b3e312605366004210933fc8fcadfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Article_Show), @"mvc.1.0.view", @"/Views/Article/Show.cshtml")]
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
#line 2 "E:\Heyday-Website\Heyday-Website\Views\_ViewImports.cshtml"
using Heyday_Website.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16d3a16ea3b3e312605366004210933fc8fcadfd", @"/Views/Article/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed3150bbcd11dd7e2d49fe5a4f8045899aa7e3ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Article_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Heyday_Website.ViewModels.ShowArticle>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/marked/marked.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("csses", async() => {
                WriteLiteral(" \r\n    <style>\r\n        .db-content {\r\n            order: 1;\r\n        }\r\n\r\n        .bd-bd-toc {\r\n            position: sticky;\r\n            top: 4rem;\r\n            height: calc(100vh-4rem);\r\n            overflow-y: auto;\r\n        }\r\n    </style>\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "16d3a16ea3b3e312605366004210933fc8fcadfd3799", async() => {
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
                WriteLiteral("\r\n    <script>\r\n        window.onload = function () {\r\n            //raw可以防止传过来的字符串转义\r\n            var text = \'");
#nullable restore
#line 23 "E:\Heyday-Website\Heyday-Website\Views\Article\Show.cshtml"
                   Write(Html.Raw(Model.Content));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n            //console.log(text);\r\n            $(\'#content\').html(marked(text));\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral(@"
<div class=""container-fluid"">
    <div class=""row flex-xl-nowarp"">
        <div class=""col-12 col-md-3 col-xl-2 bd-sidebar bg-dark""></div>
        <main class=""col-12 col-md-9 col-xl-8 py-md-3 pl-md-5 bd-content bg-white"" role=""main"">
            <p class=""h2 text-center"">");
#nullable restore
#line 34 "E:\Heyday-Website\Heyday-Website\Views\Article\Show.cshtml"
                                 Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"text-left\" id=\"content\">\r\n                \r\n            </div>\r\n            <br>\r\n            <br>\r\n            <div class=\"text-right\">\r\n                edit by ");
#nullable restore
#line 41 "E:\Heyday-Website\Heyday-Website\Views\Article\Show.cshtml"
                   Write(Model.AuthorName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br>\r\n                ");
#nullable restore
#line 43 "E:\Heyday-Website\Heyday-Website\Views\Article\Show.cshtml"
           Write(Model.PublishTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </main>\r\n        <div class=\"d-none d-xl-block col-xl-2 bd-toc bg-dark\"></div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Heyday_Website.ViewModels.ShowArticle> Html { get; private set; }
    }
}
#pragma warning restore 1591
