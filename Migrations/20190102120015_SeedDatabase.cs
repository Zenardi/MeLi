using Microsoft.EntityFrameworkCore.Migrations;

namespace meli.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Makers (Name) VALUES ('Maker1')");
            migrationBuilder.Sql("INSERT INTO Makers (Name) VALUES ('Maker2')");
            migrationBuilder.Sql("INSERT INTO Makers (Name) VALUES ('Maker3')");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelA', (SELECT ID FROM Makers WHERE Name='Maker1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelB', (SELECT ID FROM Makers WHERE Name='Maker1'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelC', (SELECT ID FROM Makers WHERE Name='Maker1'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelA', (SELECT ID FROM Makers WHERE Name='Maker2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelB', (SELECT ID FROM Makers WHERE Name='Maker2'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelC', (SELECT ID FROM Makers WHERE Name='Maker2'))");


            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelA', (SELECT ID FROM Makers WHERE Name='Maker3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelB', (SELECT ID FROM Makers WHERE Name='Maker3'))");
            migrationBuilder.Sql("INSERT INTO Models (Name, MakerId) VALUES ('Maker1-ModelC', (SELECT ID FROM Makers WHERE Name='Maker3'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DELTE FROM Makers WHERE Name in ('Maker1', 'Maker2', 'Maker3')");

            //migrationBuilder.Sql("DELTE FROM Models");
        }
    }
}
