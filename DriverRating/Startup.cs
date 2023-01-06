using System.Text;
using DriverRating.Config;
using DriverRating.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DriverRating;

public class Startup
{
    private readonly AppConfig _appConfig;
    private readonly IConfiguration _configuration;
    
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
        _appConfig = configuration
            .GetSection(nameof(AppConfig))
            .Get<AppConfig>() ?? new AppConfig();
    }
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(_appConfig);
        
        services.AddDbContext<AppDbContext>(
            options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

        services.AddMemoryCache();
        
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        
        services.AddAuthorization();

        services.AddScoped<IAppDbRepository, AppDbRepository>();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "DriverRating API",
                    Description = "DriverRating API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Jakob Bauer",
                        Url = new Uri("https://www.bauer-jakob.de"),
                        Email = "info@bauer-jakob.de"
                    }
                });
        });
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();

        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "DriverRating API");
        });
    }
}