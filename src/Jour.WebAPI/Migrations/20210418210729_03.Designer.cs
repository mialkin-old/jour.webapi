﻿// <auto-generated />
using System;
using Jour.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Jour.WebAPI.Migrations
{
    [DbContext(typeof(JourContext))]
    [Migration("20210418210729_03")]
    partial class _03
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Jour.Database.Dtos.Birthday", b =>
                {
                    b.Property<int>("BirthdayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("birthday_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.HasKey("BirthdayId")
                        .HasName("pk_birthdays");

                    b.ToTable("birthdays");
                });

            modelBuilder.Entity("Jour.Database.Dtos.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("exercise_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("integer")
                        .HasColumnName("workout_id");

                    b.HasKey("ExerciseId")
                        .HasName("pk_exercises");

                    b.HasIndex("WorkoutId")
                        .HasDatabaseName("ix_exercises_workout_id");

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("Jour.Database.Dtos.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("goal_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("date")
                        .HasColumnName("deadline");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("GoalId")
                        .HasName("pk_goals");

                    b.ToTable("goals");
                });

            modelBuilder.Entity("Jour.Database.Dtos.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("plan_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("date")
                        .HasColumnName("date_completed");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date")
                        .HasColumnName("date_created");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_completed");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("PlanId")
                        .HasName("pk_plans");

                    b.ToTable("plans");
                });

            modelBuilder.Entity("Jour.Database.Dtos.Training", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("workout_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("WorkoutDate")
                        .HasColumnType("date")
                        .HasColumnName("workout_date");

                    b.HasKey("WorkoutId")
                        .HasName("pk_workouts");

                    b.ToTable("workouts");
                });

            modelBuilder.Entity("Jour.Database.Dtos.Exercise", b =>
                {
                    b.HasOne("Jour.Database.Dtos.Training", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutId")
                        .HasConstraintName("fk_exercises_workouts_workout_id");
                });

            modelBuilder.Entity("Jour.Database.Dtos.Training", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}