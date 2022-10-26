﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MeFitDbContext))]
    [Migration("20221026115055_Added name to workout")]
    partial class Addednametoworkout
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<int>("ExercisesExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutsWorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("ExercisesExerciseId", "WorkoutsWorkoutId");

                    b.HasIndex("WorkoutsWorkoutId");

                    b.ToTable("ExerciseWorkout");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.CompletedWorkout", b =>
                {
                    b.Property<int>("CompletedWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompletedWorkoutId"));

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("CompletedWorkoutId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("CompletedWorkouts");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExerciseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<double>("DistanceInKm")
                        .HasColumnType("double precision");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MuscleGroups")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Repetitions")
                        .HasColumnType("integer");

                    b.Property<double>("Seconds")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GoalId"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsAchieved")
                        .HasColumnType("boolean");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<int>("ProgramId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("date");

                    b.HasKey("GoalId");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ProgramId")
                        .IsUnique();

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProfileId"));

                    b.Property<string>("Disabilities")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("MedicalConditions")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Program", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProgramId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProgramId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("KeycloakId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkoutId"));

                    b.Property<int>("ContributorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("WorkoutId");

                    b.HasIndex("ContributorUserId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("ProgramWorkout", b =>
                {
                    b.Property<int>("ProgramsProgramId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutsWorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("ProgramsProgramId", "WorkoutsWorkoutId");

                    b.HasIndex("WorkoutsWorkoutId");

                    b.ToTable("ProgramWorkout");
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Domain.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.CompletedWorkout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Domain.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Goal", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Profile", "Profile")
                        .WithMany("Goals")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Domain.Program", "Program")
                        .WithOne("Goal")
                        .HasForeignKey("Infrastructure.Models.Domain.Goal", "ProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Profile", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Infrastructure.Models.Domain.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Workout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.User", "Contributor")
                        .WithMany("Contributed")
                        .HasForeignKey("ContributorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("ProgramWorkout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Program", null)
                        .WithMany()
                        .HasForeignKey("ProgramsProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Domain.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsWorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Profile", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Program", b =>
                {
                    b.Navigation("Goal")
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.User", b =>
                {
                    b.Navigation("Contributed");

                    b.Navigation("Profile")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
