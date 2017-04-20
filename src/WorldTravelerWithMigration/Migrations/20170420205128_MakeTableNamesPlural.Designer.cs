using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WorldTravelerWithMigration.Models;

namespace WorldTravelerWithMigration.Migrations
{
    [DbContext(typeof(WorldTravelerDbContext))]
    [Migration("20170420205128_MakeTableNamesPlural")]
    partial class MakeTableNamesPlural
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorldTravelerWithMigration.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("LocationId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("WorldTravelerWithMigration.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Country");

                    b.HasKey("LocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("WorldTravelerWithMigration.Models.People", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceId");

                    b.Property<string>("Name");

                    b.HasKey("PeopleId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("WorldTravelerWithMigration.Models.Experience", b =>
                {
                    b.HasOne("WorldTravelerWithMigration.Models.Location", "Location")
                        .WithMany("Experiences")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WorldTravelerWithMigration.Models.People", b =>
                {
                    b.HasOne("WorldTravelerWithMigration.Models.Experience", "Experience")
                        .WithMany("Peoples")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
