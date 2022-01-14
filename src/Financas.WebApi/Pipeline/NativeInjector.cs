using Financas.Data.Repositories;
using Financas.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Financas.WebApi.Pipeline
{
	public static class NativeInjector
	{
		public static void AddDependecyInjection(this IServiceCollection services )
		{
			AddRepositories(services);
		} 

		private static void AddRepositories(IServiceCollection services )
		{
			services.AddScoped<ICategoriaRepository, CategoriaRepository>();
			services.AddScoped<IPessoaRepository, PessoaRepository>();
			services.AddScoped<IContaFinanceiraRepository, ContaFinanceiraRepository>();
		}
	}
}
