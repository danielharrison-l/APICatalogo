using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulateCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO \"Categories\"(\"Name\", \"ImageUrl\") VALUES('Bebidas', 'bebidas.jpg')");
            mb.Sql("INSERT INTO \"Categories\"(\"Name\", \"ImageUrl\") VALUES('Lanches', 'lanches.jpg')");
            mb.Sql("INSERT INTO \"Categories\"(\"Name\", \"ImageUrl\") VALUES('Sobremesas', 'sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from \"Categories\"");
        }
    }
}