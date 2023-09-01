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

    public DbSet<Loan> Loans{get; set;}
    public DbSet<EmployerRecord> EmployerRecord{get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=./ApplicationDb.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
