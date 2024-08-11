namespace EIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSocialMediaInformationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SocialMediaInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GeneralInformationId = c.Int(nullable: false),
                        ProfileName = c.String(),
                        ProfileLink = c.String(),
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
                .ForeignKey("dbo.GeneralInformations", t => t.GeneralInformationId, cascadeDelete: false)
                .Index(t => t.GeneralInformationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SocialMediaInformations", "GeneralInformationId", "dbo.GeneralInformations");
            DropIndex("dbo.SocialMediaInformations", new[] { "GeneralInformationId" });
            DropTable("dbo.SocialMediaInformations");
        }
    }
}
