using Financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Data.Mappings
{
	public class ContaFinanceiraMapping : IEntityTypeConfiguration<ContaFinanceira>
	{
		public void Configure(EntityTypeBuilder<ContaFinanceira> builder)
		{
			builder.ToTable("ContaFinanceira");

			builder.HasKey(c => c.IdContaFinanceira).HasName("idContaFinanceira");
			builder.Property(c => c.IdContaFinanceira).ValueGeneratedOnAdd();

			builder.HasOne(c => c.Pessoa).WithMany(c => c.Contas).HasForeignKey(m => m.IdPessoa);
		}
	}
}