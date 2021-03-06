﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace McShares_API.Migrations
{
    public partial class first_migrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logErrors",
                columns: table => new
                {
                    errorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    errorTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logErrors", x => x.errorID);
                });

            migrationBuilder.CreateTable(
                name: "requestDocument",
                columns: table => new
                {
                    request_Document_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doc_Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Doc_Ref = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requestDocument", x => x.request_Document_Id);
                });

            migrationBuilder.CreateTable(
                name: "dataItem_Customer",
                columns: table => new
                {
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Customer_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Of_Birth = table.Column<DateTime>(type: "Date", nullable: true),
                    Date_Incorp = table.Column<DateTime>(type: "Date", nullable: true),
                    REGISTRATION_NO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Town_City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Num_Shares = table.Column<int>(type: "int", nullable: false),
                    Share_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    request_Document_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dataItem_Customer", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK_dataItem_Customer_requestDocument_request_Document_Id",
                        column: x => x.request_Document_Id,
                        principalTable: "requestDocument",
                        principalColumn: "request_Document_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dataItem_Customer_request_Document_Id",
                table: "dataItem_Customer",
                column: "request_Document_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dataItem_Customer");

            migrationBuilder.DropTable(
                name: "logErrors");

            migrationBuilder.DropTable(
                name: "requestDocument");
        }
    }
}
