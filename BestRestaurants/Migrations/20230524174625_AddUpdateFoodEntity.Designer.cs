﻿// <auto-generated />
using BestRestaurants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BestRestaurants.Migrations
{
    [DbContext(typeof(BestRestaurantsContext))]
    [Migration("20230524174625_AddUpdateFoodEntity")]
    partial class AddUpdateFoodEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BestRestaurants.Models.Cuisine", b =>
                {
                    b.Property<int>("CuisineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("CuisineId");

                    b.ToTable("Cuisines");
                });

            modelBuilder.Entity("BestRestaurants.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FoodPrice")
                        .HasColumnType("longtext");

                    b.Property<string>("FoodType")
                        .HasColumnType("longtext");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("BestRestaurants.Models.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<int>("CuisineId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("RestaurantId");

                    b.HasIndex("CuisineId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("BestRestaurants.Models.RestaurantFood", b =>
                {
                    b.Property<int>("RestaurantFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("RestaurantFoodId");

                    b.HasIndex("FoodId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("RestaurantFoods");
                });

            modelBuilder.Entity("BestRestaurants.Models.Restaurant", b =>
                {
                    b.HasOne("BestRestaurants.Models.Cuisine", "Cuisine")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuisine");
                });

            modelBuilder.Entity("BestRestaurants.Models.RestaurantFood", b =>
                {
                    b.HasOne("BestRestaurants.Models.Food", "Food")
                        .WithMany("JoinEntities")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BestRestaurants.Models.Restaurant", "Restaurant")
                        .WithMany("JoinEntities")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("BestRestaurants.Models.Cuisine", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("BestRestaurants.Models.Food", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("BestRestaurants.Models.Restaurant", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}