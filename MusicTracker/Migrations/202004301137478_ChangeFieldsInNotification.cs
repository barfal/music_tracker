namespace MusicTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldsInNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OldDateTime", c => c.DateTime());
            AddColumn("dbo.Notifications", "OldGigPlace", c => c.String());
            DropColumn("dbo.Notifications", "ChangedDateTime");
            DropColumn("dbo.Notifications", "ChangedGigPlace");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "ChangedGigPlace", c => c.String());
            AddColumn("dbo.Notifications", "ChangedDateTime", c => c.DateTime());
            DropColumn("dbo.Notifications", "OldGigPlace");
            DropColumn("dbo.Notifications", "OldDateTime");
        }
    }
}
