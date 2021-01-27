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

		public ContaFinanceira(int idContaFinanceira, string nomeContaFinanceira, int idPessoa) : this(nomeContaFinanceira, idPessoa)
		{
			IdContaFinanceira = idContaFinanceira;
		}

		protected ContaFinanceira() { }

		public int IdContaFinanceira { get; set; }
		public string NomeContaFinanceira { get; set; }
		public int IdPessoa { get; set; }

		public void ModificarNomeContaFinanceira(string nomeContaFinanceira)
		{
			if (string.IsNullOrEmpty(nomeContaFinanceira))
				throw new DomainException("O novo nome da conta financeira não pode ser em branco");

			this.NomeContaFinanceira = nomeContaFinanceira;
		}

		public void ModificarPessoaContaFinanceira(int idPessoa)
		{
			if (idPessoa == 0)
				throw new DomainException("A pessoa da conta financeira não pode ser em branco");
		}
	}
}