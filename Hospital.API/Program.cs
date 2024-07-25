using Hospital.API.Extensions;
using Hospital.Core.Models.Identity;
using Hospital.Core.Services.Interfaces;
using Hospital.Repository.Data.Contexts;
using Hospital.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hospital.API
{
    public class Program
    {
        //https://localhost:44352/swagger/v1/swagger.json
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Configure Services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HospitalDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {

            }).AddEntityFrameworkStores<HospitalDbContext>();


            #region TokenService
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        ValidateAudience = true,
                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                    };
                });
            #endregion


            // Method Clean Code (Write All Configure in Class ApplicationServiceExtensions)
            builder.Services.AddApplicationServiceExtensions();

            #endregion

            var app = builder.Build();

            #region Update Database  - DataSeed

            var scope = app.Services.CreateScope();

            var service = scope.ServiceProvider;

            var _context = service.GetRequiredService<HospitalDbContext>();


            var loggerFactory = service.GetRequiredService<ILoggerFactory>();

            try
            {

                #region  Update Database (StoreDbContext) And DataSeeding

                await _context.Database.MigrateAsync();

                //// Data Seeding
                await HospitalDbContextSeed.SeedAsync(_context);
                var _userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
                await IdentityDataSeed.SeedRolesAsync(_userManager, service.GetRequiredService<RoleManager<IdentityRole>>());
                #endregion

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An Error Has Been Occured During Appling The Migrations");
            }

            #endregion

            #region Configure 

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
