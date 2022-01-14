using Financas.Domain.Contracts.Repositories;
using Financas.Domain.Entities;
using Financas.WebApi.Commands;
using Financas.WebApi.Controllers.Bases;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// CQRS - Command Query Separation Responsability

namespace Financas.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContaFinanceiraController : ApiBase
	{
		private readonly IContaFinanceiraRepository _contaFinanceiraRepository;

		public ContaFinanceiraController(IContaFinanceiraRepository contaFinanceiraRepository)
		{
			_contaFinanceiraRepository = contaFinanceiraRepository;
		}

		[HttpGet]
		public IEnumerable<dynamic> Get()
		{ 
			return _contaFinanceiraRepository.GetAll().Select(c => new
			{
				idConta = c.IdContaFinanceira,
				nomeConta = c.NomeContaFinanceira,
				titular = new
				{
					idPessoa = c.Pessoa.IdPessoa,
					nomePessoa = c.Pessoa.NomePessoa,
				}
			});
		}

		[HttpGet("{id}")]
		public ContaFinanceira Get(int id) => _contaFinanceiraRepository.Get(id);

		[HttpPost]
		public ContaFinanceira Post([FromBody] CriarContaFinanceiraCommand command)
		{
			var contaFinanceira = new ContaFinanceira(command.NomeContaFinanceira, command.IdPessoa);
			_contaFinanceiraRepository.Save(contaFinanceira);

			return contaFinanceira;
		}

		[HttpPut("{id}")]
		public ContaFinanceira Put(int id, [FromBody] AtualizarContaFinanceiraCommand command)
		{
			var contaFinanceira = _contaFinanceiraRepository.Get(id);
			if (contaFinanceira == null)
				throw new ExceptionNotFound("Conta não localizada");

			contaFinanceira.ModificarNomeContaFinanceira(command.NomeContaFinanceira);

			_contaFinanceiraRepository.Update(contaFinanceira);

			return contaFinanceira;
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var contaFinanceira = _contaFinanceiraRepository.Get(id);
			if (contaFinanceira == null)
				throw new ExceptionNotFound("Conta não localizada");

			_contaFinanceiraRepository.Delete(contaFinanceira);
		}
	}
}