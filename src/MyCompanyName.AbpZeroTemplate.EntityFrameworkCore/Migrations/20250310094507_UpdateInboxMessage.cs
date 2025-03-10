using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCompanyName.AbpZeroTemplate.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInboxMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MessageId",
                table: "InboxMessages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MessageType",
                table: "InboxMessages",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MessageType",
                table: "InboxMessages");

            migrationBuilder.AlterColumn<string>(
                name: "MessageId",
                table: "InboxMessages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
