using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace Financas.WebApi.Pipeline
{
	public static class SwaggerConfigurationPipeline
	{
		public static void AddSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Finanças Api", Version = "v1" });

				var definition = new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Por favor, insira no campo a palavra 'Bearer', seguida por espaço e JWT",
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey
				};
				c.AddSecurityDefinition("Bearer", definition);
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
					  new OpenApiSecurityScheme
					  {
						Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
						Scheme = "oauth2",
						Name = "Bearer",
						In = ParameterLocation.Header
					  },
					  new List<string>()
					}
				});
			});
		}

		public static void UseSwaggerUI(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Finanças API");
			});

		}
	}
}
