namespace EIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEducationalInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EducationalInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        UniversityId = c.Int(nullable: false),
                        InstituteName = c.String(),
                        SubjectId = c.Int(nullable: false),
                        SubjectName = c.String(),
                        Result = c.String(),
                        PassingYear = c.String(),
                        Duration = c.String(),
                        BoardName = c.String(),
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
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.GeneralInformationId)
                .Index(t => t.UniversityId)
                .Index(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EducationalInformations", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.EducationalInformations", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.EducationalInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.EducationalInformations", new[] { "SubjectId" });
            DropIndex("dbo.EducationalInformations", new[] { "UniversityId" });
            DropIndex("dbo.EducationalInformations", new[] { "GeneralInformationId" });
            DropTable("dbo.EducationalInformations");
        }
    }
}
