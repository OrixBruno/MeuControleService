using Orix.MeuControle.Domain.Mapa;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class MapaMapping : EntityTypeConfiguration<MapaDomainModel>
    {
        public MapaMapping()
        {
            ToTable("TB_MAPA");

            HasKey(x => x.ID);

            Property(x => x.Cor).HasMaxLength(100).HasColumnName("DS_COLOR");
            Property(x => x.Numero).HasColumnName("DS_NUMERO").IsRequired();
            Property(x => x.UrlFoto).HasMaxLength(300).HasColumnName("DS_URL_FOTO");
            Property(x => x.IdLetra).HasColumnName("FK_ID_LETRA").IsRequired();
            Property(x => x.IdSaida).HasColumnName("FK_ID_SAIDA");
            Property(x => x.IdTerritorio).HasColumnName("FK_ID_TERRITORIO").IsRequired();

            HasRequired(x => x.Letra)
                .WithMany(x => x.ListaMapa)
                .HasForeignKey(x => x.IdLetra);

            HasOptional(x => x.Saida)
                .WithMany(x => x.ListaMapa)
                .HasForeignKey(x => x.IdSaida);

            HasRequired(x => x.Territorio)
                .WithMany(x => x.ListaMapa)
                .HasForeignKey(x => x.IdTerritorio);
        }
    }
}
