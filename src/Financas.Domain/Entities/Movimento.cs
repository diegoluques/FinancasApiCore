using Financas.Domain.Bases;
using System;

namespace Financas.Domain.Entities
{
	public class Movimento : Entity
	{
		public int IdMovimento { get; set; }
		public int IdCategoria { get; set; }
		public DateTime DataMovimento { get; set; }
		public decimal ValorMovimento { get; set; }
		public string TipoMovimento { get; set; }
		public DateTime DataVencimento { get; set; }
		public bool IsPago { get; set; }
		public decimal ValorPago { get; set; }
		public decimal ValorDesconto { get; set; }
		public int Parcela { get; set; }
		public int TotalParcela { get; set; }
		public string CodigoParcelamento { get; set; }
		public DateTime DataPagamento { get; set; }
		public string DescricaoMovimento { get; set; }
		public string Observacao { get; set; }
		public int IdPessoaMovimento { get; set; }
		public int IdPessoaPagamento { get; set; }
		public int IdContaPagamento { get; set; }
	}
}