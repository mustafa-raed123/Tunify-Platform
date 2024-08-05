using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Tunify_Platform.Data;

namespace Tunify_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<TunifyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers();
            var app = builder.Build();
             app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
