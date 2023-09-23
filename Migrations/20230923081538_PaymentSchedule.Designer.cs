﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QBOID;

#nullable disable

namespace QBOID.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230923081538_PaymentSchedule")]
    partial class PaymentSchedule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("QBOID.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAccountName")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("QBOID.Models.EmployerRecord", b =>
                {
                    b.Property<Guid>("EmployerRecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployerAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployerPhone")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployerSector")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmploymentDuration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EmploymentType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IncomeReceiptMode")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("NetMonthlyIncome")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NextPayDay")
                        .HasColumnType("TEXT");

                    b.Property<int>("SalaryFrequency")
                        .HasColumnType("INTEGER");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int>("ToleranceDays")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("TotalMonthlyExpense")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployerRecordID");

                    b.ToTable("EmployerRecord");
                });

            modelBuilder.Entity("QBOID.Models.Loan", b =>
                {
                    b.Property<Guid>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Activity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankVerificationNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("EmployerRecordID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MimLoanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("LoanID");

                    b.HasIndex("EmployerRecordID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("QBOID.Models.PaymentSchedule", b =>
                {
                    b.Property<Guid>("PaymentScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MIMScheduleId")
                        .HasColumnType("TEXT");

                    b.HasKey("PaymentScheduleID");

                    b.ToTable("PaymentSchedules");
                });

            modelBuilder.Entity("QBOID.Models.Transaction", b =>
                {
                    b.Property<Guid>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("TransactionID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("QBOID.Models.Loan", b =>
                {
                    b.HasOne("QBOID.Models.EmployerRecord", "EmployerRecord")
                        .WithMany()
                        .HasForeignKey("EmployerRecordID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployerRecord");
                });

            modelBuilder.Entity("QBOID.Models.Transaction", b =>
                {
                    b.HasOne("QBOID.Models.Customer", null)
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QBOID.Models.Customer", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
