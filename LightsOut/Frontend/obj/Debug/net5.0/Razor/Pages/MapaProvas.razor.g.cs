#pragma checksum "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "77ff90cf11606e58df850c343499aedd4995f541"
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
#line 3 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
using LightsOut.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
using DataAccessLibrary;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
using DataAccessLibrary.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/mapaProvas")]
    public partial class MapaProvas : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "contentor");
            __builder.AddAttribute(2, "b-zxhmacjn0q");
            __builder.AddMarkupContent(3, "<div id=\"map\" style=\"height: 100vh; width: 100%;\" b-zxhmacjn0q></div>\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "filtros");
            __builder.AddAttribute(6, "b-zxhmacjn0q");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "class", "row");
            __builder.AddAttribute(9, "b-zxhmacjn0q");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "row");
            __builder.AddAttribute(12, "b-zxhmacjn0q");
            __builder.OpenElement(13, "button");
            __builder.AddAttribute(14, "type", "button");
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                                PrevDiaInicial

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "b-zxhmacjn0q");
            __builder.AddMarkupContent(17, "&#8249");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n                ");
            __builder.OpenElement(19, "p");
            __builder.AddAttribute(20, "b-zxhmacjn0q");
            __builder.AddContent(21, "Data Inicial: ");
            __builder.AddContent(22, 
#nullable restore
#line 20 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                   diaInicial.ToString("dd/MM/yyyy")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                ");
            __builder.OpenElement(24, "button");
            __builder.AddAttribute(25, "type", "button");
            __builder.AddAttribute(26, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                                ProxDiaInicial

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(27, "b-zxhmacjn0q");
            __builder.AddMarkupContent(28, "&#8250");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n        ");
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "row");
            __builder.AddAttribute(32, "b-zxhmacjn0q");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "row");
            __builder.AddAttribute(35, "b-zxhmacjn0q");
            __builder.OpenElement(36, "button");
            __builder.AddAttribute(37, "type", "button");
            __builder.AddAttribute(38, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                                PrevDiaFinal

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "b-zxhmacjn0q");
            __builder.AddMarkupContent(40, "&#8249");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n                ");
            __builder.OpenElement(42, "p");
            __builder.AddAttribute(43, "b-zxhmacjn0q");
            __builder.AddContent(44, "Data Final: ");
            __builder.AddContent(45, 
#nullable restore
#line 27 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                 diaFinal.ToString("dd/MM/yyyy")

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n                ");
            __builder.OpenElement(47, "button");
            __builder.AddAttribute(48, "type", "button");
            __builder.AddAttribute(49, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                                ProxDiaFinal

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(50, "b-zxhmacjn0q");
            __builder.AddMarkupContent(51, "&#8250");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n        ");
            __builder.OpenElement(53, "div");
            __builder.AddAttribute(54, "class", "row");
            __builder.AddAttribute(55, "b-zxhmacjn0q");
            __builder.OpenElement(56, "div");
            __builder.AddAttribute(57, "class", "row");
            __builder.AddAttribute(58, "b-zxhmacjn0q");
            __builder.OpenElement(59, "button");
            __builder.AddAttribute(60, "type", "button");
            __builder.AddAttribute(61, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                                DecrementRange

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(62, "b-zxhmacjn0q");
            __builder.AddMarkupContent(63, "&#8249");
            __builder.CloseElement();
            __builder.AddMarkupContent(64, "\r\n                ");
            __builder.OpenElement(65, "p");
            __builder.AddAttribute(66, "b-zxhmacjn0q");
            __builder.AddContent(67, "Range: ");
            __builder.AddContent(68, 
#nullable restore
#line 34 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                           range

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n                ");
            __builder.OpenElement(70, "button");
            __builder.AddAttribute(71, "type", "button");
            __builder.AddAttribute(72, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
                                                IncrementRange

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(73, "b-zxhmacjn0q");
            __builder.AddMarkupContent(74, "&#8250");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\Users\Carlos Preto\Desktop\3ºAno MIEI\2º Semestre\LI4\LightsOut\Frontend\Pages\MapaProvas.razor"
       
    private DateTime diaInicial = DateTime.Now;
    private DateTime diaFinal = DateTime.Now;
    private int range = 1;
    //private ProvaMo prova = new Prova();
    private List<ProvaModel> provas = new List<ProvaModel>();
    //private Localizacao local = new Localizacao();
    private List<LocalizacaoModel> localizacoes = new List<LocalizacaoModel>();
    private List<List<float>> locais = new List<List<float>>();
    private String time;


    private void IncrementRange()
    {
        int i = range + 1;
        range = i;
    }

    private void DecrementRange()
    {
        if (range > 1)
        {
            int i = range - 1;
            range = i;
        }
    }

    private void ProxDiaInicial()
    {
        DateTime d = diaInicial.AddDays(range);
        if (d <= diaFinal)
        {
            diaInicial = d;
            base.StateHasChanged();
        }
        else
        {
            diaInicial = diaFinal;
            base.StateHasChanged();
        }
    }

    private void ProxDiaFinal()
    {
        DateTime d = diaFinal.AddDays(range);
        diaFinal = d;
        base.StateHasChanged();
    }


    protected void PrevDiaInicial()
    {
        DateTime d = diaInicial.AddDays(-range);
        diaInicial = d;
        base.StateHasChanged();
    }

    protected void PrevDiaFinal()
    {
        DateTime d = diaFinal.AddDays(-range);
        if (d >= diaInicial)
        {
            diaFinal = d;
            base.StateHasChanged();
        }
        else
        {
            diaFinal = diaInicial;
            base.StateHasChanged();
        }
    }

    protected List<List<float>> getCoord(List<ProvaModel> provas)
    {
        List<List<float>> result = new List<List<float>>();

        foreach (ProvaModel prova in provas)
        {
            List<float> coord = new List<float>();
            coord.Add(prova.localizacao.latitude);
            coord.Add(prova.localizacao.longitude);
            result.Add(coord);
        }

        return result;
    }

    protected List<string> getNomes(List<ProvaModel> provas)
    {
        List<string> result = new List<string>();

        foreach (ProvaModel prova in provas)
        {
            result.Add(prova.id);
        }

        return result;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {

        if (firstRender)
        {
            provas = _dbProva.localizacaoProvasIntervalo(diaInicial.ToString("yyyy-MM-dd"), diaFinal.ToString("yyyy-MM-dd"));
            List<string> res = new List<string>();

            foreach (var p in provas)
            {
                res.Add(JsonConvert.SerializeObject(p));
            }

            await JSRuntime.InvokeVoidAsync("loadMapScenario", res);
            TimerService.UpdateEvent += async date =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            };
        }
        else
        {
            provas = _dbProva.localizacaoProvasIntervalo(diaInicial.ToString("yyyy-MM-dd"), diaFinal.ToString("yyyy-MM-dd"));
            List<string> res = new List<string>();

            foreach (var p in provas)
            {
                res.Add(JsonConvert.SerializeObject(p));
            }

            await JSRuntime.InvokeVoidAsync("loadMapScenario", res);

            TimerService.UpdateEvent += async date =>
            {
                await InvokeAsync(() =>
                {
                    time += date;
                    StateHasChanged();
                });
            };

        }

        PageHistoryState.AddPageToHistory("/mapaProvas");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IProvaData _dbProva { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalizacaoData _dbLocalizacao { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private PageHistoryState PageHistoryState { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
