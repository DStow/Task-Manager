namespace TaskManagerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeletedFieldsToProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Projects", "DeletedWhen", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "DeletedWhen");
            DropColumn("dbo.Projects", "Deleted");
        }
    }
}
