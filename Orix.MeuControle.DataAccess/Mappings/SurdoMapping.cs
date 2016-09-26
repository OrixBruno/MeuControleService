using Orix.MeuControle.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public class SurdoMapping : EntityTypeConfiguration<SurdoDomainModel>
    {
        public SurdoMapping()
        {
            ToTable("TB_SURDO");
            HasKey(x => x.Codigo);

            Property(x => x.Genero).HasColumnName("DS_GENERO").HasMaxLength(50).IsRequired();
            Property(x => x.Idade).HasColumnName("NR_IDADE").IsRequired();
            Property(x => x.Nome).HasColumnName("NM_SURDO").HasMaxLength(50).IsRequired();
            Property(x => x.Observacao).HasColumnName("DS_OBSERVACAO").HasMaxLength(250);
            Property(x => x.Bairro).HasMaxLength(100).HasColumnName("DS_BAIRRO_LOGRADOURO").HasMaxLength(50).IsRequired();
            Property(x => x.Numero).HasColumnName("NR_NUMERO_LOGRADOURO").IsRequired();
            Property(x => x.Rua).HasColumnName("DS_RUA_LOGRADOURO").HasMaxLength(50).IsRequired();
            Property(x => x.ID_Mapa).HasColumnName("FK_ID_MAPA").IsRequired();

            HasRequired(x => x.MapaDomainModel)
                .WithMany()
                .HasForeignKey(x => x.ID_Mapa);
        }
    }
}
