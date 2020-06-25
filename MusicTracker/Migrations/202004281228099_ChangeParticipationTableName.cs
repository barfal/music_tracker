namespace MusicTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeParticipationTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserParticipationGigs", newName: "Participations");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Participations", newName: "UserParticipationGigs");
        }
    }
}
