﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bookCollection.Models;

namespace bookCollection.Migrations
{
    [DbContext(typeof(BookDBContext))]
    partial class BookDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("bookCollection.Models.BookDBContext+Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bbca9711-b2e9-4c00-a209-9e3c4c6d7f1b"),
                            Author = "J.K. Rowling",
                            Description = "Story of wizard",
                            Name = "Harry Potter 1"
                        },
                        new
                        {
                            Id = new Guid("f71ac3a3-2dc6-4692-80e8-4c05b498ac5c"),
                            Author = "J.R.R Tolkien",
                            Description = "Tale of the ring",
                            Name = "Lord of the Rings"
                        },
                        new
                        {
                            Id = new Guid("0a1d19a4-3fc1-4e6f-aa78-81f0488ba9a3"),
                            Author = "Various",
                            Description = "The book of cooking",
                            Name = "Supreme Cooking book"
                        },
                        new
                        {
                            Id = new Guid("7c805f3a-763a-4315-9be1-c5b02482d357"),
                            Author = "Book author",
                            Description = "Just filling database",
                            Name = "Random Generator"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
