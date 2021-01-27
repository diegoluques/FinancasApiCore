namespace Financas.WebApi.Commands
{
	public class CriarContaFinanceiraCommand
	{
		public int IdContaFinanceira { get; set; }
		public string NomeContaFinanceira { get; set; }
		public int IdPessoa { get; set; }
	}
}