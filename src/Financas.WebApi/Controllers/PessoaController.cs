using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using Financas.WebApi.Commands;
using Financas.WebApi.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Financas.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PessoaController : ApiBase
	{
		private readonly IPessoaRepository _pessoaRepository;

		public PessoaController(IPessoaRepository pessoaRepository)
		{
			_pessoaRepository = pessoaRepository;
		}

		// GET: api/<PessoaController>
		[HttpGet]
		public IEnumerable<Pessoa> Get()
		{
			return _pessoaRepository.GetAll();
		}

		// GET api/<PessoaController>/5
		[HttpGet("{id}")]
		public Pessoa Get(int id)
		{
			return _pessoaRepository.Get(id);
		}

		// POST api/<PessoaController>
		[HttpPost]
		public Pessoa Post([FromBody] CriarPessoaCommand command)
		{
			var pessoa = new Pessoa(command.NomePessoa);
			_pessoaRepository.Save(pessoa);

			return pessoa;
		}

		// PUT api/<PessoaController>/5
		[HttpPut("{id}")]
		public Pessoa Put(int id, [FromBody] AtualizarPessoaCommand command)
		{
			var pessoa = _pessoaRepository.Get(id);
			pessoa.ModificarNomePessoa(command.NomePessoa);

			_pessoaRepository.Update(pessoa);

			return pessoa;
		}

		// DELETE api/<PessoaController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var pessoa = _pessoaRepository.Get(id);
			_pessoaRepository.Delete(pessoa);
		}
	}
}