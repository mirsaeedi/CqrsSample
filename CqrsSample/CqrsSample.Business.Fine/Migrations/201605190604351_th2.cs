using System.Data.Entity.Migrations;

namespace CqrsSample.Business.Fine.Migrations
{
    public partial class th2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Fine.Staff", "Address", c => c.String());
            DropTable("Fine.AuditableEntity");
        }
        
        public override void Down()
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
            
            DropColumn("Fine.Staff", "Address");
        }
    }
}
