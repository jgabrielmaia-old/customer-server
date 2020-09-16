using CustomerServer.Models;
using CustomerServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace CustomerServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CustomerInternal",
                                builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
            });

            services.Configure<CustomersDatabaseSettings>(
            Configuration.GetSection(nameof(CustomersDatabaseSettings)));

            services.AddSingleton<ICustomersDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<CustomersDatabaseSettings>>().Value);

            services.AddSingleton<CustomerService>();

            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customers API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CustomerInternal");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customers API V1");
            });
        }
    }
}
