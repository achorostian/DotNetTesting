namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2tables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Amount = c.Int(nullable: false),
                        Room_RoomId = c.Int(),
                    })
                .PrimaryKey(t => t.EquipmentId)
                .ForeignKey("dbo.Room", t => t.Room_RoomId)
                .Index(t => t.Room_RoomId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Capacity = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment", "Room_RoomId", "dbo.Room");
            DropIndex("dbo.Equipment", new[] { "Room_RoomId" });
            DropTable("dbo.Room");
            DropTable("dbo.Equipment");
        }
    }
}
