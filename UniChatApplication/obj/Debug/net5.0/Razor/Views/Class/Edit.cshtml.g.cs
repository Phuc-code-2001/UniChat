#pragma checksum "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa52cb96be81e8d8e040aff98b54e192bdc6fa22"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Class_Edit), @"mvc.1.0.view", @"/Views/Class/Edit.cshtml")]
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
#line 1 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\_ViewImports.cshtml"
using UniChatApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\_ViewImports.cshtml"
using UniChatApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\_ViewImports.cshtml"
using System;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa52cb96be81e8d8e040aff98b54e192bdc6fa22", @"/Views/Class/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"549e0f71a3f10529379e72fd7551066208bb08e7", @"/Views/_ViewImports.cshtml")]
    public class Views_Class_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UniChatApplication.Models.Class>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/cssPlus/buttonPlus.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/ClassManagement/StyleEdit.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("button-3 text-white text-decoration-none"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
  
    ViewData["Title"] = "Edit - Class";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.11.3/css/jquery.dataTables.css\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aa52cb96be81e8d8e040aff98b54e192bdc6fa225538", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aa52cb96be81e8d8e040aff98b54e192bdc6fa226653", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n    <h1 class=\"text-center text-primary\">Class Management</h1>\r\n    <h4 class=\"text-center text-info\">Edit for class ");
#nullable restore
#line 13 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                                                Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa52cb96be81e8d8e040aff98b54e192bdc6fa228207", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    <hr>
    <div class=""students"">
        <div class=""student-list"">
            <h5 class=""text-center text-success"">List of students of UniChat System</h5>
            <table class=""table table-bordered"" id=""student-list"">
                <thead class=""bg-success text-white"">
                    <tr>
                        <th>RollNo</th>
                        <th>Avatar</th>
                        <th>FullName</th>
                        <th>Major</th>
                        <th>Operation</th>
                    </tr>
                </thead>
                <tbody id=""tbody-list"">

");
#nullable restore
#line 32 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                     foreach (StudentProfile item in ViewBag.students)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 1334, "\"", 1347, 1);
#nullable restore
#line 34 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 1339, item.Id, 1339, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>");
#nullable restore
#line 35 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.StudentCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <img class=\"avatar\"");
            BeginWriteAttribute("src", " src=\"", 1492, "\"", 1510, 1);
#nullable restore
#line 37 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 1498, item.Avatar, 1498, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1511, "\"", 1517, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 39 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.Major);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <span command=\"Add\"");
            BeginWriteAttribute("obj", " obj=\"", 1744, "\"", 1758, 1);
#nullable restore
#line 42 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 1750, item.Id, 1750, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\">Add</span>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 45 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n        <div class=\"student-class\">\r\n            <h5 class=\"text-center text-info\">List of students of ");
#nullable restore
#line 51 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                                                             Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
            <table class=""table table-bordered"" id=""student-class"">
                <thead class=""bg-info text-white"">
                    <tr>
                        <th>RollNo</th>
                        <th>Avatar</th>
                        <th>FullName</th>
                        <th>Major</th>
                        <th>Operation</th>
                    </tr>
                </thead>
                <tbody id=""tbody-class"">
");
#nullable restore
#line 63 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                     foreach (StudentProfile item in Model.StudentProfiles)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 66 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.StudentCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <img class=\"avatar\"");
            BeginWriteAttribute("src", " src=\"", 2801, "\"", 2819, 1);
#nullable restore
#line 68 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 2807, item.Avatar, 2807, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2820, "\"", 2826, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 70 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 71 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.Major);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <span command=\"Remove\"");
            BeginWriteAttribute("obj", " obj=\"", 3056, "\"", 3070, 1);
#nullable restore
#line 73 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 3062, item.Id, 3062, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\">Remove</span>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 76 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>
    <hr>

</div>

<script>

    $(document).ready(function () {

        $('#student-list').DataTable({
            ""language"": {
                ""lengthMenu"": ""_MENU_"",
                ""zeroRecords"": ""No data matching"",
                ""info"": ""_PAGE_/_PAGES_"",
                ""infoEmpty"": """",
                ""infoFiltered"": """"
            }
        });

        $('#student-class').DataTable({
            ""language"": {
                ""lengthMenu"": ""_MENU_"",
                ""zeroRecords"": ""No data matching"",
                ""info"": ""_PAGE_/_PAGES_"",
                ""infoEmpty"": """",
                ""infoFiltered"": """"
            }
        });



        $(""td span"").click(function () {

            let span = $(this);
            let studentId = $(this).attr(""obj"");
            let row = $(this).parents(""tr"");

            if (span.attr(""command"") == ""Add"") {

                $.ajax({
           ");
            WriteLiteral("         url: \'/Class/AddStudent/\',\r\n                    type: \'POST\',\r\n                    data: { stId: studentId, classId: ");
#nullable restore
#line 122 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                                                 Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" },
                    success: function (data, textStatus, xhr) {

                        span.attr(""command"", ""Remove"");
                        span.attr(""class"", ""btn btn-danger btn-sm"");
                        span.text(""Remove"");
                        row.clone().appendTo($(""#tbody-class""));
                        row.remove();
                        console.log(""AddStudent Success!"");
                        location.reload();
                    },
                    error: function (jqXhr, textStatus, errorMessage) {

                        console.log(""AddStudent Failed!"");
                    }
                });

            }
            else if (span.attr(""command"") == ""Remove"") {

                $.ajax({
                    url: '/Class/RemoveStudent/',
                    type: 'POST',
                    data: { stId: studentId, classId: ");
#nullable restore
#line 145 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
                                                 Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" },
                    success: function (data, textStatus, xhr) {

                        span.attr(""command"", ""Add"");
                        span.attr(""class"", ""btn btn-primary btn-sm"");
                        span.text(""Add"");
                        row.clone().appendTo($(""#tbody-list""));
                        row.remove();
                        $("".dataTables_empty"").remove();

                        console.log(""RemoveStudent Success!"");
                        location.reload();
                    },
                    error: function (jqXhr, textStatus, errorMessage) {

                        console.log(""RemoveStudent Failed!"");
                    }
                });
            }

        });

    });

</script>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\" charset=\"utf8\" src=\"https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js\"></script>\r\n");
#nullable restore
#line 173 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Class\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UniChatApplication.Models.Class> Html { get; private set; }
    }
}
#pragma warning restore 1591
