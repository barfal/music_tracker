namespace MusicTracker.Migrations
{
		using System.Data.Entity.Migrations;

		public partial class FillGenresTable : DbMigration
		{
				public override void Up()
				{
						Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Jazz')");
						Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Rock')");
						Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Blues')");
						Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Disco')");
						Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Pop')");
				}

				public override void Down()
				{
						Sql("DELETE FROM Genres WHERE Id IN (1,2,3,4,5)");
				}
		}
}