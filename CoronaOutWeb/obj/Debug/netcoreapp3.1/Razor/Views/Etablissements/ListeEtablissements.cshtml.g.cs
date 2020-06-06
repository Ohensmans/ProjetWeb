#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f6cbc3db92a3a1036f0635e0ed927d068d1816d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Etablissements_ListeEtablissements), @"mvc.1.0.view", @"/Views/Etablissements/ListeEtablissements.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f6cbc3db92a3a1036f0635e0ed927d068d1816d", @"/Views/Etablissements/ListeEtablissements.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35edebf89ec85c9747c0b08c1524e1804b948fe9", @"/Views/_ViewImports.cshtml")]
    public class Views_Etablissements_ListeEtablissements : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CoronaOutWeb.ViewModel.ListeEtablissementsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/SortTable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
  
    ViewData["Title"] = "Liste des établissements enregistrés";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Liste des établissements enregistrés</h1>\r\n<br />\r\n<br />\r\n");
#nullable restore
#line 9 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
 if (Model.Etablissements.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table table-striped"" id=""myTable"">
        <thead>
            <tr>
                <th class=""NomColonne"" id=""0"">Nom</th>
                <th class=""NomColonne"" id=""1"">Type</th>
                <th class=""NomColonne"" id=""2"">Rue</th>
                <th class=""NomColonne"" id=""3"">Numéro</th>
                <th class=""NomColonne"" id=""4"">Ville</th>
                <th class=""NomColonne"" id=""5"">Pays</th>
                <th>Details</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 24 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
             foreach (var etablissement in Model.Etablissements)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                 if (etablissement.estValide)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 29 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.Label("", etablissement.Nom));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.Label("", etablissement.Type));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.Label("", etablissement.Rue));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.Label("", etablissement.NumeroBoite));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.Label("", etablissement.Ville));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.Label("", etablissement.Pays));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                       Write(Html.ActionLink("Détails", "Fiche", "Etablissements", new { id = etablissement.NomUrl }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n");
#nullable restore
#line 37 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 41 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
}

else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Il n\'y a pas encore d\'établissments validés</h3>\r\n");
#nullable restore
#line 46 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\CoronaOutWeb\Views\Etablissements\ListeEtablissements.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0f6cbc3db92a3a1036f0635e0ed927d068d1816d9062", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CoronaOutWeb.ViewModel.ListeEtablissementsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
