﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore.DynamicOrderBy.Demo.Models
{
    public partial class testOrderByContext : DbContext
    {
        public testOrderByContext()
        {
        }

        public testOrderByContext(DbContextOptions<testOrderByContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TTest> TTest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TTest>(entity =>
            {
                entity.ToTable("T_test");

                entity.Property(e => e.Abc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("abc");

                entity.Property(e => e.CreateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(msg => {
              
                    Console.WriteLine(msg);
                
            });
            string connStr = "Server=.;Database=testOrderBy;Trusted_Connection=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connStr);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}