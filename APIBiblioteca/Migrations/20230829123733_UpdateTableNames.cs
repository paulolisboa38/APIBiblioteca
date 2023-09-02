using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Removendo chaves estrangeiras da tabela de locações.
            migrationBuilder.DropForeignKey(
                name: "FK_Locacao_Leitor_LeitorId",
                table: "Locacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacao_Livro_LivroId",
                table: "Locacao");

            // Removendo chaves primárias.
            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacao",
                table: "Locacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livro",
                table: "Livro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leitor",
                table: "Leitor");

            // Renomeando tabelas (pluralizando).
            migrationBuilder.RenameTable(
                name: "Locacao",
                newName: "Locacoes");

            migrationBuilder.RenameTable(
                name: "Livro",
                newName: "Livros");

            migrationBuilder.RenameTable(
                name: "Leitor",
                newName: "Leitores");

            // Renomeando índices.
            migrationBuilder.RenameIndex(
                name: "IX_Locacao_LivroId",
                table: "Locacoes",
                newName: "IX_Locacoes_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacao_LeitorId",
                table: "Locacoes",
                newName: "IX_Locacoes_LeitorId");

            // Alterando o tipo de coluna para CPF.
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Leitores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            // Adicionando chaves primárias novamente.
            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livros",
                table: "Livros",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leitores",
                table: "Leitores",
                column: "Id");

            // Adicionando índice único para CPF.
            migrationBuilder.CreateIndex(
                name: "IX_Leitores_CPF",
                table: "Leitores",
                column: "CPF",
                unique: true);

            // Adicionando chaves estrangeiras novamente.
            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Leitores_LeitorId",
                table: "Locacoes",
                column: "LeitorId",
                principalTable: "Leitores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Livros_LivroId",
                table: "Locacoes",
                column: "LivroId",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Leitores_LeitorId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Livros_LivroId",
                table: "Locacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locacoes",
                table: "Locacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Livros",
                table: "Livros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leitores",
                table: "Leitores");

            migrationBuilder.DropIndex(
                name: "IX_Leitores_CPF",
                table: "Leitores");

            migrationBuilder.RenameTable(
                name: "Locacoes",
                newName: "Locacao");

            migrationBuilder.RenameTable(
                name: "Livros",
                newName: "Livro");

            migrationBuilder.RenameTable(
                name: "Leitores",
                newName: "Leitor");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_LivroId",
                table: "Locacao",
                newName: "IX_Locacao_LivroId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_LeitorId",
                table: "Locacao",
                newName: "IX_Locacao_LeitorId");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Leitor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locacao",
                table: "Locacao",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Livro",
                table: "Livro",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leitor",
                table: "Leitor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacao_Leitor_LeitorId",
                table: "Locacao",
                column: "LeitorId",
                principalTable: "Leitor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacao_Livro_LivroId",
                table: "Locacao",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
