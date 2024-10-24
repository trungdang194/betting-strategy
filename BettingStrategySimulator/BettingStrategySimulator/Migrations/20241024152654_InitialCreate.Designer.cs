﻿// <auto-generated />
using System;
using BettingStrategySimulator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BettingStrategySimulator.Migrations
{
    [DbContext(typeof(BettingStrategyContext))]
    [Migration("20241024152654_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("BettingStrategySimulator.Models.BetResult", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<long>("GameSessionId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StrategyStatisticsId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("CurrentBalance")
                        .HasColumnType("TEXT");

                    b.Property<int>("GameReult")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IncrementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("PnL")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PreviousBalance")
                        .HasColumnType("TEXT");

                    b.HasKey("Id", "GameSessionId", "StrategyStatisticsId");

                    b.HasIndex("GameSessionId");

                    b.HasIndex("StrategyStatisticsId");

                    b.ToTable("BetResults");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.GameSession", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StrategyStatisticsId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StrategyStatisticsId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.StrategyConfiguration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StrategyDefinitionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StrategyDefinitionId");

                    b.ToTable("StrategyConfigurations");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.StrategyDefinition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StrategyDefinitions");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.StrategyStatistics", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfGameSession")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StrategyDefinitionId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("StrategyDefinitionId");

                    b.ToTable("StrategyStatistics");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.BetResult", b =>
                {
                    b.HasOne("BettingStrategySimulator.Models.GameSession", "GameSession")
                        .WithMany()
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BettingStrategySimulator.Models.StrategyStatistics", "StrategyStatistics")
                        .WithMany()
                        .HasForeignKey("StrategyStatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameSession");

                    b.Navigation("StrategyStatistics");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.GameSession", b =>
                {
                    b.HasOne("BettingStrategySimulator.Models.StrategyStatistics", "StrategyStatistics")
                        .WithMany()
                        .HasForeignKey("StrategyStatisticsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategyStatistics");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.StrategyConfiguration", b =>
                {
                    b.HasOne("BettingStrategySimulator.Models.StrategyDefinition", "StrategyDefinition")
                        .WithMany()
                        .HasForeignKey("StrategyDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategyDefinition");
                });

            modelBuilder.Entity("BettingStrategySimulator.Models.StrategyStatistics", b =>
                {
                    b.HasOne("BettingStrategySimulator.Models.StrategyDefinition", "StrategyDefinition")
                        .WithMany()
                        .HasForeignKey("StrategyDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StrategyDefinition");
                });
#pragma warning restore 612, 618
        }
    }
}