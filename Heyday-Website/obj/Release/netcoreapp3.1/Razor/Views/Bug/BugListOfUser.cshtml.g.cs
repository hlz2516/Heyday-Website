#pragma checksum "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e39722cabea438a8b7d2262347c51a11c52ff0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bug_BugListOfUser), @"mvc.1.0.view", @"/Views/Bug/BugListOfUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e39722cabea438a8b7d2262347c51a11c52ff0a", @"/Views/Bug/BugListOfUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed3150bbcd11dd7e2d49fe5a4f8045899aa7e3ff", @"/Views/_ViewImports.cshtml")]
    public class Views_Bug_BugListOfUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Heyday_Website.Models.Bug>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BugState_pending.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BugState_reject.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BugState_processing.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BugState_throwback.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BugState_delivered.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/BugState_solved.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Bug", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditMySubmitBug", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        var curBugId;
        window.onload = function () {
            var btns = document.getElementsByClassName('list-group-item');
            for (var i = 0; i < btns.length; i++) {
                var jbtn = $(btns[i]);
                jbtn.click(function () {
                    curBugId = $(this).find('#thisId').get(0).innerText;
                    //console.log(curBugId);
                    $('#bugId').get(0).value = curBugId;
                    $.getJSON(""/Bug/GetTitleAndDetail?bugId="" + curBugId, function (data, status) {
                        if (status == ""success"") {
                            //alert(data[""title""] + "","" + data[""detail""] + "","" + data[""state""]);
                            $('#title').get(0).value = data[""title""];
                            $('#detail').get(0).innerText = data[""detail""];
                            var state = data[""state""];
                            //状态为2，5：三个按钮均失效
                            if (state == 2 || state == 5");
                WriteLiteral(@") {
                                $(""#success"").attr(""disabled"", true);
                                $(""#sbmBtn"").attr(""disabled"", true);
                                $(""#dltBtn"").attr(""disabled"", true);
                            }
                            //状态0，1：可编辑，删除，已解决按钮失效
                            else if (state == 0 || state == 1) {
                                $(""#success"").attr(""disabled"", true);
                                $(""#sbmBtn"").attr(""disabled"", false);
                                $(""#dltBtn"").attr(""disabled"", false);
                            }
                            //状态3：不可编辑，可删除，不可点击已解决
                            else if (state == 3) {
                                $(""#success"").attr(""disabled"", true);
                                $(""#sbmBtn"").attr(""disabled"", true);
                                $(""#dltBtn"").attr(""disabled"", false);
                            }
                            //状态4：不可编辑，删除，可点击已解决
                  ");
                WriteLiteral(@"          else if (state == 4) {
                                $(""#success"").attr(""disabled"", false);
                                $(""#sbmBtn"").attr(""disabled"", true);
                                $(""#dltBtn"").attr(""disabled"", true);
                            }

                        }
                    })
                })
            }
            //给删除按钮绑定事件
            $('#dltBtn').click(function () {
                var id = $('#bugId').get(0).value;
                $.get(""/Bug/DeleteMyBug?bugId="" + id, function (data, status) {
                    if (status == ""success"") {
                        if (data == ""OK"") {
                            //alert(""删除成功，请重新刷新页面"");
                            $('button[name=' + id + ']').remove();
                            $(""#success"").attr(""disabled"", true);
                            $(""#sbmBtn"").attr(""disabled"", true);
                            $(""#dltBtn"").attr(""disabled"", true);
                            $('#title').g");
                WriteLiteral(@"et(0).value = """";
                            $('#detail').get(0).innerText = """";
                        }
                    }
                });
            })

            //给已解决按钮绑定事件
            $('#success').click(function () {
                $.get(""/Bug/ChangeStateToSolved?bugId="" + curBugId);
                //alert(""已解决"");
                $(""#success"").attr(""disabled"", true);
            })

            //ajax提交表单
            $('#form1').submit(function () {
                if ($(this).valid()) {
                    $.ajax({
                        url: this.action,
                        type: this.method,
                        data: $(this).serialize(),
                        dataType: String,
                        success: function (data, result) {

                        },
                        error: function (result) {
                            alert(""提交失败！请联系管理员"");
                        }
                    });
                }
                ");
                WriteLiteral("return false;\r\n            });\r\n\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-3 pre-scrollable\" style=\"height:inherit\">\r\n            <div class=\"list-group\">\r\n");
#nullable restore
#line 101 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                 foreach (var bug in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"button\" class=\"list-group-item list-group-item-action text-left\"");
            BeginWriteAttribute("name", " name=\"", 4548, "\"", 4562, 1);
#nullable restore
#line 103 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
WriteAttributeValue("", 4555, bug.Id, 4555, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <span>#");
#nullable restore
#line 104 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                          Write(bug.Id.ToString().Substring(30,6));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                         <span id=\"thisId\" class=\"ml-4\" style=\"display:none\">");
#nullable restore
#line 105 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                                                        Write(bug.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        ");
#nullable restore
#line 106 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                   Write(bug.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"float-right\">\r\n");
#nullable restore
#line 108 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                             switch (bug.BugState)
                            {
                                case Heyday_Website.Models.BugState.pending:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e39722cabea438a8b7d2262347c51a11c52ff0a13778", async() => {
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
            WriteLiteral("\r\n                                    <span>待处理</span>\r\n");
#nullable restore
#line 113 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                    break;
                                case Heyday_Website.Models.BugState.reject:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e39722cabea438a8b7d2262347c51a11c52ff0a15199", async() => {
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
            WriteLiteral("\r\n                                    <span>已拒绝</span>\r\n");
#nullable restore
#line 117 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                    break;
                                case Heyday_Website.Models.BugState.processing:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e39722cabea438a8b7d2262347c51a11c52ff0a16624", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <span>处理中</span>\r\n");
#nullable restore
#line 121 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                    break;
                                case Heyday_Website.Models.BugState.throwback:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e39722cabea438a8b7d2262347c51a11c52ff0a18048", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <span>抛回</span>\r\n");
#nullable restore
#line 125 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                    break;
                                case Heyday_Website.Models.BugState.delivered:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e39722cabea438a8b7d2262347c51a11c52ff0a19471", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <span>已交付</span>\r\n");
#nullable restore
#line 129 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                    break;
                                case Heyday_Website.Models.BugState.solved:

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e39722cabea438a8b7d2262347c51a11c52ff0a20892", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <span>已解决</span>\r\n");
#nullable restore
#line 133 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                                    break;
                                default:
                                    break;
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </button>\r\n");
#nullable restore
#line 139 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
        <!--默认（所有按钮均无效）
     当Bug状态为处理中(2)，不可编辑，删除，不可点击已解决
     当Bug状态为已解决(5)，不可编辑，删除，不可点击已解决

     当bug状态为待处理(0)，可编辑，删除，不可点击已解决
     当bug状态为已拒绝(1)，可编辑，删除，不可点击已解决

     当bug状态为抛回(3)，不可编辑，可删除，不可点击已解决

     当bug状态为已交付(4)，不可编辑，删除，可点击已解决
    -->
        <div class=""col-9 pl-2"">
            <div class=""card"">
                <div class=""card-header text-center"">
                    <h4>Bug编辑</h4>
                </div>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e39722cabea438a8b7d2262347c51a11c52ff0a23073", async() => {
                WriteLiteral(@"
                    <div class=""form-group text-left"">
                        <h5>Bug概述</h5>
                        <input type=""text"" class=""form-control"" id=""title"" name=""bugTitle"">
                        <input type=""hidden"" id=""bugId"" name=""bugId"" />
                    </div>
                    <div class=""form-group text-left"">
                        <h5>详细描述</h5>
                        <textarea class=""form-control"" id=""detail"" rows=""3"" name=""bugDetail""></textarea>
                    </div>
                    <div class=""form-group"">
                        <input type=""hidden"" id=""submitTime"" name=""submitTime""");
                BeginWriteAttribute("value", " value=\"", 7883, "\"", 7904, 1);
#nullable restore
#line 169 "E:\Heyday-Website\Heyday-Website\Views\Bug\BugListOfUser.cshtml"
WriteAttributeValue("", 7891, DateTime.Now, 7891, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
                    </div>
                    <button type=""submit"" class=""btn btn-primary"" id=""sbmBtn"" disabled>Submit</button>
                    <button type=""button"" class=""btn btn-primary"" id=""dltBtn"" disabled>delete</button>
                    <button type=""button"" class=""btn btn-primary"" id=""success"" disabled>经测试，已解决</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Heyday_Website.Models.Bug>> Html { get; private set; }
    }
}
#pragma warning restore 1591
