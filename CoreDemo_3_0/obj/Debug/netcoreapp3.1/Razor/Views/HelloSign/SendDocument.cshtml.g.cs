#pragma checksum "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a2eb2a5f3b5adbefca3a7c472ed4b4513a6d20b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HelloSign_SendDocument), @"mvc.1.0.view", @"/Views/HelloSign/SendDocument.cshtml")]
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
#line 1 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\_ViewImports.cshtml"
using CoreDemo_3_0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\_ViewImports.cshtml"
using CoreDemo_3_0.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a2eb2a5f3b5adbefca3a7c472ed4b4513a6d20b", @"/Views/HelloSign/SendDocument.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b826296d5e66143aa8b9930040ce78e55a77b578", @"/Views/_ViewImports.cshtml")]
    public class Views_HelloSign_SendDocument : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoreDemo_3_0.Models.SendDocumentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
  
    ViewData["Title"] = "SendDocument";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
 using (Html.BeginForm(null, null, FormMethod.Post, new { enctype = "multipart/form-data" }))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"panel panel-primary col-md-6\">\r\n        <div class=\"panel-heading\">Send For Sign</div>\r\n        <div class=\"panel-body\">\r\n            <div class=\"form-horizontal\">\r\n                <hr />\r\n                ");
#nullable restore
#line 13 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 15 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
               Write(Html.LabelFor(model => model.Form.Subject, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 17 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.EditorFor(model => model.Form.Subject, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 18 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Form.Subject, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 23 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
               Write(Html.LabelFor(model => model.Form.Message, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 25 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.EditorFor(model => model.Form.Message, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 26 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Form.Message, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 31 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
               Write(Html.LabelFor(model => model.Form.SignerEmail, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 33 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.EditorFor(model => model.Form.SignerEmail, new { htmlAttributes = new { @class = "form-control", type = "email" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 34 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Form.SignerEmail, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 39 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
               Write(Html.LabelFor(model => model.Form.SignerName, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 41 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.EditorFor(model => model.Form.SignerName, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 42 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Form.SignerName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 46 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
               Write(Html.LabelFor(model => model.Form.File, htmlAttributes: new { @class = "control-label col-md-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        <input type=\"file\" name=\"Form.File\" class=\"form-control\" />\r\n                        ");
#nullable restore
#line 49 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
                   Write(Html.ValidationMessageFor(model => model.Form.File, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>

                <div class=""form-group"">
                    <div class=""col-md-offset-2 col-md-10"">
                        <input type=""submit"" value=""Create"" class=""btn btn-default"" />
                    </div>
                </div>
            </div>
            </div>
        </div>
");
#nullable restore
#line 61 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\HelloSign\SendDocument.cshtml"
        
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoreDemo_3_0.Models.SendDocumentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591