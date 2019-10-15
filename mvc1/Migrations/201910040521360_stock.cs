namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stock : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieBs", "AvailableStock", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieBs", "AvailableStock");
        }
    }
}
