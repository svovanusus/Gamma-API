﻿// <auto-generated />
using System;
using Gamma.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gamma.Data.EF.Migrations
{
    [DbContext(typeof(GammaDbContext))]
    [Migration("20220610161126_AddEntities")]
    partial class AddEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Gamma.Data.Entities.Domain", b =>
                {
                    b.Property<long>("DomainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DomainId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DomainId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Gamma.Data.Entities.MediaResource", b =>
                {
                    b.Property<long>("MediaResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MediaResourceId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DefaultAltText")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<long>("LastRevisionId")
                        .HasColumnType("bigint");

                    b.Property<string>("MediaResourceUid")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<long>("SiteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MediaResourceId");

                    b.HasIndex("LastRevisionId");

                    b.HasIndex("SiteId");

                    b.ToTable("MediaResources");
                });

            modelBuilder.Entity("Gamma.Data.Entities.MediaResourceRevision", b =>
                {
                    b.Property<long>("MediaResourceRevisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MediaResourceRevisionId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<long>("MediaResourceId")
                        .HasColumnType("bigint");

                    b.Property<long>("Size")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("MediaResourceRevisionId");

                    b.HasIndex("MediaResourceId");

                    b.ToTable("MediaResourceRevisions");
                });

            modelBuilder.Entity("Gamma.Data.Entities.Site", b =>
                {
                    b.Property<long>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SiteId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DomainId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<long>("OwnerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SiteId");

                    b.HasIndex("DomainId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("Gamma.Data.Entities.SitePage", b =>
                {
                    b.Property<long>("SitePageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SitePageId"), 1L, 1);

                    b.Property<string>("ContentJson")
                        .IsRequired()
                        .HasMaxLength(5000000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<long>("SiteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("SitePageId");

                    b.HasIndex("SiteId");

                    b.ToTable("SitePages");
                });

            modelBuilder.Entity("Gamma.Data.Entities.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gamma.Data.Entities.Domain", b =>
                {
                    b.HasOne("Gamma.Data.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Gamma.Data.Entities.MediaResource", b =>
                {
                    b.HasOne("Gamma.Data.Entities.MediaResourceRevision", "LastRevision")
                        .WithMany()
                        .HasForeignKey("LastRevisionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Gamma.Data.Entities.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LastRevision");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Gamma.Data.Entities.MediaResourceRevision", b =>
                {
                    b.HasOne("Gamma.Data.Entities.MediaResource", "MediaResource")
                        .WithMany("Revisions")
                        .HasForeignKey("MediaResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaResource");
                });

            modelBuilder.Entity("Gamma.Data.Entities.Site", b =>
                {
                    b.HasOne("Gamma.Data.Entities.Domain", "Domain")
                        .WithMany()
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Gamma.Data.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Domain");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Gamma.Data.Entities.SitePage", b =>
                {
                    b.HasOne("Gamma.Data.Entities.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Gamma.Data.Entities.MediaResource", b =>
                {
                    b.Navigation("Revisions");
                });
#pragma warning restore 612, 618
        }
    }
}
