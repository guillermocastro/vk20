using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace vk20.Models
{
    public partial class VK21Context : DbContext
    {
        public VK21Context()
        {
        }

        public VK21Context(DbContextOptions<VK21Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<BankMov> BankMov { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Doc> Doc { get; set; }
        public virtual DbSet<DocType> DocType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Line> Line { get; set; }
        public virtual DbSet<LineType> LineType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Mov> Mov { get; set; }
        public virtual DbSet<MoveType> MoveType { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Tax> Tax { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=VK21;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "vk2");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Balance).HasMaxLength(2);

                entity.Property(e => e.IncomeStatement).HasMaxLength(2);

                entity.Property(e => e.Utr)
                    .HasColumnName("UTR")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Account__Company__68487DD7");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank", "vk2");

                entity.Property(e => e.AccountNo).HasMaxLength(10);

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.BankName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CurrencyId)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasColumnName("IBAN")
                    .HasMaxLength(30);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Swift)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.Utr)
                    .IsRequired()
                    .HasColumnName("UTR")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Bank)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Bank__CompanyId__693CA210");
            });

            modelBuilder.Entity<BankMov>(entity =>
            {
                entity.HasKey(e => e.BankMoveId)
                    .HasName("PK__BankMov__CC22FDF505E4B375");

                entity.ToTable("BankMov", "vk2");

                entity.Property(e => e.AccountNo).HasMaxLength(10);

                entity.Property(e => e.Amount).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Concept)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Reference)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankMov)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK__BankMov__BankId__6A30C649");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company", "vk2");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.CurrencyId)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Legal)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.Property(e => e.Utr)
                    .IsRequired()
                    .HasColumnName("UTR")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Doc>(entity =>
            {
                entity.ToTable("Doc", "vk2");

                entity.Property(e => e.AncestorNo).HasMaxLength(10);

                entity.Property(e => e.Author).HasMaxLength(128);

                entity.Property(e => e.Comment).HasMaxLength(128);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreditNo).HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.DocDate).HasColumnType("datetime");

                entity.Property(e => e.DocNo).HasMaxLength(10);

                entity.Property(e => e.DocStatus).HasMaxLength(4);

                entity.Property(e => e.DocTypeId)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Freight).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.SubTotal).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.TaxAmount).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Total).HasColumnType("numeric(20, 2)");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.Doc)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doc__DocTypeId__6C190EBB");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Doc)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__Doc__LocationId__6B24EA82");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.Doc)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Doc__TaxId__6D0D32F4");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.ToTable("DocType", "vk2");

                entity.Property(e => e.DocTypeId).HasMaxLength(2);

                entity.Property(e => e.CreditNo).HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.DocStates).HasMaxLength(128);

                entity.Property(e => e.DocTypeName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.Prefix).HasMaxLength(2);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee", "vk2");

                entity.Property(e => e.EmployeeId).HasMaxLength(128);

                entity.Property(e => e.CostHour).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.EmployeeName).HasMaxLength(128);

                entity.Property(e => e.HoursDay).HasColumnType("numeric(20, 2)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Employee__Compan__787EE5A0");
            });

            modelBuilder.Entity<Line>(entity =>
            {
                entity.ToTable("Line", "vk2");

                entity.Property(e => e.Author).HasMaxLength(128);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CreditNo)
                    .HasColumnName("creditNo")
                    .HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.Description).HasMaxLength(128);

                entity.Property(e => e.LineTypeId)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Price).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.RegisteredOn).HasColumnType("datetime");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Line)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("FK__Line__DocId__6E01572D");

                entity.HasOne(d => d.LineType)
                    .WithMany(p => p.Line)
                    .HasForeignKey(d => d.LineTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Line__LineTypeId__6EF57B66");

                entity.HasOne(d => d.Tax)
                    .WithMany(p => p.Line)
                    .HasForeignKey(d => d.TaxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Line__TaxId__6FE99F9F");
            });

            modelBuilder.Entity<LineType>(entity =>
            {
                entity.ToTable("LineType", "vk2");

                entity.Property(e => e.LineTypeId).HasMaxLength(2);

                entity.Property(e => e.CreditNo).HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.LineStates).HasMaxLength(128);

                entity.Property(e => e.LineTypeName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location", "vk2");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Legal)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(125);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("FK__Location__Partne__70DDC3D8");
            });

            modelBuilder.Entity<Mov>(entity =>
            {
                entity.HasKey(e => e.MoveId)
                    .HasName("PK__Mov__A931A41C5A12E06D");

                entity.ToTable("Mov", "vk2");

                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.CreditNo)
                    .HasColumnName("creditNo")
                    .HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.MovetypeId)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Price).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Quantity).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.SerialNo).HasMaxLength(50);

                entity.HasOne(d => d.Line)
                    .WithMany(p => p.Mov)
                    .HasForeignKey(d => d.LineId)
                    .HasConstraintName("FK__Mov__LineId__72C60C4A");

                entity.HasOne(d => d.Movetype)
                    .WithMany(p => p.Mov)
                    .HasForeignKey(d => d.MovetypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mov__MovetypeId__71D1E811");
            });

            modelBuilder.Entity<MoveType>(entity =>
            {
                entity.ToTable("MoveType", "vk2");

                entity.Property(e => e.MoveTypeId).HasMaxLength(2);

                entity.Property(e => e.CreditNo).HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.MovStates).HasMaxLength(128);

                entity.Property(e => e.MoveTypeName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner", "vk2");

                entity.Property(e => e.CountryId)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.CreditNo).HasMaxLength(10);

                entity.Property(e => e.CurrencyId)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.PartnerName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Utr)
                    .IsRequired()
                    .HasColumnName("UTR")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Partner)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Partner__Company__73BA3083");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product", "vk2");

                entity.Property(e => e.Ean13)
                    .HasColumnName("EAN13")
                    .HasMaxLength(13);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasColumnName("SKU")
                    .HasMaxLength(30);

                entity.Property(e => e.StdCost).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.Unit).HasMaxLength(32);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Product__Company__74AE54BC");
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.ToTable("Tax", "vk2");

                entity.Property(e => e.CreditNo).HasMaxLength(10);

                entity.Property(e => e.DebitNo).HasMaxLength(10);

                entity.Property(e => e.Percentage).HasColumnType("numeric(20, 2)");

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Tax)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Tax__CompanyId__75A278F5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
