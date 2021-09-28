using Append.Blazor.Notifications;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LightsOut.Data;
using DataAccessLibrary;
using Microsoft.AspNetCore.Components.Authorization;

namespace LightsOut
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddRazorPages();
            services.AddServerSideBlazor();            
            services.AddHostedService<TimerService>();            
            services.AddSingleton<PageHistoryState>();            
            services.AddNotifications();
            services.AddBlazoredSessionStorage();
            services.AddTransient<IEquipaData, EquipaData>();
            services.AddTransient<ILocalizacaoData, LocalizacaoData>();
            services.AddTransient<INotificacaoData, NotificacaoData>();
            services.AddTransient<IProvaData, ProvaData>();
            services.AddTransient<IResultadoData, ResultadoData>();
            services.AddTransient<IUtilizadorData, UtilizadorData>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            
            
        }
    }
}
