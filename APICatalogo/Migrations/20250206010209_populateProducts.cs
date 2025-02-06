using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class populateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO \"Products\"(\"Name\", \"Description\", \"Price\", \"ImageUrl\", \"Stock\", \"RegistrationDate\", \"CategoryId\") " +
                "VALUES('Coca-Cola', 'Refrigerante de cola', 5.45, 'coca.jpg', 50, '2022-01-01', 1)");

            mb.Sql("INSERT INTO \"Products\"(\"Name\", \"Description\", \"Price\", \"ImageUrl\", \"Stock\", \"RegistrationDate\", \"CategoryId\") " +
                "Values('Lanche de Frango', 'Lanche de frango com queijo', 12.75, 'lanche_frango.jpg', 100, '2022-01-01', 2)");

            mb.Sql("INSERT INTO \"Products\"(\"Name\", \"Description\", \"Price\", \"ImageUrl\", \"Stock\", \"RegistrationDate\", \"CategoryId\") " +
                "Values('Pudim', 'Pudim de leite condensado', 7.50, 'pudim.jpg', 30, '2022-01-01', 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {

        }
    }
}
