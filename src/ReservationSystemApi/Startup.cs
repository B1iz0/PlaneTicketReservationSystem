using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;

namespace PlaneTicketReservationSystem.ReservationSystemApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            PasswordHasher.Salt = configuration.GetSection("Salt").Get<string>();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<ReservationSystemContext>(opt =>
                {
                    opt.UseLazyLoadingProxies();
                    opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly("ReservationSystemApi"));
                }
                );
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["AuthOptions:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["AuthOptions:Audience"],

                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["AuthOptions:Key"])),
                        ValidateIssuerSigningKey = true
                    };
                });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminApp", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("AdminApp");
                });
            });
            services.Configure<AppSettings>(Configuration.GetSection("AuthOptions"));

            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IDataService<User>, UserService>();
            services.AddScoped<IDataService<Role>, RoleService>();
            services.AddScoped<IDataService<Airplane>, AirplaneService>();
            services.AddScoped<IDataService<AirplaneType>, AirplaneTypeService>();
            services.AddScoped<IDataService<Airport>, AirportService>();
            services.AddScoped<IDataService<Booking>, BookingService>();
            services.AddScoped<IDataService<City>, CityService>();
            services.AddScoped<IDataService<Company>, CompanyService>();
            services.AddScoped<IDataService<Country>, CountryService>();
            services.AddScoped<IDataService<Flight>, FlightService>();

            services.AddScoped<ApiMappingsConfiguration>();
            services.AddScoped<BusinessMappingsConfiguration>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ReservationSystemContext>();
                context?.Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
