#pragma checksum "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64959e199426aa6f52d8d4626b0c91b508591a0f"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64959e199426aa6f52d8d4626b0c91b508591a0f", @"/Views/Class/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f8882e37c27f053e7649db748dbd056d6e451ad", @"/Views/_ViewImports.cshtml")]
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
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
  
    ViewData["Title"] = "Edit - Class";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.11.3/css/jquery.dataTables.css\">\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "64959e199426aa6f52d8d4626b0c91b508591a0f5565", async() => {
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
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "64959e199426aa6f52d8d4626b0c91b508591a0f6678", async() => {
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
            WriteLiteral("\n\n<div class=\"container\">\n    <div class=\"text-center\">\n    <h1 class=\"text-primary\">Class Management</h1>\n    <h4 class=\"text-info\">Edit for class ");
#nullable restore
#line 14 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                                    Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    <hr>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "64959e199426aa6f52d8d4626b0c91b508591a0f8224", async() => {
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
    </div>
    
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
#line 35 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                     foreach (StudentProfile item in ViewBag.students)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 1323, "\"", 1336, 1);
#nullable restore
#line 37 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 1328, item.Id, 1328, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                            <td>");
#nullable restore
#line 38 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.StudentCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>\n                                <img class=\"avatar\"");
            BeginWriteAttribute("src", " src=\"", 1478, "\"", 1496, 1);
#nullable restore
#line 40 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 1484, item.Avatar, 1484, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1497, "\"", 1503, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                            </td>\n                            <td>");
#nullable restore
#line 42 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 43 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.Major);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>\n                                <span command=\"Add\"");
            BeginWriteAttribute("obj", " obj=\"", 1725, "\"", 1739, 1);
#nullable restore
#line 45 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 1731, item.Id, 1731, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\">Add</span>\n                            </td>\n                        </tr>\n");
#nullable restore
#line 48 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\n            </table>\n        </div>\n\n        <div class=\"student-class\">\n            <h5 class=\"text-center text-info\">List of students of ");
#nullable restore
#line 54 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
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
#line 66 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                     foreach (StudentProfile item in Model.StudentProfiles)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\n                            <td>");
#nullable restore
#line 69 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.StudentCode);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>\n                                <img class=\"avatar\"");
            BeginWriteAttribute("src", " src=\"", 2756, "\"", 2774, 1);
#nullable restore
#line 71 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 2762, item.Avatar, 2762, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2775, "\"", 2781, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                            </td>\n                            <td>");
#nullable restore
#line 73 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>");
#nullable restore
#line 74 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
                           Write(item.Major);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                            <td>\n                                <span command=\"Remove\"");
            BeginWriteAttribute("obj", " obj=\"", 3006, "\"", 3020, 1);
#nullable restore
#line 76 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
WriteAttributeValue("", 3012, item.Id, 3012, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\">Remove</span>\n                            </td>\n                        </tr>\n");
#nullable restore
#line 79 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
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
                    url: '/Class/AddStudent/',
       ");
            WriteLiteral("             type: \'POST\',\n                    data: { stId: studentId, classId: ");
#nullable restore
#line 125 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
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
#line 148 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
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
                WriteLiteral("\n    <script type=\"text/javascript\" charset=\"utf8\" src=\"https://cdn.datatables.net/1.11.3/js/jquery.dataTables.js\"></script>\n");
#nullable restore
#line 176 "C:\Users\PhucHT\Downloads\UniChat\UniChat\UniChatApplication\Views\Class\Edit.cshtml"
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
