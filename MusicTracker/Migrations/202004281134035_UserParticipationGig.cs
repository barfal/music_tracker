namespace MusicTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserParticipationGig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserParticipationGigs",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GigId, t.UserId })
                .ForeignKey("dbo.Gigs", t => t.GigId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GigId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserParticipationGigs", "ParticipatingUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserParticipationGigs", "GigId", "dbo.Gigs");
            DropIndex("dbo.UserParticipationGigs", new[] { "ParticipatingUserId" });
            DropIndex("dbo.UserParticipationGigs", new[] { "GigId" });
            DropTable("dbo.UserParticipationGigs");
        }
    }
}
