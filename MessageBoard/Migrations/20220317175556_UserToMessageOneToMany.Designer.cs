﻿// <auto-generated />
using MessageBoard.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MessageBoard.Migrations
{
    [DbContext(typeof(MessageBoardContext))]
    [Migration("20220317175556_UserToMessageOneToMany")]
    partial class UserToMessageOneToMany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("MessageId");

                    b.HasIndex("RoomId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MessageBoard.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("MessageBoard.Models.RoomMessage", b =>
                {
                    b.Property<int>("RoomMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("RoomMessageId");

                    b.HasIndex("MessageId");

                    b.HasIndex("RoomId");

                    b.ToTable("RoomMessages");
                });

            modelBuilder.Entity("MessageBoard.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.HasOne("MessageBoard.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MessageBoard.Models.RoomMessage", b =>
                {
                    b.HasOne("MessageBoard.Models.Message", "Message")
                        .WithMany("JoinEntities")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MessageBoard.Models.Room", "Room")
                        .WithMany("JoinEntities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("MessageBoard.Models.Message", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("MessageBoard.Models.Room", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("MessageBoard.Models.User", b =>
                {
                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
