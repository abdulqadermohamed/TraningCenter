namespace TraningCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hd : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Student_Courses");
            DropPrimaryKey("dbo.Instr_Courses");
            AddColumn("dbo.Student_Courses", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Instr_Courses", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Student_Courses", "Id");
            AddPrimaryKey("dbo.Instr_Courses", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Instr_Courses");
            DropPrimaryKey("dbo.Student_Courses");
            DropColumn("dbo.Instr_Courses", "Id");
            DropColumn("dbo.Student_Courses", "Id");
            AddPrimaryKey("dbo.Instr_Courses", new[] { "Instractor_Id", "Course_Id" });
            AddPrimaryKey("dbo.Student_Courses", new[] { "Student_id", "Course_Id" });
        }
    }
}
