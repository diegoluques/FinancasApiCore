using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using Financas.WebApi.Commands;
using Financas.WebApi.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Financas.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriaController : ApiBase
	{
		private readonly ICategoriaRepository _categoriaRepository;

		public CategoriaController(ICategoriaRepository categoriaRepository)
		{
			_categoriaRepository = categoriaRepository;
		}

		[HttpGet]
		public IEnumerable<Categoria> Get() => _categoriaRepository.GetAll();

		[HttpGet("{id}")]
		public Categoria Get(int id) => _categoriaRepository.Get(id);

		[HttpPost]
		public Categoria Post([FromBody] CriarCategoriaCommand command)
		{
			var categoria = new Categoria(command.NomeCategoria);
			_categoriaRepository.Save(categoria);

			return categoria;
		}

		[HttpPut("{id}")]
		public Categoria Put(int id, [FromBody] AtualizarCategoriaCommand command)
		{
			var categoria = _categoriaRepository.Get(id);
			categoria.ModificarNomeCategoria(command.NomeCategoria);

			_categoriaRepository.Update(categoria);

			return categoria;
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var categoria = _categoriaRepository.Get(id);
			_categoriaRepository.Delete(categoria);
		}
	}
}