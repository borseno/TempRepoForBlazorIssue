#pragma checksum "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Logout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49a1a01b176045ce6394e819b7983d419f8f37ee"
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/logout")]
    public partial class Logout : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 5 "C:\Users\mark.virchenko\Desktop\Git\Votings\Votings\Client\Pages\Logout.razor"
       

    protected override async Task OnInitializedAsync()
    {
        await LogoutService.Logout();
        UriHelper.NavigateTo("/", forceLoad: true);
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager UriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogoutService LogoutService { get; set; }
    }
}
#pragma warning restore 1591
