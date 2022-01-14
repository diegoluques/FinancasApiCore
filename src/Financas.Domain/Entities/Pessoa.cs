using Financas.Domain.Bases;
using Financas.Domain.Exceptions;
using System.Collections.Generic;

namespace Financas.Domain.Entities
{
	public class Pessoa : Entity
	{
		public Pessoa(string nomePessoa)
		{
			NomePessoa = nomePessoa;
		}

		public Pessoa(int idPessoa, string nomePessoa)
		{
			IdPessoa = idPessoa;
			NomePessoa = nomePessoa;
		}

		protected Pessoa() { }

		public int IdPessoa { get; private set; }
		public string NomePessoa { get; private set; }

		public ICollection<ContaFinanceira> Contas { get; set; }

		public void ModificarNomePessoa(string nome)
		{
			if (string.IsNullOrEmpty(nome))
			{
				throw new DomainException("O nome da pessoa é obrigatório");
			}

			this.NomePessoa = nome;
		}

	}
}
