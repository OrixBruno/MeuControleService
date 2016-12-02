using Orix.MeuControle.Domain.Mapa;
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
    public sealed class EmprestimoMapping : EntityTypeConfiguration<EmprestimoDomainModel>
    {
        public EmprestimoMapping()
        {
            ToTable("TB_EMPRESTIMO");
            HasKey(x => x.ID);

            Property(x => x.IDMapa).HasColumnName("FK_ID_MAPA").HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true }));
            Property(x => x.Publicador).HasColumnName("DS_PUBLICADOR").HasMaxLength(300).IsRequired();
            Property(x => x.DataDevolucao).HasColumnName("DT_DEVOLUCAO");
            Property(x => x.DataEmprestimo).HasColumnName("DT_EMPRESTIMO").IsRequired();

            HasOptional(x => x.Mapa)
                .WithMany(x => x.Emprestimo)
                .HasForeignKey(x => x.IDMapa);
        }
    }
}
