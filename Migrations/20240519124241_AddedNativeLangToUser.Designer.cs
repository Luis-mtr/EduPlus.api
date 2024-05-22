﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240519124241_AddedNativeLangToUser")]
    partial class AddedNativeLangToUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "479c7e66-f982-443c-9750-0330a548ef62",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "40494b93-9c99-4dc6-9427-f0f3a1b83936",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("NativeLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NativeLanguageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("api.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"));

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("api.Models.Phrase", b =>
                {
                    b.Property<int>("PhraseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhraseId"));

                    b.Property<string>("PhraseText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhraseId");

                    b.ToTable("Phrases");
                });

            modelBuilder.Entity("api.Models.PhraseLanguage", b =>
                {
                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("PhraseId")
                        .HasColumnType("int");

                    b.Property<string>("PhraseInLanguage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId", "PhraseId");

                    b.HasIndex("PhraseId");

                    b.ToTable("PhrasesLanguages");
                });

            modelBuilder.Entity("api.Models.PhraseLanguageUser", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PhraseId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("CountAsked")
                        .HasColumnType("int");

                    b.Property<int>("CountRight")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Score")
                        .HasColumnType("tinyint");

                    b.HasKey("AppUserId", "PhraseId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PhraseId");

                    b.ToTable("PhraseLanguageUser");
                });

            modelBuilder.Entity("api.Models.Word", b =>
                {
                    b.Property<int>("WordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WordId"));

                    b.Property<string>("WordText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WordId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("api.Models.WordLanguage", b =>
                {
                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.Property<string>("WordInLanguage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId", "WordId");

                    b.HasIndex("WordId");

                    b.ToTable("WordsLanguages");
                });

            modelBuilder.Entity("api.Models.WordLanguageUser", b =>
                {
                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("CountAsked")
                        .HasColumnType("int");

                    b.Property<int>("CountRight")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Score")
                        .HasColumnType("tinyint");

                    b.HasKey("AppUserId", "WordId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("WordId");

                    b.ToTable("WordLanguageUsers");
                });

            modelBuilder.Entity("api.Models.WordPhrase", b =>
                {
                    b.Property<int>("WordId")
                        .HasColumnType("int");

                    b.Property<int>("PhraseId")
                        .HasColumnType("int");

                    b.HasKey("WordId", "PhraseId");

                    b.HasIndex("PhraseId");

                    b.ToTable("WordsPhrases");
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
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
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

                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("api.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.HasOne("api.Models.Language", "NativeLanguage")
                        .WithMany()
                        .HasForeignKey("NativeLanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NativeLanguage");
                });

            modelBuilder.Entity("api.Models.PhraseLanguage", b =>
                {
                    b.HasOne("api.Models.Language", "Langauge")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Phrase", "Phrase")
                        .WithMany()
                        .HasForeignKey("PhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Langauge");

                    b.Navigation("Phrase");
                });

            modelBuilder.Entity("api.Models.PhraseLanguageUser", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany("PhraseLanguageUser")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Language", "Langauge")
                        .WithMany("PhraseLanguageUser")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Phrase", "Phrase")
                        .WithMany("PhraseLanguageUser")
                        .HasForeignKey("PhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Langauge");

                    b.Navigation("Phrase");
                });

            modelBuilder.Entity("api.Models.WordLanguage", b =>
                {
                    b.HasOne("api.Models.Language", "Langauge")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Langauge");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("api.Models.WordLanguageUser", b =>
                {
                    b.HasOne("api.Models.AppUser", "AppUser")
                        .WithMany("WordLanguageUser")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Language", "Langauge")
                        .WithMany("WordLanguageUser")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Word", "Word")
                        .WithMany("WordLanguageUser")
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Langauge");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("api.Models.WordPhrase", b =>
                {
                    b.HasOne("api.Models.Phrase", "Phrase")
                        .WithMany()
                        .HasForeignKey("PhraseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Models.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phrase");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("api.Models.AppUser", b =>
                {
                    b.Navigation("PhraseLanguageUser");

                    b.Navigation("WordLanguageUser");
                });

            modelBuilder.Entity("api.Models.Language", b =>
                {
                    b.Navigation("PhraseLanguageUser");

                    b.Navigation("WordLanguageUser");
                });

            modelBuilder.Entity("api.Models.Phrase", b =>
                {
                    b.Navigation("PhraseLanguageUser");
                });

            modelBuilder.Entity("api.Models.Word", b =>
                {
                    b.Navigation("WordLanguageUser");
                });
#pragma warning restore 612, 618
        }
    }
}
