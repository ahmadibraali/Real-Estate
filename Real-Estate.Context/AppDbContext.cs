﻿using Microsoft.EntityFrameworkCore;
using Real_Estate.Domain;
using Real_Estate.Domain.Common;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Context
{
    public class AppDbContext:DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }
        public DbSet<Properties>? Properties { get; set; }
        public DbSet<Improvements>? Improvements { get; set; }
        public DbSet<TypeOfProperties>? TypeOfProperties { get; set; }
        public DbSet<TypeOfSales>? TypeOfSales { get; set; }
        public DbSet<PropertiesImprovements>? PropertiesImprovements { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            #region tables
            modelBuilder.Entity<Properties>().ToTable("Properties");
            modelBuilder.Entity<TypeOfProperties>().ToTable("TypeOfProperties");
            modelBuilder.Entity<TypeOfSales>().ToTable("TypeOfSales");
            modelBuilder.Entity<Improvements>().ToTable("Improvements");
            #endregion

            #region "primary keys"
            modelBuilder.Entity<Properties>().HasKey(property => property.Id);
            modelBuilder.Entity<TypeOfProperties>().HasKey(typeOfProperty => typeOfProperty.Id);
            modelBuilder.Entity<TypeOfSales>().HasKey(typeOfSale => typeOfSale.Id);
            modelBuilder.Entity<Improvements>().HasKey(improvement => improvement.Id);
            #endregion

            #region relationships

            modelBuilder.Entity<Properties>()
                 .HasOne(property => property.TypeOfProperty)
                 .WithMany(typeOfProperty => typeOfProperty.Properties)
                 .HasForeignKey(property => property.TypeOfPropertyId)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Properties>()
                 .HasOne(property => property.TypeOfSale)
                 .WithMany(typeOfSale => typeOfSale.Properties)
                 .HasForeignKey(property => property.TypeOfPropertyId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Properties>()
                 .HasMany(property => property.Improvements)
                 .WithMany(improvement => improvement.Properties)
                 .UsingEntity<PropertiesImprovements>(
                    propImp => propImp.HasOne(prop => prop.Improvement)
                    .WithMany()
                    .HasForeignKey(prop => prop.ImprovementId),
                    propImp => propImp.HasOne(prop => prop.Property)
                    .WithMany()
                    .HasForeignKey(prop => prop.PropertyId),
                    propImp =>
                    {
                        propImp.Property(prop => prop.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                        propImp.HasKey(propImp => new { propImp.PropertyId, propImp.ImprovementId });
                    }
                );
            #endregion
            #region "property configurations"

            #region Properties
            modelBuilder.Entity<Properties>()
                .HasIndex(property => property.Code)
                .IsUnique();
            #endregion

            #endregion
           // base.OnModelCreating(modelBuilder);
        }


    }
}
