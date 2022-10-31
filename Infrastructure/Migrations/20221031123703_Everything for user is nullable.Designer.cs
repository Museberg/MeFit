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
    [Migration("20221031123703_Everything for user is nullable")]
    partial class Everythingforuserisnullable
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
                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("ExerciseId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseWorkout");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.CompletedWorkout", b =>
                {
                    b.Property<int>("CompletedWorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompletedWorkoutId"));

                    b.Property<int>("GoalId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("CompletedWorkoutId");

                    b.HasIndex("GoalId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("CompletedWorkouts");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExerciseId"));

                    b.Property<int>("ContributorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("character varying(2048)");

                    b.Property<double?>("DistanceInKm")
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

                    b.Property<int?>("Repetitions")
                        .HasColumnType("integer");

                    b.Property<double?>("Seconds")
                        .HasColumnType("double precision");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ExerciseId");

                    b.HasIndex("ContributorUserId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Goal", b =>
                {
                    b.Property<int>("GoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GoalId"));

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StartingDate")
                        .HasColumnType("date");

                    b.HasKey("GoalId");

                    b.HasIndex("ProfileId");

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

                    b.Property<double?>("Height")
                        .HasColumnType("double precision");

                    b.Property<string>("MedicalConditions")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<double?>("Weight")
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

                    b.Property<int?>("ContributorUserId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("GoalId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ProgramId");

                    b.HasIndex("ContributorUserId");

                    b.HasIndex("GoalId")
                        .IsUnique();

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("KeycloakId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
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

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

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
                    b.Property<int>("ProgramId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("ProgramId", "WorkoutId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ProgramWorkout");
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ExerciseWorkout_Exercises_WorkoutId");

                    b.HasOne("Infrastructure.Models.Domain.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ExerciseWorkout_Workouts_ExerciseId");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.CompletedWorkout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Goal", "Goal")
                        .WithMany("CompletedWorkouts")
                        .HasForeignKey("GoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Domain.Workout", "Workout")
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Goal");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Exercise", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.User", "Contributor")
                        .WithMany("ExercisesContributed")
                        .HasForeignKey("ContributorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Goal", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Profile", "Profile")
                        .WithMany("Goals")
                        .HasForeignKey("ProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Profile", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Infrastructure.Models.Domain.Profile", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Program", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.User", "Contributor")
                        .WithMany("ProgramsContributed")
                        .HasForeignKey("ContributorUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Infrastructure.Models.Domain.Goal", "Goal")
                        .WithOne("Program")
                        .HasForeignKey("Infrastructure.Models.Domain.Program", "GoalId");

                    b.Navigation("Contributor");

                    b.Navigation("Goal");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Workout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.User", "Contributor")
                        .WithMany("WorkoutsContributed")
                        .HasForeignKey("ContributorUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("ProgramWorkout", b =>
                {
                    b.HasOne("Infrastructure.Models.Domain.Program", null)
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ProgramWorkout_Programs_WorkoutId");

                    b.HasOne("Infrastructure.Models.Domain.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_ProgramWorkout_Workouts_ProgramId");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Goal", b =>
                {
                    b.Navigation("CompletedWorkouts");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.Profile", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("Infrastructure.Models.Domain.User", b =>
                {
                    b.Navigation("ExercisesContributed");

                    b.Navigation("Profile");

                    b.Navigation("ProgramsContributed");

                    b.Navigation("WorkoutsContributed");
                });
#pragma warning restore 612, 618
        }
    }
}