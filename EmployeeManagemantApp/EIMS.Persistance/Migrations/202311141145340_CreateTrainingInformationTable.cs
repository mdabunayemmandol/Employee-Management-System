namespace EIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTrainingInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        CourseName = c.String(),
                        Result = c.String(),
                        InstituteName = c.String(),
                        Institute = c.String(),
                        Duration = c.String(),
                        Year = c.String(),
                        Remark = c.String(),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GeneralInformations", t => t.GeneralInformationId, cascadeDelete: true)
                .Index(t => t.GeneralInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.TrainingInformations", new[] { "GeneralInformationId" });
            DropTable("dbo.TrainingInformations");
        }
    }
}
