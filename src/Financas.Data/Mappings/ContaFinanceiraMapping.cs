using Financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Data.Mappings
{
	public class ContaFinanceiraMapping
	{
		public void Configure(EntityTypeBuilder<ContaFinanceira> builder)
		{
			builder.ToTable("contaFinanceira");

			builder.HasKey(c => c.IdContaFinanceira).HasName("idContaFinanceira");
			builder.Property(c => c.IdContaFinanceira).ValueGeneratedOnAdd();
		}
	}
}