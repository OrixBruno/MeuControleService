using Orix.MeuControle.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orix.MeuControle.DataAccess.Mappings
{
    class AutenticacaoMapping : EntityTypeConfiguration<ContaDomainModel>
    {
        public AutenticacaoMapping()
        {
            ToTable("TB_AUTENTICACAO");
            HasKey(x => x.Usuario);

            Property(x => x.Usuario).HasColumnName("DS_USUARIO").HasMaxLength(50).IsRequired();
            Property(x => x.Senha).HasColumnName("DS_SENHA").HasMaxLength(15).IsRequired();
            Property(x => x.Email).HasColumnName("DS_EMAIL").HasMaxLength(50).IsRequired();
        }
    }
}
