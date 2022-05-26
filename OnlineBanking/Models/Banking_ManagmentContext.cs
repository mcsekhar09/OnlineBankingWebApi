using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OnlineBanking.Models
{
    public partial class Banking_ManagmentContext : DbContext
    {
        public Banking_ManagmentContext()
        {
        }

        public Banking_ManagmentContext(DbContextOptions<Banking_ManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountRequest> AccountRequest { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Beneficiary> Beneficiary { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MCSEKHAR09\\SQLEXPRESS;Database=Banking_Managment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Account__8CB382B183CA4355");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountNum).HasColumnName("account_num");

                entity.Property(e => e.Balance)
                    .HasColumnName("balance")
                    .HasColumnType("money");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RequestId).HasColumnName("Request_id");

                entity.Property(e => e.TransactionPassword)
                    .HasColumnName("transaction_password")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__Account__Request__145C0A3F");
            });

            modelBuilder.Entity<AccountRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId)
                    .HasName("PK__account___E9C0AF0B1923DCC1");

                entity.ToTable("account_request");

                entity.Property(e => e.RequestId)
                    .HasColumnName("Request_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddharCard).HasColumnName("addhar_card");

                entity.Property(e => e.DebitAtmcard)
                    .HasColumnName("debit_atmcard")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnName("dob")
                    .HasColumnType("date");

                entity.Property(e => e.EmailId)
                    .HasColumnName("email_id")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .IsRequired()
                    .HasColumnName("father_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GrossAnnualIncome).HasColumnName("gross_annual_income");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNum)
                    .HasColumnName("mobile_num")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OccupationalDetails)
                    .HasColumnName("occupational_details")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PermenentAddress)
                    .HasColumnName("permenent_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ResidentialAddress)
                    .HasColumnName("residential_address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Adminid)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Passwords)
                    .HasColumnName("passwords")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.ToTable("beneficiary");

                entity.Property(e => e.BeneficiaryId)
                    .HasColumnName("beneficiary_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BeneficiaryAccNo).HasColumnName("beneficiary_acc_no");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.IfscCode)
                    .HasColumnName("Ifsc_code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Beneficiary)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__beneficia__Custo__173876EA");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__Transact__9A8C4A3D4F9BC53F");

                entity.Property(e => e.TransactionId)
                    .HasColumnName("Transaction_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.FromAcc).HasColumnName("From_Acc");

                entity.Property(e => e.Remark)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ToAcc).HasColumnName("to_Acc");

                entity.Property(e => e.TransactionDate)
                    .HasColumnName("transaction_date")
                    .HasColumnType("date");

                entity.Property(e => e.TransactionStatus)
                    .HasColumnName("transaction_status")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionType)
                    .HasColumnName("Transaction_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__Custo__1A14E395");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
