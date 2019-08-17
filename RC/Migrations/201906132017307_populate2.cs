namespace RC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate2 : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Hospitals', 1)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Doctors', 1)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Clinics', 1)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'HighSchools', 2)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Universities', 2)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Teachers', 2)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Clubs', 3)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Soccer Coaches', 3)");
            Sql("INSERT INTO[dbo].[Categories] ([Name], [sectorId]) VALUES(N'Gyms', 3)");

        }

        public override void Down()
        {
        }
    }
}
