#pragma checksum "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e7dea2616a5bf7a1bc48d283337af3576f018d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expenses_Index), @"mvc.1.0.view", @"/Views/Expenses/Index.cshtml")]
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
#line 1 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\_ViewImports.cshtml"
using ManagementSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\_ViewImports.cshtml"
using ManagementSystem.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\_ViewImports.cshtml"
using ManagementSystem.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7dea2616a5bf7a1bc48d283337af3576f018d2", @"/Views/Expenses/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39adecd93c7c40f96443fc9706daa25422ffe418", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Expenses_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Expense>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary text-white mx-2 btn-rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ValidationScriptsPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 6 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            DefineSection("Css", async() => {
                WriteLiteral("\n    <link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.13.1/css/jquery.dataTables.min.css\" />\n    <link rel=\"stylesheet\" href=\"https://cdn.datatables.net/buttons/2.3.2/css/buttons.dataTables.min.css\" />\n");
            }
            );
            WriteLiteral("<div class=\"col-lg-12 grid-margin stretch-card\">\n    <div class=\"card\">\n        <div class=\"card-body\">\n            <div class=\"d-flex justify-content-between\">\n                <h4 class=\"card-title  font-weight-bolder\">Xərclər</h4>\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e7dea2616a5bf7a1bc48d283337af3576f018d26735", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 19 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                <div class=\"row\">\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5e7dea2616a5bf7a1bc48d283337af3576f018d28470", async() => {
                WriteLiteral("Yarat");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                </div>


            </div>

            <div class=""table-responsive pt-3"">
                <table id=""example"" class=""display nowrap"" style=""width:100%"">
                    <thead>
                        <tr>

                            <th>Xərc</th>

                            <th>Xərc Haqqında </th>


                            <th>Xərcin Vaxtı</th>
                            <th>Qeyd Edən Şəxs</th>

                        </tr>
                    </thead>
                    <tbody>

");
#nullable restore
#line 45 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
                         foreach (Expense item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\n\n                                <td>");
#nullable restore
#line 49 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
                               Write(item.Money);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</td>\n                                <td>");
#nullable restore
#line 50 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
                               Write(item.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                                <td>");
#nullable restore
#line 52 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
                               Write(item.RecordTime.ToString("dd/MM/yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                <td>");
#nullable restore
#line 53 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"
                               Write(item.AppUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                \n\n\n\n                            </tr>\n");
#nullable restore
#line 59 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Expenses\Index.cshtml"



                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n                </table>\n\n            </div>\n        </div>\n    </div>\n</div>\n\n\n\n\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src="" https://code.jquery.com/jquery-3.5.1.js""></script>
    <script src="" https://cdn.datatables.net/1.13.1/js/jquery.dataTables.min.js""></script>
    <script src="" https://cdn.datatables.net/buttons/2.3.2/js/dataTables.buttons.min.js""></script>
    <script src="" https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script>
    <script src="" https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script>
    <script src="" https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>
    <script src="" https://cdn.datatables.net/buttons/2.3.2/js/buttons.html5.min.js""></script>
    <script src="" https://cdn.datatables.net/buttons/2.3.2/js/buttons.print.min.js""></script>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5e7dea2616a5bf7a1bc48d283337af3576f018d213417", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"


    <script>
        $(document).ready(function () {
            $('#example').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'copy', 'csv', 'excel', 'pdf', 'print'
                ]
            });
        });


    </script>
");
            }
            );
            WriteLiteral("\n\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Expense>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591