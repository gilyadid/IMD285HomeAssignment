using Microsoft.EntityFrameworkCore;

namespace IMD285WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Read the connection string
        var connectionString = builder.Configuration.GetConnectionString("Imd285DbConStr")
                               ?? Environment.GetEnvironmentVariable("ConnectionStrings__Imd285DbConStr");

        // Add DbContext with connection string
        builder.Services.AddDbContext<Imd285DbContext>(options =>
            options.UseSqlServer(connectionString));

        // Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader());
        });

        var app = builder.Build();

        // Apply migrations and create the database
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<Imd285DbContext>();
                context.Database.Migrate(); // Applies any pending migrations and creates the database
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while creating the database.");
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseCors("AllowAll"); // Enable CORS using the defined policy
        app.UseAuthorization();
        app.MapControllers();
        app.Run("http://0.0.0.0:80");
    }
}
