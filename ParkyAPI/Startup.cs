using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ParkyAPI.Data;
using ParkyAPI.Mapper;
using ParkyAPI.Repositories.RepositoryNationalPark;
using ParkyAPI.Repositories.RepositoryTrail;
using ParkyAPI.Service.ServiceNationalPark;
using ParkyAPI.Service.ServiceTrail;
using ParkyAPI.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ParkyAPI
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
            services.AddDbContext<ApplicationDbContext>
            (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<INationalParkService, NationalParkService>();
            services.AddScoped<ITrailService, TrailService>();
            services.AddScoped<INationalParkRepository, NationalParkRepository>();
            services.AddScoped<ITrailRepository, TrailRepository>();
             
            services.AddAutoMapper(typeof(ParkyMappings));

            //***versioning
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            //***


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ParkyOpenAPISpec",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Parky API",
                        Version = "1",
                        Description = "Parky API Swagger Description"
                    });
            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, /*versioning*/IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                //options.SwaggerEndpoint("/swagger/ParkyOpenAPISpec/swagger.json", "Parky API");
                //***versioning
                foreach (var desc in provider.ApiVersionDescriptions)
                    options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
                //***
            });
        }
    }
}
