﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flashcards.TwilightSaw.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardStacks",
                columns: table => new
                {
                    CardStackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardStacks", x => x.CardStackId);
                });

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Front = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Back = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardStackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flashcards_CardStacks_CardStackId",
                        column: x => x.CardStackId,
                        principalTable: "CardStacks",
                        principalColumn: "CardStackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudySessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    CardStackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudySessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudySessions_CardStacks_CardStackId",
                        column: x => x.CardStackId,
                        principalTable: "CardStacks",
                        principalColumn: "CardStackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardStacks_Name",
                table: "CardStacks",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_CardStackId",
                table: "Flashcards",
                column: "CardStackId");

            migrationBuilder.CreateIndex(
                name: "IX_StudySessions_CardStackId",
                table: "StudySessions",
                column: "CardStackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "StudySessions");

            migrationBuilder.DropTable(
                name: "CardStacks");
        }
    }
}
