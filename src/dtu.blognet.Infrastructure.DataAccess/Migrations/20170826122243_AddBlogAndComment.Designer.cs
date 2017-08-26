using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using dtu.blognet.Infrastructure.DataAccess;

namespace dtu.blognet.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170826122243_AddBlogAndComment")]
    partial class AddBlogAndComment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dtu.blognet.Core.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("dtu.blognet.Core.Entities.BlogTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("BlogTags");
                });

            modelBuilder.Entity("dtu.blognet.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("dtu.blognet.Core.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("dtu.blognet.Core.Entities.BlogTag", b =>
                {
                    b.HasOne("dtu.blognet.Core.Entities.Blog")
                        .WithMany("Tags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dtu.blognet.Core.Entities.Comment", b =>
                {
                    b.HasOne("dtu.blognet.Core.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("dtu.blognet.Core.Entities.Post", b =>
                {
                    b.HasOne("dtu.blognet.Core.Entities.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
