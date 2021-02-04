using Financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Data.Mappings
{
	public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
	{
		public void Configure(EntityTypeBuilder<Pessoa> builder)
		{
			builder.ToTable("Pessoa");

			builder.HasKey(c => c.IdPessoa).HasName("idPessoa");
			builder.Property(c => c.IdPessoa).ValueGeneratedOnAdd(); 
		}
	}
}