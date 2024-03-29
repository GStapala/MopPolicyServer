﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MopPolicyServer.Infrastructure.Data.Contexts;

#nullable disable

namespace MopPolicyServer.Infrastructure.Data.Migrations
{
    [DbContext(typeof(PolicyServerDbContext))]
    [Migration("20240131181157_InitialMigrationPolicyServer")]
    partial class InitialMigrationPolicyServer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("Permissions", "pol");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.PermissionSubject", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("PermissionSubject", "pol");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Policies", "pol");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PolicyId");

                    b.ToTable("Roles", "pol");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityServerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LastModified")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Subjects", "pol");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Permission", b =>
                {
                    b.HasOne("MopPolicyServer.Domain.Entities.Policy", "Policy")
                        .WithMany("Permissions")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.PermissionSubject", b =>
                {
                    b.HasOne("MopPolicyServer.Domain.Entities.Permission", "Permission")
                        .WithMany("PermissionSubjects")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MopPolicyServer.Domain.Entities.Subject", "Subject")
                        .WithMany("PermissionSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Role", b =>
                {
                    b.HasOne("MopPolicyServer.Domain.Entities.Policy", "Policy")
                        .WithMany("Roles")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Subject", b =>
                {
                    b.HasOne("MopPolicyServer.Domain.Entities.Role", null)
                        .WithMany("Subjects")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Permission", b =>
                {
                    b.Navigation("PermissionSubjects");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Policy", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Role", b =>
                {
                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("MopPolicyServer.Domain.Entities.Subject", b =>
                {
                    b.Navigation("PermissionSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
