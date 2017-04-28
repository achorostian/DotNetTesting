namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conventions : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Addresses", newName: "Address");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Address", newName: "Addresses");
        }
    }
}
