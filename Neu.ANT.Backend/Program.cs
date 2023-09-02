
using Neu.ANT.Backend.Configurations;
using Neu.ANT.Backend.Services;

namespace Neu.ANT.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<DatabaseConfigurations>(builder.Configuration.GetSection("Database"));
            builder.Services
                .AddSingleton<DatabaseConnectionService>()
                .AddSingleton<UserDbService>()
                .AddSingleton<TokenDbService>()
                .AddSingleton<AuthenticationService>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}