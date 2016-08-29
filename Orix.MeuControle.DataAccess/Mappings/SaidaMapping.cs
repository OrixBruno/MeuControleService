using Orix.MeuControle.Domain.Mapa;
using System.Data.Entity.ModelConfiguration;

namespace Orix.MeuControle.DataAccess.Mappings
{
    public sealed class SaidaMapping : EntityTypeConfiguration<SaidaDomainModel>
    {
        public SaidaMapping()
        {
            ToTable("TB_SAIDA");

            HasKey(x => x.ID);

            Property(x => x.Local).HasMaxLength(100).IsRequired().HasColumnName("NM_LOCAL");
            Property(x => x.Logradouro).HasMaxLength(250).HasColumnName("DS_LOGRADOURO");
        }
    }
}
