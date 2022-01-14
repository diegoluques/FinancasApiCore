using Financas.Data.Contexts;
using Financas.Data.Repositories;
using Financas.Domain.Contracts.Repositories;
using Financas.WebApi.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Financas.WebApi
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
			services.AddSwagger();
			services.AddControllers();
			services.AddDependecyInjection();
			 
			services.AddDbContext<FinancasContext>(options => 
					options.UseSqlServer(Configuration.GetConnectionString("FinancasConnectionString")));

			services.AddControllersWithViews()
				.AddNewtonsoftJson(options => {
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
					options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseCors(x => x
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader());

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseStaticFiles();

			app.UseSwaggerUI(); 

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
