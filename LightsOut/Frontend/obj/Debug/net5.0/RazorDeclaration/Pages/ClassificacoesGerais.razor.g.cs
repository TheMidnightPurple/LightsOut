// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 5 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\ClassificacoesGerais.razor"
using DataAccessLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\ClassificacoesGerais.razor"
using DataAccessLibrary.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/classificacoesGerais")]
    public partial class ClassificacoesGerais : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 761 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\ClassificacoesGerais.razor"
       

    private ResultadoModel resultado = new ResultadoModel();

    private List<Tuple<string, int>> total = new List<Tuple<string, int>>();
    private List<Tuple<string, int>> totalEquipas = new List<Tuple<string, int>>();
    private int provaPretendida = 1;
    private int epocaPretendida = 2021;

    private void ProxProva()
    {
        if (provaPretendida < 22)
        {
            provaPretendida++;
        }
    }

    private void PrevProva()
    {
        if (provaPretendida > 1)
        {
            provaPretendida--;
        }
    }

    private void ProxEpoca()
    {
        if (epocaPretendida < 2021)
        {
            epocaPretendida++;
            provaPretendida = 1;
        }
    }

    private void PrevEpoca()
    {
        if (epocaPretendida > 1999)
        {
            epocaPretendida--;
            provaPretendida = 1;
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

        if (firstRender)
        {
            total = await _dbResultado.ClassificacoesGeraisPiloto(epocaPretendida, provaPretendida);
            totalEquipas = await _dbResultado.ClassificacoesGeraisEquipas(epocaPretendida, provaPretendida);
            StateHasChanged();

        }
        else
        {
            total = await _dbResultado.ClassificacoesGeraisPiloto(epocaPretendida, provaPretendida);
            totalEquipas = await _dbResultado.ClassificacoesGeraisEquipas(epocaPretendida, provaPretendida);
            StateHasChanged();
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IResultadoData _dbResultado { get; set; }
    }
}
#pragma warning restore 1591