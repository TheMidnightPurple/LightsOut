#pragma checksum "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "816e11e29f9f5a89ebbad6b64c96204790a1b14b"
// <auto-generated/>
#pragma warning disable 1591
namespace LightsOut.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using DataAccessLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using LightsOut;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using LightsOut.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\Index.razor"
using LightsOut.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "section");
            __builder.AddAttribute(2, "b-lrzzdctped");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "video-container");
            __builder.AddAttribute(5, "b-lrzzdctped");
            __builder.AddMarkupContent(6, "<div class=\"color-overlay\" b-lrzzdctped></div>\r\n        ");
            __builder.AddMarkupContent(7, "<video autoplay muted loop b-lrzzdctped><source src=\"video.mp4\" type=\"video/mp4\" b-lrzzdctped></video>\r\n        ");
            __builder.OpenElement(8, "div");
            __builder.AddAttribute(9, "class", "overlay");
            __builder.AddAttribute(10, "b-lrzzdctped");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(11);
            __builder.AddAttribute(12, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(13, "<h1 b-lrzzdctped>Bem-Vindo ao LightsOut</h1>\r\n                    ");
                __builder2.OpenElement(14, "h2");
                __builder2.AddAttribute(15, "b-lrzzdctped");
                __builder2.AddContent(16, 
#nullable restore
#line 17 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\Index.razor"
                         context.User.Identity.Name

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(17, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(18, "<h1 b-lrzzdctped>Bem-Vindo ao LightsOut</h1>\r\n                    ");
                __builder2.AddMarkupContent(19, "<h2 b-lrzzdctped>O Sistema de Monitorização de Eventos de F1</h2>");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 29 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\Index.razor"
      

    string time = "";
    
    protected override void OnInitialized()
    {
        TimerService.UpdateEvent += async date =>
        {
            await InvokeAsync(() =>
            {
                time += date;
                StateHasChanged();
            });
        };
        
        PageHistoryState.AddPageToHistory("http://localhost:5000");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PageHistoryState PageHistoryState { get; set; }
    }
}
#pragma warning restore 1591