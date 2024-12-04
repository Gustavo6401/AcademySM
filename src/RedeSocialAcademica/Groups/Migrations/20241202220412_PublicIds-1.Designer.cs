﻿// <auto-generated />
using System;
using Groups.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Groups.Migrations
{
    [DbContext(typeof(GroupsDbContext))]
    [Migration("20241202220412_PublicIds-1")]
    partial class PublicIds1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AnswerComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("UserId");

                    b.ToTable("AnswerComment");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AnswerVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnswerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateVote")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Vote")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("UserId");

                    b.ToTable("AnswerVote");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AssignmentFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentFile");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AssignmentSent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<float>("Rate")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("UserId");

                    b.ToTable("AssignmentsSents");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.CategoryGroups", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("CategoryGroups");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.ConversationsUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConversationId")
                        .HasColumnType("int");

                    b.Property<string>("ConversationRole")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("ConversationsUsers");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.DoubtFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoubtId")
                        .HasColumnType("int");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoubtId");

                    b.ToTable("DoubtFiles");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.GroupsUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("GroupsUsers");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnnouncementText")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAnnouncement")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoubtId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoubtId");

                    b.HasIndex("UserId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EducationalBackground")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Institution")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ProfilePicFilePath")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Writer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YearWriting")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<float>("NoteValue")
                        .HasColumnType("real");

                    b.Property<Guid>("PublicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("PublicId")
                        .IsUnique()
                        .HasDatabaseName("IX_Assignment_PublicId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MainCategory")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Conversation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("PublicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<string>("Tutor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublicId")
                        .IsUnique()
                        .HasDatabaseName("IX_Courses_PublicId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Doubt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Doubts");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.DoubtVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateVote")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoubtId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Vote")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("DoubtId");

                    b.HasIndex("UserId");

                    b.ToTable("DoubtVote");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ConversationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("UserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(10000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.PostFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("RelativePath")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostFile");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.PostVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Vote")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("PostVote");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AnswerComment", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("AnswerComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AnswerVote", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("AnswerVote")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Answer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AssignmentFile", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Assignment", "Assignment")
                        .WithMany()
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.AssignmentSent", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Assignment", "Assignment")
                        .WithMany("Sents")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Assignments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.CategoryGroups", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.ConversationsUsers", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Conversation", "Conversation")
                        .WithMany()
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.DoubtFile", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Doubt", "Doubt")
                        .WithMany("Files")
                        .HasForeignKey("DoubtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doubt");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Aggregations.GroupsUsers", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Announcement", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany("Announcements")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Answer", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Doubt", "Doubt")
                        .WithMany("Answers")
                        .HasForeignKey("DoubtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Answers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doubt");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Article", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany("Articles")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Articles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Assignment", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany("Assignments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Comment", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Doubt", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany("Doubts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Doubts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.DoubtVote", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Doubt", "Doubt")
                        .WithMany("Votes")
                        .HasForeignKey("DoubtId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("DoubtVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Doubt");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Message", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Conversation", "Conversation")
                        .WithMany("Messages")
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conversation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Post", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Courses", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.PostFile", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Post", "Post")
                        .WithMany("Files")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.PostVote", b =>
                {
                    b.HasOne("Groups.Domain.Models.SqlServerModels.Post", "Post")
                        .WithMany("Votes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Groups.Domain.Models.SqlServerModels.ApplicationUser", "User")
                        .WithMany("PostVotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.ApplicationUser", b =>
                {
                    b.Navigation("AnswerComments");

                    b.Navigation("AnswerVote");

                    b.Navigation("Answers");

                    b.Navigation("Articles");

                    b.Navigation("Assignments");

                    b.Navigation("Comments");

                    b.Navigation("DoubtVotes");

                    b.Navigation("Doubts");

                    b.Navigation("Messages");

                    b.Navigation("PostVotes");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Assignment", b =>
                {
                    b.Navigation("Sents");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Conversation", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Courses", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Articles");

                    b.Navigation("Assignments");

                    b.Navigation("Doubts");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Doubt", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Files");

                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Groups.Domain.Models.SqlServerModels.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Files");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}