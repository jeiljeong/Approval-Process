using ApprovalProcess.Infrastructure.Models;
using ApprovalProcess.Infrastructure.Repositories;
using ApprovalProcess.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;


namespace ApprovalProcess.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the DI container
            services.AddControllers();
            
            // Register the ApprovalService with the DI container
            services.AddScoped<IApprovalService, ApprovalService>();

            // Configure MongoDB
            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
                var client = new MongoClient(settings.ConnectionString);
                return client.GetDatabase(settings.DatabaseName);
            });

            // Configure Entity Framework Core (RDB)
            services.AddDbContext<OracleDbContext>(options =>
                options.UseOracle(Configuration.GetConnectionString("YourRdbConnectionString")));

            // Conditional registration based on a configuration flag or other logic
            var useMongoDb = Configuration.GetValue<bool>("UseMongoDb");
            if (useMongoDb)
            {
                services.AddScoped<IApprovalRepository, MongoApprovalRepository>();
            }
            else
            {
                services.AddScoped<IApprovalRepository, OracleApprovalRepository>();
            }

            // Add other necessary services here (e.g., DbContext, Repositories, etc.)
            // For example: services.AddDbContext<YourDbContext>(options => ...);
            services.AddLogging();

            // Configure CORS if necessary
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error"); // Add your error handling middleware
                app.UseHsts();
            }

            // Log each request
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Handling request: {RequestPath}", context.Request.Path);
                await next.Invoke();
                logger.LogInformation("Finished handling request.");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Use CORS if configured
            app.UseCors();

            // Authentication and Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Swagger setup if added
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty; // To serve the Swagger UI at the app's root
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map attribute-routed API controllers
            });
        }
    }
}
