#pragma checksum "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccd71b56413354c6e78f79e9742adc2be4b5593f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reservations_Index), @"mvc.1.0.view", @"/Views/Reservations/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
using static ManagementSystem.Helper.Helper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccd71b56413354c6e78f79e9742adc2be4b5593f", @"/Views/Reservations/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39adecd93c7c40f96443fc9706daa25422ffe418", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Reservations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Reservation>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary text-white mx-2 btn-rounded"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary rounded-button "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"


<div class=""col-lg-12 grid-margin stretch-card"">
    <div class=""card"">
        <div class=""card-body"">
            <div class=""d-flex justify-content-between"">
                <h4 class=""card-title  font-weight-bolder"">Rezervasiyalar</h4>
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccd71b56413354c6e78f79e9742adc2be4b5593f6686", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 16 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
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
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccd71b56413354c6e78f79e9742adc2be4b5593f8386", async() => {
                WriteLiteral("Yarat");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            </div>

            <div class=""table-responsive pt-3"">
                <table class=""table table-bordered "">
                    <thead>
                        <tr>

                            <th class=""font-weight-bold"">
                                Müştəri Adı
                            </th>


                            <th class=""font-weight-bold"">
                                Qeydler
                            </th>
                            <th class=""font-weight-bold"">
                                Masa
                            </th>

                            <th class=""font-weight-bold"">
                                Tarix
                            </th>
                            <th class=""font-weight-bold"">
                                Qeyd edən şəxs
                            </th>

                            <th class=""font-weight-bold"">
                                Status
                            </th>

        ");
            WriteLiteral("                    <th class=\"font-weight-bold\">\r\n                                Əməliyyatlar\r\n                            </th>\r\n\r\n\r\n                        </tr>\r\n                    </thead>\r\n                    <tbody>\r\n");
#nullable restore
#line 57 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                         foreach (Reservation item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 62 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                               Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 67 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                               Write(item.Notes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td name=\"tableId\">\r\n                                    ");
#nullable restore
#line 70 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                               Write(item.Table.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n                                <td>\r\n                                    ");
#nullable restore
#line 74 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                               Write(item.Day.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    ");
#nullable restore
#line 75 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                               Write(item.StartTime?.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" -   ");
#nullable restore
#line 75 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                                                      Write(item.EndTime?.ToString("HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 80 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                               Write(item.AppUser.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 93 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                 if (item.Status == ReservationStatus.Pending)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        <label class=\"badge badge-info\">");
#nullable restore
#line 96 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                                                   Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                    </td>\r\n");
#nullable restore
#line 98 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"

                                }
                                else if (item.Status == ReservationStatus.Cancelled)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        <label class=\"badge badge-danger\">");
#nullable restore
#line 103 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                                                     Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                    </td>\r\n");
#nullable restore
#line 105 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                }
                                else if (item.Status == ReservationStatus.Done)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        <label class=\"badge badge-success\">");
#nullable restore
#line 109 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                                                      Write(item.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                    </td>\r\n");
#nullable restore
#line 111 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                \r\n\r\n\r\n                                <td>\r\n                                    <div class=\"d-flex justify-content-center \">\r\n\r\n");
#nullable restore
#line 119 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                         if (item.Status == ReservationStatus.Pending)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                             ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ccd71b56413354c6e78f79e9742adc2be4b5593f18187", async() => {
                WriteLiteral("\r\n                                            <i class=\"fa-solid fa-wrench fa-customize\"></i>\r\n                                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 121 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 124 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                                        }
                                      

                                      

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </div>\r\n                                </td>\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 152 "C:\Users\USER\OneDrive\Desktop\ProjectEnd\RestaurantManagementSystem\ManagementSystem-main\ManagementSystem\ManagementSystem\Views\Reservations\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Css", async() => {
                WriteLiteral(@"
    <style type=""text/css"">

        element.style {
        }


        .rounded-button {
            width: 30px;
            height: 30px;
            /*   background: #9932cc;*/
            color: #ffffff;
            display: inline-flex;
            align-items: center;
            justify-content: center;
            cursor: pointer;
            border-radius: 50%;
            border: none;
            text-decoration: none;
            transition: background 0.2s;
            margin: 7px;
        }

        /* .rounded-button:hover {
                                                        #ffffff;

                                                    }*/

        .fa-customize {
            font-size: 15px;
        }

    </style>


");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Reservation>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591