namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class membership : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "MembershipTypeId", c => c.Int(nullable: true));
            CreateIndex("dbo.customers", "MembershipTypeId");
            AddForeignKey("dbo.customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.customers", "MembershipTypeId");
        }
    }
}
