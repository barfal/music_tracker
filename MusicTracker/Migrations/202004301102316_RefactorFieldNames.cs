namespace MusicTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorFieldNames : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Participations", name: "UserId", newName: "ParticipatingUserId");
            RenameIndex(table: "dbo.Participations", name: "IX_UserId", newName: "IX_ParticipatingUserId");
            AddColumn("dbo.Notifications", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Notifications", "NotificationType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "NotificationType", c => c.Int(nullable: false));
            DropColumn("dbo.Notifications", "Type");
            RenameIndex(table: "dbo.Participations", name: "IX_ParticipatingUserId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Participations", name: "ParticipatingUserId", newName: "UserId");
        }
    }
}
