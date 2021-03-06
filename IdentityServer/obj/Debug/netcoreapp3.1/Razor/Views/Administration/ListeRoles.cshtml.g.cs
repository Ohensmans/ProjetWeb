#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6b55b1c13c0df7a9bfdbf22bcd1bdbf8893c755"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_ListeRoles), @"mvc.1.0.view", @"/Views/Administration/ListeRoles.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6b55b1c13c0df7a9bfdbf22bcd1bdbf8893c755", @"/Views/Administration/ListeRoles.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_ListeRoles : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdentityServer.ViewModel.Administration.ListeRoleViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/site.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/SortTable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Pagination.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
  
    ViewData["Title"] = "Liste des rôles";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Liste des rôles</h1>\r\n\r\n");
#nullable restore
#line 9 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
Write(Html.HiddenFor(model => model.returnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 13 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
 if (Model.lRoles.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\r\n    <div>\r\n        ");
#nullable restore
#line 17 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
   Write(Html.ActionLink("Créer un nouveau rôle", "CreateRole", "Administration", new { returnUrl = Model.returnUrl }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 18 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
   Write(Html.ActionLink("Retour au tableau de bord", "Index", "Administration", new { returnUrl = Model.returnUrl }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <br />
    <br />
    <table class=""table table-striped"" id=""myTable"">
        <thead>
            <tr>
                <th class=""NomColonne"" id=""0"">Nom</th>
                <th>Modifier</th>
                <th>Supprimer</th>
            </tr>
        </thead>
        <tbody>

");
#nullable restore
#line 32 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
             foreach (var role in Model.lRoles)
            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 36 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
                   Write(Html.Label("", role.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
                   Write(Html.ActionLink("Modifier", "EditRole", "Administration", new { id = role.Id, returnUrl = Model.returnUrl }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 39 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
                         using (Html.BeginForm("DeleteRole", "Administration", new { roleId = role.Id, returnUrl = Model.returnUrl }, FormMethod.Post))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span");
            BeginWriteAttribute("id", " id=\"", 1496, "\"", 1527, 2);
            WriteAttributeValue("", 1501, "confirmDeleteSpan_", 1501, 18, true);
#nullable restore
#line 41 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
WriteAttributeValue("", 1519, role.Id, 1519, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" style=""display:none"">
                                <span>Etes-vous sûr de vouloir supprimer ce rôle ?</span>
                                <button type=""submit"" class=""btn btn-danger"">Oui</button>
                                <a href=""#"" class=""btn btn-primary""");
            BeginWriteAttribute("onclick", " onclick=\"", 1801, "\"", 1843, 4);
            WriteAttributeValue("", 1811, "confirmDelete(\'", 1811, 15, true);
#nullable restore
#line 44 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
WriteAttributeValue("", 1826, role.Id, 1826, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1834, "\',", 1834, 2, true);
            WriteAttributeValue(" ", 1836, "false)", 1837, 7, true);
            EndWriteAttribute();
            WriteLiteral(">Non</a>\r\n                            </span>\r\n");
            WriteLiteral("                            <span");
            BeginWriteAttribute("id", " id=\"", 1926, "\"", 1950, 2);
            WriteAttributeValue("", 1931, "deleteSpan_", 1931, 11, true);
#nullable restore
#line 47 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
WriteAttributeValue("", 1942, role.Id, 1942, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <a href=\"#\" class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2020, "\"", 2061, 4);
            WriteAttributeValue("", 2030, "confirmDelete(\'", 2030, 15, true);
#nullable restore
#line 48 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
WriteAttributeValue("", 2045, role.Id, 2045, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2053, "\',", 2053, 2, true);
            WriteAttributeValue(" ", 2055, "true)", 2056, 6, true);
            EndWriteAttribute();
            WriteLiteral(">Supprimer</a>\r\n                            </span>\r\n");
#nullable restore
#line 50 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
               Write(Html.Hidden(role.Id, role.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </tr>\r\n");
#nullable restore
#line 54 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            WriteLiteral("    <div id=\"centerAll\" class=\"pagination\">\r\n        <a id=\"paginationButtonPrevious\" href=\"#\">&laquo;</a>\r\n        <a");
            BeginWriteAttribute("id", " id=\"", 2411, "\"", 2416, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"paginationButtonNum active\" href=\"#\"></a>\r\n        <a");
            BeginWriteAttribute("id", " id=\"", 2478, "\"", 2483, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"paginationButtonNum\" href=\"#\"></a>\r\n        <a");
            BeginWriteAttribute("id", " id=\"", 2538, "\"", 2543, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"paginationButtonNum\" href=\"#\"></a>\r\n        <a id=\"paginationButtonNext\" href=\"#\">&raquo;</a>\r\n    </div>\r\n");
#nullable restore
#line 65 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""card"">
        <div class=""card-header"">
            Il n'existe pas encore de rôles
        </div>
        <div class=""card-body"">
            <h5 class=""card-title"">
                Utilisez le bouton ci-dessous pour créer un rôle
            </h5>
            ");
#nullable restore
#line 77 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
       Write(Html.ActionLink("Créer un nouveau rôle", "CreateRole", "Administration", new { returnUrl = Model.returnUrl }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 80 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\ListeRoles.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6b55b1c13c0df7a9bfdbf22bcd1bdbf8893c75513173", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6b55b1c13c0df7a9bfdbf22bcd1bdbf8893c75514273", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6b55b1c13c0df7a9bfdbf22bcd1bdbf8893c75515373", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdentityServer.ViewModel.Administration.ListeRoleViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
