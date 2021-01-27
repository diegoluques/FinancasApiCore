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
	public class ContaFinanceiraController : ApiBase
	{
		private readonly IContaFinanceiraRepository _contaFinanceiraRepository;

		public ContaFinanceiraController(IContaFinanceiraRepository contaFinanceiraRepository)
		{
			_contaFinanceiraRepository = contaFinanceiraRepository;
		}

		[HttpGet]
		public IEnumerable<ContaFinanceira> Get() => _contaFinanceiraRepository.GetAll();

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
			contaFinanceira.ModificarNomeContaFinanceira(command.NomeContaFinanceira);
			contaFinanceira.ModificarPessoaContaFinanceira(command.IdPessoa);

			_contaFinanceiraRepository.Update(contaFinanceira);

			return contaFinanceira;
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var contaFinanceira = _contaFinanceiraRepository.Get(id);
			_contaFinanceiraRepository.Delete(contaFinanceira);
		}
	}
}