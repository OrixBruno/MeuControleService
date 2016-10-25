using Orix.MeuControle.Domain.Mapa;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class LetraMapping : EntityTypeConfiguration<LetraDomainModel>
    {
        public LetraMapping()
        {
            ToTable("TB_LETRA");

            HasKey(x => x.ID);

            Property(x => x.Letra).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true })).IsFixedLength().IsRequired().HasColumnName("NM_LETRA");
            Property(x => x.Descricao).HasMaxLength(300).HasColumnName("DS_LETRA");
        }        
    }
}
