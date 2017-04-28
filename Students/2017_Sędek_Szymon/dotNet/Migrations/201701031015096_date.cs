namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TrainingRoom", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingRoom", "EndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TrainingRoom", "EndDate", c => c.String());
            AlterColumn("dbo.TrainingRoom", "StartDate", c => c.String());
        }
    }
}
