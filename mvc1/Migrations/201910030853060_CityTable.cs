namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CityTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.customers", "City");
        }
    }
}
