#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9a176167e1d584fbb22b806c7b1c4f5f14dd6e7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdministrationNews_Edit), @"mvc.1.0.view", @"/Views/AdministrationNews/Edit.cshtml")]
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
#line 1 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\_ViewImports.cshtml"
using CoronaOutWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\_ViewImports.cshtml"
using CoronaOutWeb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\_ViewImports.cshtml"
using ModelesApi.POC;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9a176167e1d584fbb22b806c7b1c4f5f14dd6e7", @"/Views/AdministrationNews/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35edebf89ec85c9747c0b08c1524e1804b948fe9", @"/Views/_ViewImports.cshtml")]
    public class Views_AdministrationNews_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoronaOutWeb.ViewModel.CreateNewsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("logo-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("accept", new global::Microsoft.AspNetCore.Html.HtmlString("image/*"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("handleLogo(this.files)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control custom-file-input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/toastr.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ModifImages.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
  
    ViewData["Title"] = "Modifier la news";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Modifier la news</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @enctype = "multipart/form-data", @id = "form" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
Write(Html.HiddenFor(model => model.TailleMaxImages, new { @id = "tailleMaxImage", @value = Model.TailleMaxImages }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
Write(Html.HiddenFor(model => model.news.Id, new { @id = "etabId" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
Write(Html.HiddenFor(model => model.news.ImageName));

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
Write(Html.ValidationSummary(false, "", new { @class = "text-danger", @id = "validation-summary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <!--Titre-->\r\n    <div class=\"col-md-12\">\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 19 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
       Write(Html.LabelFor(model => model.news.Titre, new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 20 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
       Write(Html.TextBoxFor(model => model.news.Titre, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 21 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.news.Titre, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <!--Zone de texte-->\r\n    <div class=\"col-md-12\">\r\n        <div class=\"form-group\">\r\n            ");
#nullable restore
#line 28 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
       Write(Html.LabelFor(model => model.news.Message, "Corps de la news", new { @class = "control-label", @Wrap = "hard", @rows = "20" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 29 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
       Write(Html.TextAreaFor(model => model.news.Message, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 30 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
       Write(Html.ValidationMessageFor(model => model.news.Message, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <!--Image-->\r\n    <div class=\"col-md-12\">\r\n        ");
#nullable restore
#line 36 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
   Write(Html.Label("", "Image", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"custom-file\" id=\"logo-container\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c9a176167e1d584fbb22b806c7b1c4f5f14dd6e710312", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 38 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.image);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            <label id=\"logo-label\" class=\"custom-file-label\">Sélectionner l\'image</label>\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <!--Image Preview-->\r\n    <div class=\"col-md-12\">\r\n        <div id=\"logoPreview\">\r\n");
#nullable restore
#line 46 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
             if (Model.news.ImageName != "")
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul class=\"list-group\" id=\"ulPreviewLogo\">\r\n                    ");
#nullable restore
#line 49 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
               Write(Html.HiddenFor(model => model.PathLogo, new { @id = "PhotoId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <li class=\"list-group-item d-flex\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 2256, "\"", 2277, 1);
#nullable restore
#line 51 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
WriteAttributeValue("", 2262, Model.PathLogo, 2262, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"120\" alt=\"la photo ne charge pas\" class=\"align-self-start p-2\" />\r\n                        ");
#nullable restore
#line 52 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
                   Write(Html.Label("", "Supprimer", new { @class = "btn btn-danger align-self-center ml-auto p2", id = "deleteLogo", onclick = "supprimerLogo()" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </li>\r\n\r\n                </ul>\r\n");
#nullable restore
#line 56 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
            WriteLiteral("    <br />\r\n    <br />\r\n");
            WriteLiteral("    <div class=\"col-md-12\">\r\n        <button style=\"width:auto\" type=\"submit\" name=\"button\" value=\"create\" class=\"btn btn-primary\">Modifier la news</button>\r\n        ");
#nullable restore
#line 65 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"
   Write(Html.ActionLink("Retour", "ListeNews", "AdministrationNews", "", new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 67 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\AdministrationNews\Edit.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9a176167e1d584fbb22b806c7b1c4f5f14dd6e715414", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c9a176167e1d584fbb22b806c7b1c4f5f14dd6e716514", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoronaOutWeb.ViewModel.CreateNewsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
