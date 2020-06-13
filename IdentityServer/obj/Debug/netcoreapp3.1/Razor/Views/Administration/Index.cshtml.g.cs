#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "671994429f03da3505d7fc02c240fb0e717805df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_Index), @"mvc.1.0.view", @"/Views/Administration/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"671994429f03da3505d7fc02c240fb0e717805df", @"/Views/Administration/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdentityServer.ViewModel.Administration.TableauBordViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
  
    ViewData["Title"] = "Tableau de bord des utilisateurs";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Tableau de bord des utilisateurs</h1>\r\n\r\n<div class=\"col-md-12 row\">\r\n    ");
#nullable restore
#line 9 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
Write(Html.HiddenFor(model => model.ReturnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"col-md-6\">\r\n        <br />\r\n        <br />\r\n        <h2>Liste des rôles existants</h2>\r\n");
#nullable restore
#line 14 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
         if (Model.RoleNames.Any())
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <table class=\"table table-striped\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Nom</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
                     foreach (var role in Model.RoleNames)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 28 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
                           Write(Html.Label("", role));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 30 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 33 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Il n\'y a pas encore de rôles</h3>\r\n");
#nullable restore
#line 37 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            ");
#nullable restore
#line 39 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
       Write(Html.ActionLink("Créer un nouveau rôle", "CreateRole", "Administration", new { returnUrl = Model.ReturnUrl }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 40 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
       Write(Html.ActionLink("Gérer les rôles", "ListeRoles", "Administration", new { returnUrl = Model.ReturnUrl }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"col-md-6\">\r\n        <br />\r\n        <br />\r\n        <h2>Liste des utilisateurs existants</h2>\r\n");
#nullable restore
#line 49 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
         if (Model.UserNames.Any())
        {


#line default
#line hidden
#nullable disable
            WriteLiteral("            <table class=\"table table-striped\">\r\n                <thead>\r\n                    <tr>\r\n                        <th>Nom</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 59 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
                     foreach (var user in Model.UserNames)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>");
#nullable restore
#line 63 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
                           Write(Html.Label("", user));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 65 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 68 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <h3>Il n\'y a pas encore d\'utilisateurs</h3>\r\n");
#nullable restore
#line 72 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n            ");
#nullable restore
#line 74 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
       Write(Html.ActionLink("Ajouter un nouvel utilisateur", "Register", "Account", new { returnUrl = Model.ReturnUrl }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 75 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
       Write(Html.ActionLink("Gérer les utilisateurs", "ListeUsers", "Administration", new { returnUrl = Model.ReturnUrl }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n\r\n    </div>\r\n</div>\r\n<br />\r\n<br />\r\n\r\n");
#nullable restore
#line 83 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
 using (Html.BeginForm(FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12 row\">\r\n        <button style=\"width:auto\" type=\"submit\" name=\"button\" value=\"back\" class=\"btn btn-danger\">Retour vers le site</button>\r\n    </div>\r\n");
#nullable restore
#line 88 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdentityServer.ViewModel.Administration.TableauBordViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
