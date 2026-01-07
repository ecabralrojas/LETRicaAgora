using LET.Agora.Application;
using LET.Agora.Database;

namespace LET.Agora.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var config = builder.Configuration;

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddApplication();
        builder.Services.AddDatabase(config["Database:ConnectionString"],
                                     config["HttpAddress:AGORABaseAddress"],
                                     config["HttpAddress:AGORAToken"]);

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", app =>
            {
                app.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "API LET.AGORA");
            c.RoutePrefix = string.Empty;
        });

        app.UseCors("CorsPolicy");
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
