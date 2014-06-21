namespace demo01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regras",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.RegraDeUsuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Regras", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Usuario", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                        Nome = c.String(),
                        SobreNome = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Cidade = c.String(),
                        Estado = c.String(),
                        PostalCode = c.String(),
                        PhonePrimary = c.String(),
                        PhoneSecondary = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.SolicitacoesDeUsuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.LoginDeUsuario",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Usuario", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegraDeUsuario", "IdentityUser_Id", "dbo.Usuario");
            DropForeignKey("dbo.LoginDeUsuario", "IdentityUser_Id", "dbo.Usuario");
            DropForeignKey("dbo.SolicitacoesDeUsuario", "IdentityUser_Id", "dbo.Usuario");
            DropForeignKey("dbo.RegraDeUsuario", "RoleId", "dbo.Regras");
            DropIndex("dbo.LoginDeUsuario", new[] { "IdentityUser_Id" });
            DropIndex("dbo.SolicitacoesDeUsuario", new[] { "IdentityUser_Id" });
            DropIndex("dbo.RegraDeUsuario", new[] { "IdentityUser_Id" });
            DropIndex("dbo.RegraDeUsuario", new[] { "RoleId" });
            DropIndex("dbo.Regras", "RoleNameIndex");
            DropTable("dbo.LoginDeUsuario");
            DropTable("dbo.SolicitacoesDeUsuario");
            DropTable("dbo.Usuario");
            DropTable("dbo.RegraDeUsuario");
            DropTable("dbo.Regras");
        }
    }
}
