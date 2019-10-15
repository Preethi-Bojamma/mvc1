namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genereDeletion : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovieBs", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieBs", "Genre", c => c.String());
        }
    }
}
