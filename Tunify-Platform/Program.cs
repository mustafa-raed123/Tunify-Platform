using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Tunify_Platform.Data;
using Tunify_Platform.Data.Models;
using Tunify_Platform.Reposiories.Interface;

using Tunify_Platform.Reposiories.Services;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TunifyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<TunifyDbContext>()
            .AddDefaultTokenProviders();
            builder.Services.AddControllers();

            builder.Services.AddScoped<IUsers, UserService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();

              builder.Services.AddScoped<IUserAuthentication, IdentityUserService>();
            builder.Services.AddScoped<jwtTokenService>();

            builder.Services.AddAuthentication(
               options =>
               {
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               }
               ).AddJwtBearer(
               options =>
               {
                   options.TokenValidationParameters = jwtTokenService.ValidateToken(builder.Configuration);
               });
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });
            });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "api/{documentName}/swagger.json";
             }
            );

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "";
            });
            app.MapControllers();

            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
