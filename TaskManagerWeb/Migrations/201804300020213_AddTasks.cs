namespace TaskManagerWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTasks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        ProjectTaskId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProjectId = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedWhen = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        CompletedWhen = c.DateTime(),
                    })
                .PrimaryKey(t => t.ProjectTaskId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            DropTable("dbo.ProjectTasks");
        }
    }
}
