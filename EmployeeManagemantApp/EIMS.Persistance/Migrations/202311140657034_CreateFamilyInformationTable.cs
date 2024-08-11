namespace EIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFamilyInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        Relation = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
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
            DropForeignKey("dbo.FamilyInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.FamilyInformations", new[] { "GeneralInformationId" });
            DropTable("dbo.FamilyInformations");
        }
    }
}
