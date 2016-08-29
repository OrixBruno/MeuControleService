using Orix.MeuControle.Domain.Mapa;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class TerritorioMapping : EntityTypeConfiguration<TerritorioDomainModel>
    {
        public TerritorioMapping()
        {
            ToTable("TB_TERRITORIO");

            HasKey(x => x.ID);

            Property(x => x.Nome).HasMaxLength(100).IsRequired().HasColumnName("NM_TERRITORIO");
        }
    }
}
