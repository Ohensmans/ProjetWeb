#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6959b675645d094fa6c382906ac1a565a157e93f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administration_EditUser), @"mvc.1.0.view", @"/Views/Administration/EditUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6959b675645d094fa6c382906ac1a565a157e93f", @"/Views/Administration/EditUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Administration_EditUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdentityServer.ViewModel.Administration.EditUserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
  
    ViewData["Title"] = "Modifier un utilisateur";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Modifier un utilisateur</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @class = "row" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
Write(Html.HiddenFor(model => model.ReturnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"col-md-12\">\r\n    ");
#nullable restore
#line 13 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 17 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.Id, new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 18 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.TextBoxFor(model => model.User.Id, new { @class = "form-control col-sm-10", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 22 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.UserName, new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 23 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.TextBoxFor(model => model.User.UserName, new { @class = "form-control col-sm-10" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 24 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.UserName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 29 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.Nom, new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 30 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.TextBoxFor(model => model.User.Nom, new { @class = "form-control col-sm-10" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 31 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.Nom, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 35 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.Prenom, new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 36 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.TextBoxFor(model => model.User.Prenom, new { @class = "form-control col-sm-10" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 37 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.Prenom, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 41 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.Sexe, new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 42 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.DropDownListFor(model => model.User.Sexe, new SelectList(Model.lGenres), "Sélectionnez votre genre", new { @class = "form-control col-sm-10" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 43 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.Sexe, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 47 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.PhoneNumber, "Numéro de téléphone", new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 48 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.TextBoxFor(model => model.User.PhoneNumber, new { @class = "form-control col-sm-10" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 49 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.PhoneNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 53 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.DateNaissance, "Date de naissance", new { @class = "control-label col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 54 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.EditorFor(model => model.User.DateNaissance,"", new { htmlAttributes = new { @class = "form-control col-sm-10" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 55 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.DateNaissance, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"form-group row\">\r\n        ");
#nullable restore
#line 59 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.EditorFor(model => model.User.estProfessionel, new { @class = "form-control col-sm-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 60 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.LabelFor(model => model.User.estProfessionel, "est professionel", new { @class = "control-label col-sm-10" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        ");
#nullable restore
#line 61 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ValidationMessageFor(model => model.User.estProfessionel, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <br />\r\n    <div class=\"form-group row\">\r\n        <button type=\"submit\" class=\"btn btn-primary\">Mettre à jour</button>\r\n        ");
#nullable restore
#line 67 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.ActionLink("Retour", "ListeUsers", "Administration", new { returnUrl = Model.ReturnUrl }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"card\">\r\n        <div class=\"card-header\">\r\n            <h3>Rôles de l\'utilisateur</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"card-body\">\r\n");
#nullable restore
#line 76 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
         if (Model.Roles.Any())
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 78 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
             foreach (var role in Model.Roles)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row\">\r\n                ");
#nullable restore
#line 81 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
           Write(Html.Label("", role, new { @class = "card-title" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 83 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 83 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
             
        }
        else
        {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
   Write(Html.Label("", "Pas de rôle pour le moment", new { @class = "card-title" }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 87 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
                                                                                    
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"card-footer\">\r\n            ");
#nullable restore
#line 90 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
       Write(Html.ActionLink("Gérer les rôles", "ManageUserRoles", "Administration", new { userId = Model.User.Id, returnUrl = Model.ReturnUrl }, new { @class = "btn btn-success" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n            </div>\r\n");
#nullable restore
#line 97 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Administration\EditUser.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdentityServer.ViewModel.Administration.EditUserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
