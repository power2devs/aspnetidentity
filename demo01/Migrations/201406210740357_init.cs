namespace demo01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "DataDeNascimento", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuario", "DataDeNascimento");
        }
    }
}
