using Microsoft.EntityFrameworkCore.Migrations;

namespace Etickets_Platform.Migrations
{
    public partial class ModifiedDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "profilePicture",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "MovieCategorie",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "movieName",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Desciption",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "profilePicture",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Producers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Cinemas",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "logo",
                table: "Cinemas",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "Actors",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureURL",
                table: "Producers",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieCategory",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cinemas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureURL",
                table: "Actors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePictureURL",
                table: "Producers");

            migrationBuilder.DropColumn(
                name: "MovieCategory",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "ProfilePictureURL",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Producers",
                newName: "fullName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cinemas",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Cinemas",
                newName: "logo");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Actors",
                newName: "fullName");

            migrationBuilder.AddColumn<string>(
                name: "profilePicture",
                table: "Producers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Movies",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "MovieCategorie",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "movieName",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Desciption",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "profilePicture",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
