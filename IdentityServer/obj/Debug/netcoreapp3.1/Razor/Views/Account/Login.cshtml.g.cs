#pragma checksum "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a3221714211e8004255c89f84c6b23ae6db8c03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a3221714211e8004255c89f84c6b23ae6db8c03", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IdentityServer.ViewModel.LoginInputViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
  
    ViewData["Title"] = "Se connecter";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Se connecter</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
 using (Html.BeginForm(FormMethod.Post, new { @class = "row" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
Write(Html.HiddenFor(model => model.ReturnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"col-md-12\">\r\n\r\n        <fieldset>\r\n            ");
#nullable restore
#line 15 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
       Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <br />\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 19 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.LabelFor(model => model.Username, "Login", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 21 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.TextBoxFor(model => model.Username, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 23 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.ValidationMessageFor(model => model.Username, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 27 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.LabelFor(model => model.Password, "Mot de passe", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 29 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.TextBoxFor(model => model.Password, new { @class = "form-control", @type ="password"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <br />\r\n                ");
#nullable restore
#line 31 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.ValidationMessageFor(model => model.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 35 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.EditorFor(model => model.RememberLogin, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 36 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
           Write(Html.LabelFor(model => model.RememberLogin, "Se rappeler du login", new { @class = "control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                <br />
            </div>

            <div>
                <button type=""submit"" class=""btn btn-primary"" name=""button"" value=""login"">Se connecter</button>
                <button type=""submit"" class=""btn btn-danger"" name=""button"" value=""cancel"">Annuler</button>
                <br />
                <br />
                <button type=""submit"" class=""btn btn-success"" name=""button"" value=""register"">Créer un nouveau compte</button>
            </div>
        </fieldset>
    </div>
");
#nullable restore
#line 49 "C:\Users\Olivier\Desktop\Projets Git\ProjetWeb\IdentityServer\Views\Account\Login.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IdentityServer.ViewModel.LoginInputViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
