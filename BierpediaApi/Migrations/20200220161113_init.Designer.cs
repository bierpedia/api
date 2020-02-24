﻿// <auto-generated />
using System;
using Bierpedia.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Bierpedia.Api.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200220161113_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("bierpedia")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Bierpedia.Api.Model.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("ABV")
                        .HasColumnName("abv")
                        .HasColumnType("numeric");

                    b.Property<int>("ConcernId")
                        .HasColumnName("concern_id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ConcernId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("beers");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.BeerBrewery", b =>
                {
                    b.Property<int>("BeerId")
                        .HasColumnName("beer_id")
                        .HasColumnType("integer");

                    b.Property<int>("BreweryId")
                        .HasColumnName("brewery_id")
                        .HasColumnType("integer");

                    b.HasKey("BeerId", "BreweryId");

                    b.HasIndex("BreweryId");

                    b.ToTable("beer_breweries");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.BeerStyle", b =>
                {
                    b.Property<int>("BeerId")
                        .HasColumnName("beer_id")
                        .HasColumnType("integer");

                    b.Property<int>("StyleId")
                        .HasColumnName("style_id")
                        .HasColumnType("integer");

                    b.HasKey("BeerId", "StyleId");

                    b.HasIndex("StyleId");

                    b.ToTable("beer_styles");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Brewery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CountryId")
                        .HasColumnName("country_id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("breweries");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Concern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("concerns");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("countries");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BeerId")
                        .HasColumnName("beer_id")
                        .HasColumnType("integer");

                    b.Property<int>("Grade")
                        .HasColumnName("grade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.ToTable("ratings");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<int?>("ParentId")
                        .HasColumnName("parent_id")
                        .HasColumnType("integer");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnName("slug")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("styles");
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Beer", b =>
                {
                    b.HasOne("Bierpedia.Api.Model.Concern", "Concern")
                        .WithMany("Beers")
                        .HasForeignKey("ConcernId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierpedia.Api.Model.BeerBrewery", b =>
                {
                    b.HasOne("Bierpedia.Api.Model.Beer", "Beer")
                        .WithMany("BeerBreweries")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bierpedia.Api.Model.Brewery", "Brewery")
                        .WithMany()
                        .HasForeignKey("BreweryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierpedia.Api.Model.BeerStyle", b =>
                {
                    b.HasOne("Bierpedia.Api.Model.Beer", "Beer")
                        .WithMany("BeerStyles")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bierpedia.Api.Model.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Brewery", b =>
                {
                    b.HasOne("Bierpedia.Api.Model.Country", "Country")
                        .WithMany("Breweries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Rating", b =>
                {
                    b.HasOne("Bierpedia.Api.Model.Beer", "Beer")
                        .WithMany("Ratings")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bierpedia.Api.Model.Style", b =>
                {
                    b.HasOne("Bierpedia.Api.Model.Style", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
