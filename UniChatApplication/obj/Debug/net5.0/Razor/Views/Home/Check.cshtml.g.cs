#pragma checksum "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Home\Check.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cd229a7fe11ed0c6256a05e5fab4e5bd9648648"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Check), @"mvc.1.0.view", @"/Views/Home/Check.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cd229a7fe11ed0c6256a05e5fab4e5bd9648648", @"/Views/Home/Check.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"117675200237a5f49f8acab2be1560d50c609162", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Check : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<UniChatApplication.Models.AdminProfile>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Check Page</h2>\r\n\r\n<div class=\"container d-flex flex-column\" style=\"gap: 1rem\">\r\n\r\n    <div class=\"box\">\r\n        <h4>Account list</h4>\r\n        <ol>\r\n");
#nullable restore
#line 10 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Home\Check.cshtml"
             foreach(var profile in Model)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Home\Check.cshtml"
           Write(profile.FullName);

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\PhucHT\Desktop\UniChatWeb\UniChatApplication\Views\Home\Check.cshtml"
                                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<UniChatApplication.Models.AdminProfile>> Html { get; private set; }
    }
}
#pragma warning restore 1591