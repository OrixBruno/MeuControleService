using Orix.MeuControle.Domain.Mapa;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class FotoMapping : EntityTypeConfiguration<FotoDomainModel>
    {
        public FotoMapping()
        {
            ToTable("TB_FOTO");

            HasKey(x => x.ID)
                .HasRequired(x => x.Mapa)
                .WithOptional(x => x.Foto);

            Property(x => x.Descricao).HasMaxLength(300).HasColumnName("DS_FOTO");
            Property(x => x.URL).HasMaxLength(500).HasColumnName("DS_URL");         
        }
    }
}
