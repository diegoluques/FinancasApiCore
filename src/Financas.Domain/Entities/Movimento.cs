using Financas.Domain.Bases;
using Financas.Domain.Exceptions;
using System;

namespace Financas.Domain.Entities
{
    public class Movimento : Entity
    {
        public Movimento(DateTime dataMovimento, decimal valor, DateTime dataVencto, string descricao, int idPessoaMovimento)
        {
            TratarTipoMovimento(valor);

            this.DataMovimento = dataMovimento;
            this.ValorMovimento = valor;
        }

        private void TratarTipoMovimento(decimal valor)
        {
            if (valor < 0)
                this.TipoMovimento = "D";
            else if (valor > 0)
                this.TipoMovimento = "R";
            else
                throw new DomainException("Valor do Movimento não pode ser ZERADO");
        }

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
        public DateTime? DataPagamento { get; set; }
        public string DescricaoMovimento { get; set; }
        public string Observacao { get; set; }
        public int IdPessoaMovimento { get; set; }
        public int IdPessoaPagamento { get; set; }
        public int IdContaPagamento { get; set; }

        public void Pagar(decimal valorPago)
        {
            if (valorPago <= 0)
                throw new DomainException("Valor pago não pode ser menor ou igual a ZERO");

            this.ValorPago = valorPago;
            if (this.ValorMovimento <= this.ValorPago)
                this.IsPago = true;
        }

    }
}