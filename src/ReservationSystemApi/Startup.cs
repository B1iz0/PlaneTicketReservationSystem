using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlaneTicketReservationSystem.Business;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Infrastructure;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;

namespace PlaneTicketReservationSystem.ReservationSystemApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddConfigurationServices(Configuration);
            services.AddContextServices(Configuration);
            services.AddAuthenticationAuthorizationServices(Configuration);
            services.AddCorsServices();
            services.AddRepositoryServices();
            services.AddBusinessServices();
            services.AddProviderServices();

            services.AddAutoMapper(typeof(BusinessMappingsProfile), typeof(FiltersHintsMappingsProfile));
            services.AddScoped<ApiMappingsConfiguration>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ReservationSystemContext>();
                context?.Database.Migrate();

                var contextInitializer = serviceScope.ServiceProvider.GetService<ContextInitializer>();
                contextInitializer?.InitializeContext();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CorsOptions.ApiCorsName);

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
