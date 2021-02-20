﻿// <auto-generated />
using System;
using McShares_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace McShares_API.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20210220205543_init_migrat")]
    partial class init_migrat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("McShares_API.Models.DataItem_Customer", b =>
                {
                    b.Property<string>("customer_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address_Line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address_Line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Customer_Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Date_Incorp")
                        .HasColumnType("Date");

                    b.Property<DateTime>("Date_Of_Birth")
                        .HasColumnType("Date");

                    b.Property<int>("Num_Shares")
                        .HasColumnType("int");

                    b.Property<string>("REGISTRATION_NO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Share_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Town_City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("requestDocumentrequest_Document_Id")
                        .HasColumnType("int");

                    b.Property<int>("request_Document_Id")
                        .HasColumnType("int");

                    b.HasKey("customer_id");

                    b.HasIndex("requestDocumentrequest_Document_Id");

                    b.ToTable("dataItem_Customer");
                });

            modelBuilder.Entity("McShares_API.Models.RequestDocument", b =>
                {
                    b.Property<int>("request_Document_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Doc_Date")
                        .HasColumnType("Date");

                    b.Property<string>("Doc_Ref")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("request_Document_Id");

                    b.ToTable("requestDocument");
                });

            modelBuilder.Entity("McShares_API.Models.DataItem_Customer", b =>
                {
                    b.HasOne("McShares_API.Models.RequestDocument", "requestDocument")
                        .WithMany()
                        .HasForeignKey("requestDocumentrequest_Document_Id");

                    b.Navigation("requestDocument");
                });
#pragma warning restore 612, 618
        }
    }
}
