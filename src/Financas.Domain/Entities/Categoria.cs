using Financas.Domain.Bases;
using Financas.Domain.Exceptions;

namespace Financas.Domain.Entities
{
	public class Categoria : Entity
	{
		public Categoria(string nomeCategoria)
		{
			NomeCategoria = nomeCategoria;
		}

		public Categoria(int idCategoria, string nomeCategoria) : this(nomeCategoria)
		{
			IdCategoria = idCategoria;
		}

		protected Categoria() { } // EF
		 
		public int IdCategoria { get; private set; }
		public string NomeCategoria { get; private set; }

		public void ModificarNomeCategoria(string novoNome)
		{
			if (string.IsNullOrEmpty(novoNome))
				throw new DomainException("O novo nome da categoria não pode ser em branco");

			if (novoNome.Length < 5)
				throw new DomainException("O novo nome da categoria não pode conter menos que 5 caracteres");

			this.NomeCategoria = novoNome;
		}
	}
}