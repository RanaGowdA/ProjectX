using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerRelationshipManagement.Data.Migrations
{
    public partial class intialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_TemplateConfigurations_TemplateConfigurationId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_TemplateConfigurationId",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TemplateConfigurationId",
                table: "Accounts",
                column: "TemplateConfigurationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_TemplateConfigurations_TemplateConfigurationId",
                table: "Accounts",
                column: "TemplateConfigurationId",
                principalTable: "TemplateConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
