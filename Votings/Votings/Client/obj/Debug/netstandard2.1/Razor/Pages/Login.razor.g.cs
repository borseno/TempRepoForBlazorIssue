#pragma checksum "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "398632c30919194cb6124dd42a9565dfee9a3008"
// <auto-generated/>
#pragma warning disable 1591
namespace Votings.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Client.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Shared.PageModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Client.BusinessLogic.Services.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\_Imports.razor"
using Votings.Shared.Extensions;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/login")]
    public partial class Login : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Login</h1>\r\n\r\n");
#nullable restore
#line 7 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
 if (errors != null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "alert alert-danger");
            __builder.AddAttribute(4, "role", "alert");
            __builder.AddMarkupContent(5, "\r\n");
#nullable restore
#line 10 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
         foreach (var error in errors)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "            ");
            __builder.OpenElement(7, "p");
            __builder.AddContent(8, 
#nullable restore
#line 12 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                error

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n");
#nullable restore
#line 13 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(10, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(11, "\r\n");
#nullable restore
#line 15 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
}

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(12, "\r\n");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "card");
            __builder.AddMarkupContent(15, "\r\n    ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "card-body");
            __builder.AddMarkupContent(18, "\r\n        ");
            __builder.AddMarkupContent(19, "<h5 class=\"card-title\">Please enter your details</h5>\r\n        ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(20);
            __builder.AddAttribute(21, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 20 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                          loginModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(22, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 20 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                                                      HandleLogin

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(23, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(24, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(25);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(26, "\r\n            ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.ValidationSummary>(27);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(28, "\r\n\r\n            ");
                __builder2.OpenElement(29, "div");
                __builder2.AddAttribute(30, "class", "form-group");
                __builder2.AddMarkupContent(31, "\r\n                ");
                __builder2.AddMarkupContent(32, "<label for=\"email\">Email address</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(33);
                __builder2.AddAttribute(34, "id", "email");
                __builder2.AddAttribute(35, "class", "form-control");
                __builder2.AddAttribute(36, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 26 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                                                                        loginModel.Email

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(37, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginModel.Email = __value, loginModel.Email))));
                __builder2.AddAttribute(38, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => loginModel.Email));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(39, "\r\n                ");
                __Blazor.Votings.Client.Pages.Login.TypeInference.CreateValidationMessage_0(__builder2, 40, 41, 
#nullable restore
#line 27 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                                          () => loginModel.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(42, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(43, "\r\n            ");
                __builder2.OpenElement(44, "div");
                __builder2.AddAttribute(45, "class", "form-group");
                __builder2.AddMarkupContent(46, "\r\n                ");
                __builder2.AddMarkupContent(47, "<label for=\"password\">Password</label>\r\n                ");
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.InputText>(48);
                __builder2.AddAttribute(49, "id", "password");
                __builder2.AddAttribute(50, "type", "password");
                __builder2.AddAttribute(51, "class", "form-control");
                __builder2.AddAttribute(52, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                                                                                           loginModel.Password

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(53, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginModel.Password = __value, loginModel.Password))));
                __builder2.AddAttribute(54, "ValueExpression", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => loginModel.Password));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(55, "\r\n                ");
                __Blazor.Votings.Client.Pages.Login.TypeInference.CreateValidationMessage_1(__builder2, 56, 57, 
#nullable restore
#line 32 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
                                          () => loginModel.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.AddMarkupContent(58, "\r\n            ");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(59, "\r\n            ");
                __builder2.AddMarkupContent(60, "<button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n        ");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(61, "\r\n\r\n");
#nullable restore
#line 37 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
         if (logginIn)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(62, "            ");
            __builder.AddMarkupContent(63, "<div>\r\n                <p>Logging in...</p>\r\n            </div>\r\n");
#nullable restore
#line 42 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(64, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Login.razor"
       

    private LoginModel loginModel = new LoginModel();
    private bool logginIn;
    private IEnumerable<string> errors;

    private async Task HandleLogin()
    {
        logginIn = true;

        var result = await LoginService.Login(loginModel);

        if (result.Successful)
        {
            UriHelper.NavigateTo("/", forceLoad: true);
        }
        else
        {
            errors = result.Errors;
        }

        logginIn = false;
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager UriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILoginService LoginService { get; set; }
    }
}
namespace __Blazor.Votings.Client.Pages.Login
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateValidationMessage_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
