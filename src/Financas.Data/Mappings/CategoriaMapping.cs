using Financas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.Data.Mappings
{
	public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
	{
		public void Configure(EntityTypeBuilder<Categoria> builder)
		{
			builder.ToTable("Categoria");

			builder.HasKey(c => c.IdCategoria).HasName("idCategoria");
			builder.Property(c => c.IdCategoria).ValueGeneratedOnAdd();
		}
	}
}