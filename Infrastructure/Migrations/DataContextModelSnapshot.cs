﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChatId"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("ReceiveUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SendUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ChatId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Domain.Entities.ExternalAccount", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("UserId");

                    b.ToTable("ExternalAccounts");
                });

            modelBuilder.Entity("Domain.Entities.FavoriteUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PostId");

                    b.HasIndex("PostId");

                    b.ToTable("FavoriteUsers");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int>("ChatId")
                        .HasColumnType("integer");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SendMessageDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MessageId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ChatId");

                    b.ToTable("Messanges");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DatePublished")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Domain.Entities.PostFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostFiles");
                });

            modelBuilder.Entity("Domain.Entities.PostLike", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("Like")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.ToTable("PostLike");
                });

            modelBuilder.Entity("Domain.Entities.PostLikeUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<int>("PostLikeId")
                        .HasColumnType("integer");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PostLikeId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PostLikeId");

                    b.ToTable("PostLikeUsers");
                });

            modelBuilder.Entity("Domain.Entities.PostView", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("View")
                        .HasColumnType("integer");

                    b.HasKey("PostId");

                    b.ToTable("PostViews");
                });

            modelBuilder.Entity("Domain.Entities.PostViewUser", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("PostViewId")
                        .HasColumnType("integer");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "PostViewId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PostViewId");

                    b.ToTable("PostViewUsers");
                });

            modelBuilder.Entity("Domain.Entities.Profile", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("About")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<DateOnly?>("DOB")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Occupation")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Photo")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Domain.Entities.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("PostId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusStory")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("PostId");

                    b.ToTable("Stories");
                });

            modelBuilder.Entity("Domain.Entities.StoryLike", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StoryId"));

                    b.Property<int>("Like")
                        .HasColumnType("integer");

                    b.Property<int>("StoryId1")
                        .HasColumnType("integer");

                    b.HasKey("StoryId");

                    b.HasIndex("StoryId1");

                    b.ToTable("StoryLikes");
                });

            modelBuilder.Entity("Domain.Entities.StoryLikeUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StoryLikeId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StoryLikeId");

                    b.HasIndex("UserId");

                    b.ToTable("StoryLikeUsers");
                });

            modelBuilder.Entity("Domain.Entities.StoryView", b =>
                {
                    b.Property<int>("StoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StoryId"));

                    b.Property<int>("StoryId1")
                        .HasColumnType("integer");

                    b.Property<int>("View")
                        .HasColumnType("integer");

                    b.HasKey("StoryId");

                    b.HasIndex("StoryId1");

                    b.ToTable("StoryViews");
                });

            modelBuilder.Entity("Domain.Entities.StoryViewUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("StoryViewId")
                        .HasColumnType("integer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("StoryViewId");

                    b.HasIndex("UserId");

                    b.ToTable("StoryViewUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Chat", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Chats")
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.ExternalAccount", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithOne("ExternalAccount")
                        .HasForeignKey("Domain.Entities.ExternalAccount", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.FavoriteUser", b =>
                {
                    b.HasOne("Domain.Entities.Post", "Post")
                        .WithMany("FavoriteUsers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithMany("FavoriteUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Location", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithOne("Location")
                        .HasForeignKey("Domain.Entities.Location", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Message", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Messanges")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("Post")
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Domain.Entities.PostFile", b =>
                {
                    b.HasOne("Domain.Entities.Post", "Post")
                        .WithMany("PostFiles")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Entities.PostLike", b =>
                {
                    b.HasOne("Domain.Entities.Post", "Post")
                        .WithOne("PostLikes")
                        .HasForeignKey("Domain.Entities.PostLike", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Entities.PostLikeUser", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("PostLikeUsers")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Entities.PostLike", "PostLike")
                        .WithMany("Users")
                        .HasForeignKey("PostLikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("PostLike");
                });

            modelBuilder.Entity("Domain.Entities.PostView", b =>
                {
                    b.HasOne("Domain.Entities.Post", "Post")
                        .WithOne("PostViews")
                        .HasForeignKey("Domain.Entities.PostView", "PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Entities.PostViewUser", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany("PostViewUsers")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Entities.PostView", "PostView")
                        .WithMany("Users")
                        .HasForeignKey("PostViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("PostView");
                });

            modelBuilder.Entity("Domain.Entities.Profile", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Domain.Entities.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Story", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Domain.Entities.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Entities.StoryLike", b =>
                {
                    b.HasOne("Domain.Entities.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("Domain.Entities.StoryLikeUser", b =>
                {
                    b.HasOne("Domain.Entities.StoryLike", "StoryLike")
                        .WithMany("Users")
                        .HasForeignKey("StoryLikeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoryLike");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.StoryView", b =>
                {
                    b.HasOne("Domain.Entities.Story", "Story")
                        .WithMany()
                        .HasForeignKey("StoryId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("Domain.Entities.StoryViewUser", b =>
                {
                    b.HasOne("Domain.Entities.StoryView", "StoryView")
                        .WithMany("Users")
                        .HasForeignKey("StoryViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoryView");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Chats");

                    b.Navigation("ExternalAccount")
                        .IsRequired();

                    b.Navigation("FavoriteUsers");

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Messanges");

                    b.Navigation("Post");

                    b.Navigation("PostLikeUsers");

                    b.Navigation("PostViewUsers");

                    b.Navigation("Profile")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Domain.Entities.Post", b =>
                {
                    b.Navigation("FavoriteUsers");

                    b.Navigation("PostFiles");

                    b.Navigation("PostLikes")
                        .IsRequired();

                    b.Navigation("PostViews")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.PostLike", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.PostView", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.StoryLike", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.StoryView", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
