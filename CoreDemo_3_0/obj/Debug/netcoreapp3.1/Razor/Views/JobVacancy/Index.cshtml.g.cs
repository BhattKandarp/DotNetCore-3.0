#pragma checksum "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccbb88c841a6310aa36ab7ffac7b7734dddf1fa8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JobVacancy_Index), @"mvc.1.0.view", @"/Views/JobVacancy/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccbb88c841a6310aa36ab7ffac7b7734dddf1fa8", @"/Views/JobVacancy/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b826296d5e66143aa8b9930040ce78e55a77b578", @"/Views/_ViewImports.cshtml")]
    public class Views_JobVacancy_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CoreDemo_3_0.Entities.JobVacancy>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
  
    ViewData["Title"] = "Department List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<a href=""/Department/ManageDepartment"" class=""btn btn-primary"">Add</a>
<br />
<table id=""_DataTable"" class=""table compact table-striped table-bordered nowrap dataTable"" aria-describedby=""_DataTable_info"">
    <thead>
        <tr role=""row"">

            <th class=""sorting_asc"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-sort=""ascending"" aria-label=""Image: activate to sort column descending"" style=""width: 127px;"">Vacancy</th>
            <th class=""sorting"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-label=""Title: activate to sort column ascending"" style=""width: 209px;"">Department</th>
            <th class=""sorting"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-label=""City: activate to sort column ascending"" style=""width: 116px;"">NOF Postion</th>
            <th class=""sorting"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-labe");
            WriteLiteral(@"l=""Vacancy: activate to sort column ascending"" style=""width: 127px;"">Experience</th>
            <th class=""sorting"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-label=""Created Date: activate to sort column ascending"" style=""width: 190px;"">Start Date</th>
            <th class=""sorting"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-label=""Created Date: activate to sort column ascending"" style=""width: 190px;"">End Date</th>
            <th style=""width: 38px;"" class=""sorting"" role=""columnheader"" tabindex=""0"" aria-controls=""_DataTable"" rowspan=""1"" colspan=""1"" aria-label="" Action : activate to sort column ascending""> Action </th>
        </tr>
    </thead>
    <tbody role=""alert"" aria-live=""polite"" aria-relevant=""all"">
");
#nullable restore
#line 21 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr class=\"even\">\r\n\r\n            <td style=\"text-align:left\">");
#nullable restore
#line 25 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
                                   Write(item.Vacancy);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td style=\"text-align:left\">");
#nullable restore
#line 26 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
                                   Write(item.Department);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td style=\"text-align:left\">");
#nullable restore
#line 27 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
                                   Write(item.NoOfPosition);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td style=\"text-align:right\">");
#nullable restore
#line 28 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
                                    Write(item.NoOfExperience);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td style=\"text-align:right\">");
#nullable restore
#line 29 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
                                    Write(item.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td style=\"text-align:right\">");
#nullable restore
#line 30 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
                                    Write(item.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td class=\"text-center \">\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 2456, "\"", 2513, 2);
            WriteAttributeValue("", 2463, "/Department/ManageDepartment?DepartmentId=", 2463, 42, true);
#nullable restore
#line 32 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
WriteAttributeValue("", 2505, item.Id, 2505, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"Edit\">Edit  <i class=\"fa fa-edit\"></i></a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 2584, "\"", 2642, 2);
            WriteAttributeValue("", 2591, "/Department/DeleteDepartment?&DepartmentId=", 2591, 43, true);
#nullable restore
#line 33 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"
WriteAttributeValue("", 2634, item.Id, 2634, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2643, "\"", 2651, 0);
            EndWriteAttribute();
            WriteLiteral(" onclick=\"return confirm(\" Are you sure you want to delete this job?\");\" title=\"Delete\">Delete     <i class=\"fa fa-times\"></i></a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 36 "D:\AspNetCore\CoreDemo_3_0\CoreDemo_3_0\Views\JobVacancy\Index.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CoreDemo_3_0.Entities.JobVacancy>> Html { get; private set; }
    }
}
#pragma warning restore 1591
