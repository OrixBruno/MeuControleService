namespace Orix.MeuControle.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_EMPRESTIMO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FK_ID_MAPA = c.Int(),
                        DS_PUBLICADOR = c.String(nullable: false, maxLength: 300, unicode: false),
                        DT_EMPRESTIMO = c.DateTime(nullable: false),
                        DT_DEVOLUCAO = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_MAPA", t => t.FK_ID_MAPA)
                .Index(t => t.FK_ID_MAPA, unique: true);
            
            CreateTable(
                "dbo.TB_MAPA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DS_NUMERO = c.Int(nullable: false),
                        DS_COLOR = c.String(maxLength: 100, unicode: false),
                        DS_URL_FOTO = c.String(maxLength: 300, unicode: false),
                        FK_ID_LETRA = c.Int(nullable: false),
                        FK_ID_SAIDA = c.Int(),
                        FK_ID_TERRITORIO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_LETRA", t => t.FK_ID_LETRA)
                .ForeignKey("dbo.TB_SAIDA", t => t.FK_ID_SAIDA)
                .ForeignKey("dbo.TB_TERRITORIO", t => t.FK_ID_TERRITORIO)
                .Index(t => t.FK_ID_LETRA)
                .Index(t => t.FK_ID_SAIDA)
                .Index(t => t.FK_ID_TERRITORIO);
            
            CreateTable(
                "dbo.TB_LETRA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NM_LETRA = c.String(nullable: false, maxLength: 128, unicode: false),
                        DS_LETRA = c.String(maxLength: 300, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.NM_LETRA, unique: true);
            
            CreateTable(
                "dbo.TB_SAIDA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NM_LOCAL = c.String(nullable: false, maxLength: 100, unicode: false),
                        DS_LOGRADOURO = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.NM_LOCAL, unique: true);
            
            CreateTable(
                "dbo.TB_SURDO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NR_CODIGO = c.Int(nullable: false),
                        NM_SURDO = c.String(maxLength: 50, unicode: false),
                        DS_GENERO = c.String(maxLength: 50, unicode: false),
                        NR_IDADE = c.Int(nullable: false),
                        DS_RUA_LOGRADOURO = c.String(maxLength: 100, unicode: false),
                        NR_NUMERO_LOGRADOURO = c.Int(nullable: false),
                        DS_BAIRRO_LOGRADOURO = c.String(maxLength: 100, unicode: false),
                        DS_OBSERVACAO = c.String(maxLength: 250, unicode: false),
                        DS_DATA_CADASTRO = c.DateTime(nullable: false),
                        DS_DATA_MODIFICACAO = c.DateTime(nullable: false),
                        FK_ID_MAPA = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_MAPA", t => t.FK_ID_MAPA)
                .Index(t => t.NR_CODIGO, unique: true)
                .Index(t => t.FK_ID_MAPA);
            
            CreateTable(
                "dbo.TB_TERRITORIO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NM_TERRITORIO = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.NM_TERRITORIO, unique: true);
            
            CreateTable(
                "dbo.TB_FOTO",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DS_URL = c.String(maxLength: 500, unicode: false),
                        DS_FOTO = c.String(maxLength: 300, unicode: false),
                        Mapa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TB_MAPA", t => t.Mapa_ID)
                .Index(t => t.Mapa_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TB_FOTO", "Mapa_ID", "dbo.TB_MAPA");
            DropForeignKey("dbo.TB_EMPRESTIMO", "FK_ID_MAPA", "dbo.TB_MAPA");
            DropForeignKey("dbo.TB_MAPA", "FK_ID_TERRITORIO", "dbo.TB_TERRITORIO");
            DropForeignKey("dbo.TB_SURDO", "FK_ID_MAPA", "dbo.TB_MAPA");
            DropForeignKey("dbo.TB_MAPA", "FK_ID_SAIDA", "dbo.TB_SAIDA");
            DropForeignKey("dbo.TB_MAPA", "FK_ID_LETRA", "dbo.TB_LETRA");
            DropIndex("dbo.TB_FOTO", new[] { "Mapa_ID" });
            DropIndex("dbo.TB_TERRITORIO", new[] { "NM_TERRITORIO" });
            DropIndex("dbo.TB_SURDO", new[] { "FK_ID_MAPA" });
            DropIndex("dbo.TB_SURDO", new[] { "NR_CODIGO" });
            DropIndex("dbo.TB_SAIDA", new[] { "NM_LOCAL" });
            DropIndex("dbo.TB_LETRA", new[] { "NM_LETRA" });
            DropIndex("dbo.TB_MAPA", new[] { "FK_ID_TERRITORIO" });
            DropIndex("dbo.TB_MAPA", new[] { "FK_ID_SAIDA" });
            DropIndex("dbo.TB_MAPA", new[] { "FK_ID_LETRA" });
            DropIndex("dbo.TB_EMPRESTIMO", new[] { "FK_ID_MAPA" });
            DropTable("dbo.TB_FOTO");
            DropTable("dbo.TB_TERRITORIO");
            DropTable("dbo.TB_SURDO");
            DropTable("dbo.TB_SAIDA");
            DropTable("dbo.TB_LETRA");
            DropTable("dbo.TB_MAPA");
            DropTable("dbo.TB_EMPRESTIMO");
        }
    }
}
