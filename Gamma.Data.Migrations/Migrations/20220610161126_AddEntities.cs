using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gamma.Data.EF.Migrations
{
    public partial class AddEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomainId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                    table.ForeignKey(
                        name: "FK_Domains_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: false),
                    DomainId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                    table.ForeignKey(
                        name: "FK_Sites_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Sites_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SitePages",
                columns: table => new
                {
                    SitePageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ContentJson = table.Column<string>(type: "nvarchar(max)", maxLength: 5000000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitePages", x => x.SitePageId);
                    table.ForeignKey(
                        name: "FK_SitePages_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaResourceRevisions",
                columns: table => new
                {
                    MediaResourceRevisionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaResourceId = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaResourceRevisions", x => x.MediaResourceRevisionId);
                });

            migrationBuilder.CreateTable(
                name: "MediaResources",
                columns: table => new
                {
                    MediaResourceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaResourceUid = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SiteId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    LastRevisionId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DefaultAltText = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaResources", x => x.MediaResourceId);
                    table.ForeignKey(
                        name: "FK_MediaResources_MediaResourceRevisions_LastRevisionId",
                        column: x => x.LastRevisionId,
                        principalTable: "MediaResourceRevisions",
                        principalColumn: "MediaResourceRevisionId");
                    table.ForeignKey(
                        name: "FK_MediaResources_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domains_OwnerId",
                table: "Domains",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaResourceRevisions_MediaResourceId",
                table: "MediaResourceRevisions",
                column: "MediaResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaResources_LastRevisionId",
                table: "MediaResources",
                column: "LastRevisionId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaResources_SiteId",
                table: "MediaResources",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_SitePages_SiteId",
                table: "SitePages",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_DomainId",
                table: "Sites",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_OwnerId",
                table: "Sites",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaResourceRevisions_MediaResources_MediaResourceId",
                table: "MediaResourceRevisions",
                column: "MediaResourceId",
                principalTable: "MediaResources",
                principalColumn: "MediaResourceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaResourceRevisions_MediaResources_MediaResourceId",
                table: "MediaResourceRevisions");

            migrationBuilder.DropTable(
                name: "SitePages");

            migrationBuilder.DropTable(
                name: "MediaResources");

            migrationBuilder.DropTable(
                name: "MediaResourceRevisions");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
