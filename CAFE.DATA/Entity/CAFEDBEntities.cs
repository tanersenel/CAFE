using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CAFE.DATA.Entity
{
    public partial class CAFEDBEntities : DbContext
    {
        public CAFEDBEntities()
        {
        }

        public CAFEDBEntities(DbContextOptions<CAFEDBEntities> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Productproperty> Productproperties { get; set; }
        public virtual DbSet<Property> Properties { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=THOSCAFEDB;User ID=sa;Password=sa123456A; Connection Timeout=240;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");

                entity.Property(e => e.Categoryname)
                    .HasMaxLength(200)
                    .HasColumnName("CATEGORYNAME");

                entity.Property(e => e.Createddate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDDATE");

                entity.Property(e => e.Creatoruserid).HasColumnName("CREATORUSERID");

                entity.Property(e => e.Isdeleted).HasColumnName("ISDELETED");

                entity.Property(e => e.Parentcategoryid).HasColumnName("PARENTCATEGORYID");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Categoryid).HasColumnName("CATEGORYID");

                entity.Property(e => e.Createddate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATEDDATE");

                entity.Property(e => e.Creatoruserid).HasColumnName("CREATORUSERID");

                entity.Property(e => e.Imagepath)
                    .HasMaxLength(500)
                    .HasColumnName("IMAGEPATH");

                entity.Property(e => e.Isdeleted).HasColumnName("ISDELETED");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Productname)
                    .HasMaxLength(250)
                    .HasColumnName("PRODUCTNAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Categoryid)
                    .HasConstraintName("FK_PRODUCT_CATEGORY");
            });

            modelBuilder.Entity<Productproperty>(entity =>
            {
                entity.ToTable("PRODUCTPROPERTY");

                entity.Property(e => e.Productpropertyid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCTPROPERTYID");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productproperties)
                    .HasForeignKey(d => d.Productid)
                    .HasConstraintName("FK_PRODUCTPROPERTY_PRODUCT");

             
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("PROPERTY");

                entity.Property(e => e.Propertyid).HasColumnName("PROPERTYID");

                entity.Property(e => e.Key)
                    .HasMaxLength(50)
                    .HasColumnName("KEY");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("VALUE");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Hashpassword)
                    .HasMaxLength(500)
                    .HasColumnName("HASHPASSWORD");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("NAME");

                entity.Property(e => e.Saltpassword)
                    .HasMaxLength(50)
                    .HasColumnName("SALTPASSWORD");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .HasColumnName("SURNAME");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("USERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
