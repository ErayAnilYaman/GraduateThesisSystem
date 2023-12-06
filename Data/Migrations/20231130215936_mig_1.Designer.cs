﻿// <auto-generated />
using System;
using Data.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ThesesContext))]
    [Migration("20231130215936_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Author", b =>
                {
                    b.Property<int>("AuthorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("AuthorID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Data.Models.CoSupervisorThesis", b =>
                {
                    b.Property<int>("CoSupervisorThesisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoSupervisorThesisID"));

                    b.Property<int>("SupervisorID")
                        .HasColumnType("int");

                    b.Property<int>("ThesisID")
                        .HasColumnType("int");

                    b.HasKey("CoSupervisorThesisID");

                    b.HasIndex("SupervisorID");

                    b.HasIndex("ThesisID");

                    b.ToTable("CoSupervisorTheses");
                });

            modelBuilder.Entity("Data.Models.Institute", b =>
                {
                    b.Property<int>("InstituteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstituteID"));

                    b.Property<string>("InstituteName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UniversityID")
                        .HasColumnType("int");

                    b.HasKey("InstituteID");

                    b.HasIndex("UniversityID");

                    b.ToTable("Institutes");
                });

            modelBuilder.Entity("Data.Models.Keyword", b =>
                {
                    b.Property<int>("KeywordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KeywordID"));

                    b.Property<string>("KeywordText")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("KeywordID");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("Data.Models.SubjectTopic", b =>
                {
                    b.Property<int>("SubjectTopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectTopicID"));

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("SubjectTopicID");

                    b.ToTable("SubjectTopics");
                });

            modelBuilder.Entity("Data.Models.Supervisor", b =>
                {
                    b.Property<int>("SupervisorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupervisorID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SupervisorName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("SupervisorID");

                    b.ToTable("Supervisors");
                });

            modelBuilder.Entity("Data.Models.Thesis", b =>
                {
                    b.Property<int>("ThesisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThesisID"));

                    b.Property<string>("Abstract")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<int>("InstituteID")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ThesisLanguage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ThesisNumber")
                        .HasColumnType("int");

                    b.Property<string>("ThesisType")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("ThesisYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("UniversityID")
                        .HasColumnType("int");

                    b.HasKey("ThesisID");

                    b.HasIndex("AuthorID");

                    b.HasIndex("InstituteID");

                    b.HasIndex("UniversityID");

                    b.ToTable("Theses");
                });

            modelBuilder.Entity("Data.Models.ThesisKeyword", b =>
                {
                    b.Property<int>("ThesisKeywordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThesisKeywordID"));

                    b.Property<int>("KeywordID")
                        .HasColumnType("int");

                    b.Property<int>("ThesisID")
                        .HasColumnType("int");

                    b.HasKey("ThesisKeywordID");

                    b.HasIndex("KeywordID");

                    b.HasIndex("ThesisID");

                    b.ToTable("ThesisKeywords");
                });

            modelBuilder.Entity("Data.Models.ThesisSubjectTopic", b =>
                {
                    b.Property<int>("ThesisSubjectTopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThesisSubjectTopicID"));

                    b.Property<int>("SubjectTopicID")
                        .HasColumnType("int");

                    b.Property<int>("ThesisID")
                        .HasColumnType("int");

                    b.HasKey("ThesisSubjectTopicID");

                    b.HasIndex("SubjectTopicID");

                    b.HasIndex("ThesisID");

                    b.ToTable("ThesisSubjectTopics");
                });

            modelBuilder.Entity("Data.Models.ThesisSupervisor", b =>
                {
                    b.Property<int>("ThesisSupervisorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThesisSupervisorID"));

                    b.Property<int>("SupervisorID")
                        .HasColumnType("int");

                    b.Property<int>("ThesisID")
                        .HasColumnType("int");

                    b.HasKey("ThesisSupervisorID");

                    b.HasIndex("SupervisorID");

                    b.HasIndex("ThesisID");

                    b.ToTable("ThesisSupervisors");
                });

            modelBuilder.Entity("Data.Models.University", b =>
                {
                    b.Property<int>("UniversityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniversityID"));

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("UniversityID");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("Data.Models.CoSupervisorThesis", b =>
                {
                    b.HasOne("Data.Models.Supervisor", "Supervisor")
                        .WithMany("CoSupervisorTheses")
                        .HasForeignKey("SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "Thesis")
                        .WithMany("CoSupervisorTheses")
                        .HasForeignKey("ThesisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");

                    b.Navigation("Thesis");
                });

            modelBuilder.Entity("Data.Models.Institute", b =>
                {
                    b.HasOne("Data.Models.University", "University")
                        .WithMany("Institutes")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("University");
                });

            modelBuilder.Entity("Data.Models.Thesis", b =>
                {
                    b.HasOne("Data.Models.Author", "Author")
                        .WithMany("Theses")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Institute", "Institute")
                        .WithMany("Theses")
                        .HasForeignKey("InstituteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.University", "University")
                        .WithMany("Theses")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Institute");

                    b.Navigation("University");
                });

            modelBuilder.Entity("Data.Models.ThesisKeyword", b =>
                {
                    b.HasOne("Data.Models.Keyword", "Keyword")
                        .WithMany("ThesisKeywords")
                        .HasForeignKey("KeywordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "Thesis")
                        .WithMany("ThesisKeywords")
                        .HasForeignKey("ThesisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Keyword");

                    b.Navigation("Thesis");
                });

            modelBuilder.Entity("Data.Models.ThesisSubjectTopic", b =>
                {
                    b.HasOne("Data.Models.SubjectTopic", "SubjectTopic")
                        .WithMany("ThesisSubjectTopics")
                        .HasForeignKey("SubjectTopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "Thesis")
                        .WithMany("ThesisSubjectTopics")
                        .HasForeignKey("ThesisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubjectTopic");

                    b.Navigation("Thesis");
                });

            modelBuilder.Entity("Data.Models.ThesisSupervisor", b =>
                {
                    b.HasOne("Data.Models.Supervisor", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Thesis", "Thesis")
                        .WithMany()
                        .HasForeignKey("ThesisID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supervisor");

                    b.Navigation("Thesis");
                });

            modelBuilder.Entity("Data.Models.Author", b =>
                {
                    b.Navigation("Theses");
                });

            modelBuilder.Entity("Data.Models.Institute", b =>
                {
                    b.Navigation("Theses");
                });

            modelBuilder.Entity("Data.Models.Keyword", b =>
                {
                    b.Navigation("ThesisKeywords");
                });

            modelBuilder.Entity("Data.Models.SubjectTopic", b =>
                {
                    b.Navigation("ThesisSubjectTopics");
                });

            modelBuilder.Entity("Data.Models.Supervisor", b =>
                {
                    b.Navigation("CoSupervisorTheses");
                });

            modelBuilder.Entity("Data.Models.Thesis", b =>
                {
                    b.Navigation("CoSupervisorTheses");

                    b.Navigation("ThesisKeywords");

                    b.Navigation("ThesisSubjectTopics");
                });

            modelBuilder.Entity("Data.Models.University", b =>
                {
                    b.Navigation("Institutes");

                    b.Navigation("Theses");
                });
#pragma warning restore 612, 618
        }
    }
}
