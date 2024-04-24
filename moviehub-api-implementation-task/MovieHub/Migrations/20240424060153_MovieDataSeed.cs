using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieHub.Migrations
{
    /// <inheritdoc />
    public partial class MovieDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sqlFilePath = "../db/moviehub-db-data-seed.sql";
            string sqlContent = File.ReadAllText(sqlFilePath);
            migrationBuilder.Sql(sqlContent);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
