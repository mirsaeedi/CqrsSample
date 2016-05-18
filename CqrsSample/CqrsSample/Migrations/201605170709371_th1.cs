namespace CqrsSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class th1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Fine.AuditableEntity",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LastModifierId = c.Long(nullable: false),
                        LastModifiedDateTime = c.DateTime(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Fine.EmploymentHistory",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmploymentStatusType = c.Int(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        BeginDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(),
                        StaffId = c.Int(nullable: false),
                        Staff_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Fine.Staff", t => t.Staff_Id)
                .Index(t => t.Staff_Id);
            
            CreateTable(
                "Fine.Fine",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        MinCost = c.Int(nullable: false),
                        MaxCost = c.Int(nullable: false),
                        DefaultCost = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Fine.Staff",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Fine.StaffFine",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FineId = c.Long(nullable: false),
                        StaffId = c.Long(nullable: false),
                        Cost = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Fine.Staff", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.StaffId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Fine.StaffFine", "StaffId", "Fine.Staff");
            DropForeignKey("Fine.EmploymentHistory", "Staff_Id", "Fine.Staff");
            DropIndex("Fine.StaffFine", new[] { "StaffId" });
            DropIndex("Fine.EmploymentHistory", new[] { "Staff_Id" });
            DropTable("Fine.StaffFine");
            DropTable("Fine.Staff");
            DropTable("Fine.Fine");
            DropTable("Fine.EmploymentHistory");
            DropTable("Fine.AuditableEntity");
        }
    }
}
