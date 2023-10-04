
using Neu.ANT.Backend.Configurations;
using Neu.ANT.Backend.Services;
using System.Diagnostics.CodeAnalysis;

namespace Neu.ANT.Backend
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      CreateServer().Run();
    }

    public static WebApplication CreateServer()
    {
      var builder = WebApplication
          .CreateBuilder();

      builder.CollectConfiguration<DatabaseConfigurations>("Database");
      builder.ConfigureServices();

      var app = builder.Build();

      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
      }

      app.UseHttpsRedirection();
      app.UseAuthorization();
      app.MapControllers();

      return app;
    }

    public static void CollectConfiguration<T>(this WebApplicationBuilder builder, string section)
        where T : class
        => builder.Services.Configure<T>(builder.Configuration.GetSection(section));

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();
      builder.Services.AddSingleton<DatabaseConnectionService>();

      builder.Services.AddSingleton<UserInformationService>();
      builder.Services.AddSingleton<SessionTokenService>();
      builder.Services.AddSingleton<GroupManagementService>();
      builder.Services.AddSingleton<GroupRelationService>();
      builder.Services.AddSingleton<MessageManagementService>();
      builder.Services.AddSingleton<AuthenticationService>();

      builder.Services.AddControllers().AddNewtonsoftJson();
    }
  }
}