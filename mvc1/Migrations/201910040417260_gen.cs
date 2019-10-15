namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gen : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieBs", "GenreId", c => c.Int(nullable: true));
            CreateIndex("dbo.MovieBs", "GenreId");
            AddForeignKey("dbo.MovieBs", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieBs", "GenreId", "dbo.Genres");
            DropIndex("dbo.MovieBs", new[] { "GenreId" });
            DropColumn("dbo.MovieBs", "GenreId");
        }
    }
}
