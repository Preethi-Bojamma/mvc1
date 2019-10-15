namespace mvc1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("Insert genres(Name)values('Family')");
            Sql("Insert genres(Name)values('Kids')");
            Sql("Insert genres(Name)values('Fiction')");
            Sql("Insert genres(Name)values('Action')");
            Sql("Insert genres(Name)values('Thriller')");
        }
        
        public override void Down()
        {
        }
    }
}
