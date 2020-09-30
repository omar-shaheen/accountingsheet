#pragma checksum "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d3c33105d2cc491971a54920cc8d17d42114331"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared_usertwo), @"mvc.1.0.view", @"/Pages/Shared/usertwo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d3c33105d2cc491971a54920cc8d17d42114331", @"/Pages/Shared/usertwo.cshtml")]
    public class Pages_Shared_usertwo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html lang=\"en\">\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d3c33105d2cc491971a54920cc8d17d421143312718", async() => {
                WriteLiteral(@"
  <meta charset=""UTF-8"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1, shrink-to-fit=no"">
  <title>Document</title>

  <link href=""https://fonts.googleapis.com/css2?family=Tajawal:wght@200;300;400;500;700;800;900&display=swap""
    rel=""stylesheet"">
  <link rel=""stylesheet"" href=""/assets/libs/bootstrap-4.5.2/bootstrap.min.css"">
  <link rel=""stylesheet"" href=""/assets/libs/datatables/datatables.min.css"">
  <link rel=""stylesheet"" href=""/assets/libs/datatables/dataTables.bootstrap4.min.css"">
  <link rel=""stylesheet"" href=""/assets/css/style.css"">
  <link rel=""stylesheet"" href=""/assets/css/style.css"">
  <link rel=""stylesheet"" href=""/assets/css/media.css"">
  <link rel=""stylesheet"" href=""/assets/css/ar.css"">


");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8d3c33105d2cc491971a54920cc8d17d421143314455", async() => {
                WriteLiteral(@"


  <div class=""wrapper-container py-5"">

    

    <div class=""page-daily-inputs"">
      <div class=""container-fluid"">
        <div class=""title d-flex align-items-center justify-content-between"">
          <div class=""left"">
            <div class=""bredcrumps mb-4"">
              <a href=""/Sheet/index""> الرئيسية </a>
              <span class=""active""> المهندس محمد </span>
            </div>
          </div>
          <div class=""right"">
            <span class=""h4 m-0 d-block all-costs""> الرصيد : ");
#nullable restore
#line 39 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                                                        Write(ViewBag.balance);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" LE </a>
          </div>
        </div>
        
        <strong class=""user-title text-center""> المهندس محمد </strong>

        <div class=""row"">
          <div class=""col-md-6"">
            <!-- Table -->
            <div class=""title-table"">
              <table class=""table text-center m-0"">
                <thead>
                  <tr>
                    <th> العهدة </th>
                  </tr>
                  <tr>
                    <th>   اجمالي العهدة : ");
#nullable restore
#line 55 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                                      Write(ViewBag.project.income);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" LE </th>
                  </tr>
                </thead>
              </table>
            </div>

            <div class=""table-responsive"">
              <table class=""table table-striped table-bordered text-center"">
                <thead>
                  <tr>
                    <th>م</th>
                    <th>العهدة</th>
                    <th>التاريخ</th>
                  </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 71 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                    var y=1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 72 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                   foreach (var item in ViewBag.projectormonthlyinputexpense)
                  {

#line default
#line hidden
#nullable disable
                WriteLiteral("                  <tr>\n                    <td><span>");
#nullable restore
#line 75 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                         Write(y);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\n                    <td> <span>LE ");
#nullable restore
#line 76 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                             Write(item.incomeamount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> </td>\n                    <td style=\"min-width: 200px;\"> <span>");
#nullable restore
#line 77 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                                                    Write(item.description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> </td>\n                    <td> ");
#nullable restore
#line 78 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                    Write(item.createdat);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\n                  </tr>\n");
#nullable restore
#line 80 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                  y++;
                  }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
              </table>
            </div>

          </div>

          <div class=""col-md-6"">
            <!-- Table -->
            <div class=""title-table"">
              <table class=""table text-center m-0"">
                <thead>
                  <tr>
                    <th> الواصل </th>
                  </tr>
                  <tr>
                    <th>   اجمالي الواصل له : ");
#nullable restore
#line 97 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                                         Write(ViewBag.project.expense);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" LE </th>
                  </tr>
                </thead>
              </table>
            </div>

            <div class=""table-responsive"">
              <table class=""table table-striped table-bordered text-center"">
                <thead>
                  <tr>
                    <th>م</th>
                    <th>المبلغ</th>
                    <th>التاريخ</th>
                  </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 113 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                    var i=1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 114 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                   foreach (var item in ViewBag.projectormonthlyinputexpense)
                  {


#line default
#line hidden
#nullable disable
                WriteLiteral("                  <tr>\n                    <td><span>");
#nullable restore
#line 118 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                         Write(i);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span></td>\n                    <td> <span>LE ");
#nullable restore
#line 119 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                             Write(item.expenseamount);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> </td>\n                    <td style=\"min-width: 200px;\"> <span>");
#nullable restore
#line 120 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                                                    Write(item.description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span> </td>\n                    <td> ");
#nullable restore
#line 121 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                    Write(item.createdat);

#line default
#line hidden
#nullable disable
                WriteLiteral(" </td>\n                  </tr>\n");
#nullable restore
#line 123 "D:\engineeringoffice\accountingsheet\Pages\Shared\usertwo.cshtml"
                  i++;
                  }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </tbody>
              </table>
            </div>

          </div>
        </div>

      </div>
    </div>

  </div>





  <script src=""/assets/js/jquery-3.5.1.min.js""></script>
  <script src=""/assets/libs/bootstrap-4.5.2/popper.min.js""></script>
  <script src=""/assets/libs/bootstrap-4.5.2/bootstrap.bundle.min.js""></script>
  <script src=""/assets/libs/datatables/datatables.min.js""></script>
  <script src=""/assets/libs/datatables/dataTables.bootstrap4.min.js""></script>
  <script src=""/assets/libs/datatables/editable-html-table-js.js""></script>
  <script src=""/assets/libs/chart.bundle.min.js""></script>
  <script src=""/assets/js/scripts.js""></script>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
