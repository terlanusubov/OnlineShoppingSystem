#pragma checksum "D:\Desktop\GagiStoreSystem\GagiStoreSystem\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9bd6f8a3496e2eef4cf35095359a76dd0630b16"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9bd6f8a3496e2eef4cf35095359a76dd0630b16", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"466183dd0aa8dfff09b1927153bd7e22b596755d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GagiStoreSystem.Infrastructure.Models.HomeM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"breadcrumb\">\n    <ul>\n        <li><a");
            BeginWriteAttribute("href", " href=\"", 99, "\"", 133, 1);
#nullable restore
#line 4 "D:\Desktop\GagiStoreSystem\GagiStoreSystem\Views\Home\Index.cshtml"
WriteAttributeValue("", 106, Url.Action("Index","Home"), 106, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Ana səhifə</a></li>
    </ul>
</div>
<div class=""separator-breadcrumb border-top""></div>
<div class=""col-md-4"">
    <div class=""card card-icon-big mb-4"">
        <div class=""card-body text-center"">
            <i class=""i-Data-Upload""></i>
            <p class=""text-muted mt-2 mb-2"">Post olunan məhsullar</p>
            <p class=""lead text-18 mt-2 mb-0"">");
#nullable restore
#line 13 "D:\Desktop\GagiStoreSystem\GagiStoreSystem\Views\Home\Index.cshtml"
                                         Write(Model.TotalPostedProducts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        </div>\n    </div>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GagiStoreSystem.Infrastructure.Models.HomeM> Html { get; private set; }
    }
}
#pragma warning restore 1591
