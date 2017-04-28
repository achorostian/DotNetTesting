namespace Gym.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2tables31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Equipment", "Room_RoomId", "dbo.Room");
            DropIndex("dbo.Equipment", new[] { "Room_RoomId" });
            RenameColumn(table: "dbo.Equipment", name: "Room_RoomId", newName: "RoId");
            AlterColumn("dbo.Equipment", "RoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Equipment", "RoId");
            AddForeignKey("dbo.Equipment", "RoId", "dbo.Room", "RoomId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Equipment", "RoId", "dbo.Room");
            DropIndex("dbo.Equipment", new[] { "RoId" });
            AlterColumn("dbo.Equipment", "RoId", c => c.Int());
            RenameColumn(table: "dbo.Equipment", name: "RoId", newName: "Room_RoomId");
            CreateIndex("dbo.Equipment", "Room_RoomId");
            AddForeignKey("dbo.Equipment", "Room_RoomId", "dbo.Room", "RoomId");
        }
    }
}
