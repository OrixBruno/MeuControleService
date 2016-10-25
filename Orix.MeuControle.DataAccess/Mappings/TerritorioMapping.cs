using Orix.MeuControle.Domain.Mapa;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class TerritorioMapping : EntityTypeConfiguration<TerritorioDomainModel>
    {
        public TerritorioMapping()
        {
            ToTable("TB_TERRITORIO");

            HasKey(x => x.ID);

            Property(x => x.Nome).HasMaxLength(100).HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute() { IsUnique = true })).IsRequired().HasColumnName("NM_TERRITORIO");
        }
    }
}
