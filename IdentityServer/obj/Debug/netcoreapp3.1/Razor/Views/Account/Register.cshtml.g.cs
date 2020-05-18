#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2784aca2162647cb9586d969cdf10a5a50564b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2784aca2162647cb9586d969cdf10a5a50564b7", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdentityServer.ViewModel.RegisterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
  
    ViewData["Title"] = "Enregistrer un nouvel utilisateur";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Enregistrer un nouvel utilisateur</h1>\r\n\r\n\r\n\r\n");
#nullable restore
#line 10 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @class = "row" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
Write(Html.HiddenFor(model => model.ReturnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n\r\n        <fieldset>\r\n            <legend>Informations générales</legend>\r\n\r\n            ");
#nullable restore
#line 19 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
       Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <br />\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.Nom, new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 25 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(model => model.User.Nom, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 27 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.Nom, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 31 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.Prenom, new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 33 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(model => model.User.Prenom, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 35 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.Prenom, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 39 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.Sexe, new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 41 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.DropDownListFor(model => model.User.Sexe, new SelectList(Model.lGenres),"Sélectionnez votre genre", new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 43 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.Sexe, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 47 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.PhoneNumber, "Numéro de téléphone", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 49 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(model => model.User.PhoneNumber, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 51 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.PhoneNumber, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 55 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.DateNaissance, "Date de naissance", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 57 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.EditorFor(model => model.User.DateNaissance, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 59 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.DateNaissance, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 63 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.EditorFor(model => model.User.estProfessionel, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 64 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.estProfessionel, "Cochez cette case si vous représentez un ou des établissement(s)", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 66 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.estProfessionel, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n\r\n        </fieldset>\r\n        <fieldset>\r\n            <legend>Informations de connexion</legend>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 75 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.User.Id, "Adresse mail / Login", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 77 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(model => model.User.Id, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 79 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.User.Id, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 83 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.Password, "Mot de passe", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 85 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(model => model.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 87 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 91 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.LabelFor(model => model.ConfirmPassword, "Confirmation du mot de passe", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 93 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.TextBoxFor(model => model.ConfirmPassword, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 95 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"
           Write(Html.ValidationMessageFor(model => model.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </fieldset>\r\n\r\n        <button type=\"submit\" class=\"btn btn-primary\">Enregistrer</button>\r\n    </div>\r\n");
#nullable restore
#line 101 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Register.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdentityServer.ViewModel.RegisterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
