namespace EIMS.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GeneralInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeId = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Fathername = c.String(),
                        Mothername = c.String(),
                        PhoneNo = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        NationalId = c.String(),
                        Nationality = c.String(),
                        Gender = c.String(),
                        BloodGroup = c.String(),
                        Religon = c.String(),
                        MaritialStatus = c.String(),
                        JObJoiningDate = c.DateTime(nullable: false),
                        Salary = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        Remark = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateBy = c.String(),
                        UpdateDate = c.DateTime(),
                        DeleteBy = c.String(),
                        DeleteDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GeneralInformations", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.GeneralInformations", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.GeneralInformations", new[] { "DesignationId" });
            DropIndex("dbo.GeneralInformations", new[] { "DepartmentId" });
            DropTable("dbo.Universities");
            DropTable("dbo.Subjects");
            DropTable("dbo.GeneralInformations");
            DropTable("dbo.Designations");
            DropTable("dbo.Departments");
        }
    }
}
