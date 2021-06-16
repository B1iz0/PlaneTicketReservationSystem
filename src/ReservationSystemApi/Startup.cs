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
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;

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
            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddControllers();
            services.AddDbContext<ReservationSystemContext>(opt =>
                {
                    opt.UseLazyLoadingProxies();
                    opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });
            services.AddScoped<ContextInitializer>();
            services.AddRepositoryServices();

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
                        ValidateIssuerSigningKey = true,
                    };
                });
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("AdminApp", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("AdminApp");
                });
                opt.AddPolicy("Admin", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireRole("Admin", "AdminApp");
                });
            });

            services.AddConfigurationServices(Configuration);
            services.AddBusinessServices();

            services.AddScoped<ApiMappingsConfiguration>();
            services.AddScoped<BusinessMappingsConfiguration>();
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

            app.UseCors("ApiCorsPolicy");

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
