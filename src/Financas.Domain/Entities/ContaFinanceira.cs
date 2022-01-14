using Financas.Domain.Bases;
using Financas.Domain.Exceptions;

namespace Financas.Domain.Entities
{
	public class ContaFinanceira : Entity
	{
		public ContaFinanceira(string nomeContaFinanceira, int idPessoa)
		{
			NomeContaFinanceira = nomeContaFinanceira;
			IdPessoa = idPessoa;
		}

		protected ContaFinanceira() { }

		public int IdContaFinanceira { get; set; }
		public string NomeContaFinanceira { get; set; }

		public int IdPessoa { get; set; }
		public Pessoa Pessoa { get; set; }

		public void ModificarNomeContaFinanceira(string nomeContaFinanceira)
		{
			if (string.IsNullOrEmpty(nomeContaFinanceira))
				throw new DomainException("O novo nome da conta financeira não pode ser em branco");

			this.NomeContaFinanceira = nomeContaFinanceira;
		}
	}
}