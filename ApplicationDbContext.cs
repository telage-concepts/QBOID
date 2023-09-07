using System;
using System.Collections.Generic;
using QBOID.Models;
using Microsoft.EntityFrameworkCore;

namespace QBOID;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public DbSet<Loan>? Loans{get; set;}
    public DbSet<EmployerRecord>? EmployerRecord{get; set;}
    public DbSet<Customer>? Customers {get; set;}
    public DbSet<Transaction>? Transactions {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=./ApplicationDb.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
