#pragma checksum "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba6669e5a1f3e33262145c7a952e8185cb9d05d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GroupChat_Setting), @"mvc.1.0.view", @"/Views/GroupChat/Setting.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\_ViewImports.cshtml"
using UniChatApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\_ViewImports.cshtml"
using UniChatApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba6669e5a1f3e33262145c7a952e8185cb9d05d9", @"/Views/GroupChat/Setting.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f8882e37c27f053e7649db748dbd056d6e451ad", @"/Views/_ViewImports.cshtml")]
    public class Views_GroupChat_Setting : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GroupChat>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Box", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GroupChat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("remove btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Destroy", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("destroy btn btn-outline-danger btn-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
  
    ViewData["Title"] = "GroupSetting";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            WriteLiteral(@"
<style>

    * {
        margin: 0;
        padding: 0;
        box-sizing: border-box;
        font-family: monospace, sans-serif;
    }

    body {
        padding-top: 80px;
        padding-left: 2rem;
        padding-right: 2rem;
    }

    .container-fluid {
        padding: 2rem 1rem;
        border-radius: 10px;
        box-shadow: 0 0 5px 1px blue;
    }

    .avatar-box {
        display: flex;
        align-items: center;
        justify-content: center;
    }

    .avatar-box img {
        width: 80px;
        height: 80px;
        object-fit: cover;
        border-radius: 10px;
        box-shadow: 0 0 5px 1px blue;
    }

    .student-board {
        display: flex;
        flex-wrap: wrap;
        gap: .5rem;
        align-items: baseline;
    }

    .student-board > * {
        flex: 1;
        min-width: min(350px, 100%);
    }

    .table td, .table th {
        vertical-align: inherit;
    }

    .btn-control {
        line-height: 100%;
        vertical-align: middle;
    }


</style>

<div ");
            WriteLiteral("class=\"container-fluid\">\n\n    <h1 class=\"text-primary text-center\">Setting for GroupChat</h1>\n    <h4 class=\"text-info text-center\">Subject: ");
#nullable restore
#line 69 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                          Write(ViewBag.RoomChat.Subject.SubjectCode);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 69 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                                                  Write(ViewBag.RoomChat.Subject.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <hr>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba6669e5a1f3e33262145c7a952e8185cb9d05d98366", async() => {
                WriteLiteral("Back");
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
#nullable restore
#line 71 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                     WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
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
            WriteLiteral("\n    <hr>\n    <div class=\"student-board\">\n        <div class=\"group-student-list\">\n            <h4 class=\"text-center text-info\">");
#nullable restore
#line 75 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                         Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
            <table class=""table table-bordered table-sm text-center"">
                <thead class=""bg-info"">
                    <tr>
                        <th>No.</th>
                        <th>Avatar</th>
                        <th>FullName</th>
                        <th>Role</th>
                        <th>Remove</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 87 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                      
                        int index = 0;
                        foreach (GroupManage item in ViewBag.GroupDataList)
                        {
                            index++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>");
#nullable restore
#line 93 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                               Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n                                    <div class=\"avatar-box\">\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 2401, "\"", 2434, 1);
#nullable restore
#line 96 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
WriteAttributeValue("", 2407, item.StudentProfile.Avatar, 2407, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2435, "\"", 2441, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                                    </div>\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 100 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                               Write(item.StudentProfile.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>");
#nullable restore
#line 102 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                               Write(item.RoleText);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>\n");
#nullable restore
#line 104 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                     if (item.RoleText == "Member")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba6669e5a1f3e33262145c7a952e8185cb9d05d914186", async() => {
                WriteLiteral("&rarr;");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "studentName", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 106 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
AddHtmlAttributeValue("", 2921, item.StudentProfile.FullName, 2921, 29, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-GroupManageId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 106 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                                                                                        WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["GroupManageId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-GroupManageId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["GroupManageId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 107 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                    }
                                    else 
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba6669e5a1f3e33262145c7a952e8185cb9d05d917415", async() => {
                WriteLiteral("\n                                            <ion-icon name=\"close-circle-outline\"></ion-icon>\n                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "groupName", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 110 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
AddHtmlAttributeValue("", 3227, Model.Name, 3227, 11, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-GroupChatId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 110 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["GroupChatId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-GroupChatId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["GroupChatId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
#nullable restore
#line 113 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\n                            </tr>\n");
#nullable restore
#line 116 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n            </table>\n        </div>\n        <div class=\"room-student-list\">\n            <h4 class=\"text-center text-secondary\">Students of ");
#nullable restore
#line 122 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                          Write(ViewBag.RoomChat.Class.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
            <table class=""table table-bordered table-sm text-center"">
                <thead class=""bg-primary"">
                    <tr>
                        <th></th>
                        <th>FullName</th>
                        <th>Avatar</th>
                        <th>No.</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 133 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                      
                        index = 0;
                        foreach (StudentProfile item in ViewBag.StudentRestListOfRoom)
                        {
                            index++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n                                <td>\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba6669e5a1f3e33262145c7a952e8185cb9d05d922306", async() => {
                WriteLiteral("\n                                        &larr;\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-GroupChatId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 140 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                                   WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["GroupChatId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-GroupChatId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["GroupChatId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 140 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StudentId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-StudentId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StudentId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                </td>\n                                <td>\n                                    ");
#nullable restore
#line 145 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                               Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </td>\n                                <td>\n                                    <div class=\"avatar-box\">\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 5033, "\"", 5051, 1);
#nullable restore
#line 149 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
WriteAttributeValue("", 5039, item.Avatar, 5039, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 5052, "\"", 5058, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                                    </div>\n                                </td>\n                                <td>");
#nullable restore
#line 152 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                               Write(index);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            </tr>\n");
#nullable restore
#line 154 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\GroupChat\Setting.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
</div>

<script>

    $(document).ready(function(){

        $("".remove"").click(function(e){

            if (!confirm(""Are you sure kick "" + $(this).attr(""studentName"") + "" out your group?""))
            {
                e.preventDefault();
            }

        });

        $("".destroy"").click(function(e){

            if (!confirm(""Do you want to completely cancel your group "" + $(this).attr(""groupName"") + ""?""))
            {
                e.preventDefault();
            }

        })

    })


</script>

");
            WriteLiteral("<script type=\"module\" src=\"https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js\"></script>\n<script nomodule src=\"https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js\"></script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GroupChat> Html { get; private set; }
    }
}
#pragma warning restore 1591
