namespace Orix.MeuControle.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoMappingAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_AUTENTICACAO",
                c => new
                    {
                        DS_USUARIO = c.String(nullable: false, maxLength: 50, unicode: false),
                        DS_SENHA = c.String(nullable: false, maxLength: 15, unicode: false),
                        DS_EMAIL = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.DS_USUARIO);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_AUTENTICACAO");
        }
    }
}
