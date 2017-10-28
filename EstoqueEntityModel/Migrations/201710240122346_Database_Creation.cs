namespace EstoqueEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Database_Creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProdutoEstoques",
                c => new
                    {
                        NumeroProduto = c.String(nullable: false, maxLength: 10),
                        NomeProduto = c.String(maxLength: 20),
                        DescricaoProduto = c.String(maxLength: 50),
                        EstoqueProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroProduto)
                .Index(t => t.NumeroProduto, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ProdutoEstoques", new[] { "NumeroProduto" });
            DropTable("dbo.ProdutoEstoques");
        }
    }
}
