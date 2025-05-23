﻿// <auto-generated />
using System;
using Entity.Data.Entity.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    partial class EntityDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("CityName");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("Entity.Models.Degree", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfExpiry")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateRange")
                        .HasColumnType("datetime2");

                    b.Property<string>("DegreeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Degrees");
                });

            modelBuilder.Entity("Entity.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityId");

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("DistictName");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("District", (string)null);
                });

            modelBuilder.Entity("Entity.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("IdentityCardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NationId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("JobId");

                    b.HasIndex("NationId");

                    b.HasIndex("WardId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Entity.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Entity.Models.Nation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nations");
                });

            modelBuilder.Entity("Entity.Models.Ward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DistrictId")
                        .HasColumnType("int")
                        .HasColumnName("DistrictId");

                    b.Property<string>("WardName")
                        .IsRequired()
                        .HasMaxLength(350)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("WardName");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Ward", (string)null);
                });

            modelBuilder.Entity("Entity.Models.Degree", b =>
                {
                    b.HasOne("Entity.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("fk_employee_id");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Entity.Models.District", b =>
                {
                    b.HasOne("Entity.Models.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_provice_id");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Entity.Models.Employee", b =>
                {
                    b.HasOne("Entity.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_city");

                    b.HasOne("Entity.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_DS");

                    b.HasOne("Entity.Models.Job", "Job")
                        .WithMany()
                        .HasForeignKey("JobId")
                        .HasConstraintName("job");

                    b.HasOne("Entity.Models.Nation", "Nation")
                        .WithMany()
                        .HasForeignKey("NationId")
                        .HasConstraintName("fk_na");

                    b.HasOne("Entity.Models.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("District");

                    b.Navigation("Job");

                    b.Navigation("Nation");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("Entity.Models.Ward", b =>
                {
                    b.HasOne("Entity.Models.District", "District")
                        .WithMany("Wards")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_district_id");

                    b.Navigation("District");
                });

            modelBuilder.Entity("Entity.Models.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("Entity.Models.District", b =>
                {
                    b.Navigation("Wards");
                });
#pragma warning restore 612, 618
        }
    }
}
