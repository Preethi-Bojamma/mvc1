namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.customers");
        }
    }
}
