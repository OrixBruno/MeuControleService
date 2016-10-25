using Orix.MeuControle.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
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
            HasKey(x => x.ID);

            Property(x => x.Codigo).HasColumnName("NR_CODIGO").HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property(x => x.Genero).HasColumnName("DS_GENERO").HasMaxLength(50);
            Property(x => x.Idade).HasColumnName("NR_IDADE");
            Property(x => x.Nome).HasColumnName("NM_SURDO").HasMaxLength(50);
            Property(x => x.Observacao).HasColumnName("DS_OBSERVACAO").HasMaxLength(250);
            Property(x => x.Bairro).HasColumnName("DS_BAIRRO_LOGRADOURO").HasMaxLength(100);
            Property(x => x.Numero).HasColumnName("NR_NUMERO_LOGRADOURO");
            Property(x => x.Rua).HasColumnName("DS_RUA_LOGRADOURO").HasMaxLength(100);
            Property(x => x.DataCadastro).HasColumnName("DS_DATA_CADASTRO").IsRequired();
            Property(x => x.DataModificacao).HasColumnName("DS_DATA_MODIFICACAO").IsRequired();
            Property(x => x.IdMapa).HasColumnName("FK_ID_MAPA");

            HasOptional(x => x.Mapa)
                .WithMany(x => x.Surdos)
                .HasForeignKey(x => x.IdMapa);
        }
    }
}
