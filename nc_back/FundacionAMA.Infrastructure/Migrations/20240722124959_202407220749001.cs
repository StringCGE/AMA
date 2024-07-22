using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundacionAMA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _202407220749001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_grupoCliente_grupo_GrupoId1",
                table: "grupoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_grupoCliente_person_ClienteId",
                table: "grupoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_grupoCliente",
                table: "grupoCliente");

            migrationBuilder.DropIndex(
                name: "IX_grupoCliente_ClienteId",
                table: "grupoCliente");

            migrationBuilder.DropIndex(
                name: "IX_grupoCliente_GrupoId1",
                table: "grupoCliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "grupoCliente");

            migrationBuilder.DropColumn(
                name: "GrupoId1",
                table: "grupoCliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrupoCliente_ID",
                table: "grupoCliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupoCliente_Cliente_Id",
                table: "grupoCliente",
                column: "Cliente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupoCliente_Grupo_Id",
                table: "grupoCliente",
                column: "Grupo_Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupoCliente_Id",
                table: "grupoCliente",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "Fk_Cliente_Id",
                table: "grupoCliente",
                column: "Cliente_Id",
                principalTable: "person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "Fk_Grupo_Id",
                table: "grupoCliente",
                column: "Grupo_Id",
                principalTable: "grupo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Cliente_Id",
                table: "grupoCliente");

            migrationBuilder.DropForeignKey(
                name: "Fk_Grupo_Id",
                table: "grupoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrupoCliente_ID",
                table: "grupoCliente");

            migrationBuilder.DropIndex(
                name: "IX_grupoCliente_Cliente_Id",
                table: "grupoCliente");

            migrationBuilder.DropIndex(
                name: "IX_grupoCliente_Grupo_Id",
                table: "grupoCliente");

            migrationBuilder.DropIndex(
                name: "IX_grupoCliente_Id",
                table: "grupoCliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "grupoCliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GrupoId1",
                table: "grupoCliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_grupoCliente",
                table: "grupoCliente",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_grupoCliente_ClienteId",
                table: "grupoCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_grupoCliente_GrupoId1",
                table: "grupoCliente",
                column: "GrupoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_grupoCliente_grupo_GrupoId1",
                table: "grupoCliente",
                column: "GrupoId1",
                principalTable: "grupo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_grupoCliente_person_ClienteId",
                table: "grupoCliente",
                column: "ClienteId",
                principalTable: "person",
                principalColumn: "Id");
        }
    }
}
