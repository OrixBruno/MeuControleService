using Orix.MeuControle.DataAccess.Mappings;
using Orix.MeuControle.Domain;
using Orix.MeuControle.Domain.Mapa;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Orix.MeuControle.DataAccess
{
    public sealed class Conexao : DbContext
    {
        public Conexao()//Data Source=(localdb)\v11.0;Initial Catalog=DBCONTROLEMAPAS;Integrated Security=True
            : base(@"Data Source = bancoprojetos.mssql.somee.com; Initial Catalog = bancoprojetos; Persist Security Info=True;User ID = Aliorus_SQLLogin_1; Password=4ouegmr6y9")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<Conexao>(new CreateDatabaseIfNotExists<Conexao>());
            //Database.SetInitializer<Conexao>(new MigrateDatabaseToLatestVersion<Conexao, Configuration>());
        }

        public DbSet<SurdoDomainModel> Surdo { get; set; }
        public DbSet<MapaDomainModel> Mapa { get; set; }
        public DbSet<LetraDomainModel> Letra { get; set; }
        public DbSet<SaidaDomainModel> Saida { get; set; }
        public DbSet<TerritorioDomainModel> Territorio { get; set; }
        public DbSet<FotoDomainModel> Foto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<String>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new MapaMapping());
            modelBuilder.Configurations.Add(new LetraMapping());
            modelBuilder.Configurations.Add(new TerritorioMapping());
            modelBuilder.Configurations.Add(new SaidaMapping());
            modelBuilder.Configurations.Add(new FotoMapping());
            modelBuilder.Configurations.Add(new SurdoMapping());
        }
    }
}
