using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EHR.Database
{
    public partial class EHRContext : DbContext
    {
        public EHRContext()
        {
        }

        public EHRContext(DbContextOptions<EHRContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdmissionD> AdmissionD { get; set; }
        public virtual DbSet<AdmissionH> AdmissionH { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PrescriptionD> PrescriptionD { get; set; }
        public virtual DbSet<PrescriptionH> PrescriptionH { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=FAHMY-LAPTOP\\MSSQLSERVER2019;Database=EHR;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmissionD>(entity =>
            {
                entity.ToTable("admissionD");

                entity.Property(e => e.AdmissionDid).HasColumnName("admissionDID");

                entity.Property(e => e.AdmissionHid).HasColumnName("admissionHID");

                entity.HasOne(d => d.AdmissionH)
                    .WithMany(p => p.AdmissionD)
                    .HasForeignKey(d => d.AdmissionHid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admissionD_admissionH");
            });

            modelBuilder.Entity<AdmissionH>(entity =>
            {
                entity.ToTable("admissionH");

                entity.Property(e => e.AdmissionHid).HasColumnName("admissionHID");

                entity.Property(e => e.AdmissionDateTime)
                    .HasColumnName("admissionDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Discharge).HasColumnName("discharge");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.InsuranceId)
                    .HasColumnName("insuranceID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PatientId).HasColumnName("patientID");

                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AdmissionH)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admissionH_Doctor");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.AdmissionH)
                    .HasForeignKey(d => d.InsuranceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admissionH_insurance");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.AdmissionH)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admissionH_Patient");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.AdmissionH)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_admissionH_Room");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(15);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(15);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillId).HasColumnName("BillID");

                entity.Property(e => e.PatientId).HasColumnName("patientID");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_Patient");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.DoctorAddresss).HasMaxLength(50);

                entity.Property(e => e.DoctorCity).HasMaxLength(15);

                entity.Property(e => e.DoctorEmail).HasMaxLength(50);

                entity.Property(e => e.DoctorFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DoctorMobile).HasMaxLength(13);

                entity.Property(e => e.Ssn).HasColumnName("SSN");

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_Department");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Doctor)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Doctor_States");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.GenderId).HasColumnName("genderID");

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasColumnName("genderName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("insurance");

                entity.Property(e => e.InsuranceId).HasColumnName("insuranceID");

                entity.Property(e => e.InsuranceName)
                    .IsRequired()
                    .HasColumnName("insuranceName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineId).HasColumnName("medicineID");

                entity.Property(e => e.MedicineDoseNote)
                    .IsRequired()
                    .HasColumnName("medicineDoseNote")
                    .HasMaxLength(1000);

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("medicineName")
                    .HasMaxLength(50);

                entity.Property(e => e.MedicinePrice).HasColumnName("medicinePrice");

                entity.Property(e => e.MedicineexpiredDate)
                    .HasColumnName("medicineexpiredDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientId).HasColumnName("patientID");

                entity.Property(e => e.GenderId).HasColumnName("genderID");

                entity.Property(e => e.IsAdmissioned).HasColumnName("isAdmissioned");

                entity.Property(e => e.PatientAddresss)
                    .HasColumnName("patientAddresss")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientCity)
                    .HasColumnName("patientCity")
                    .HasMaxLength(15);

                entity.Property(e => e.PatientDob)
                    .HasColumnName("patientDOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.PatientEmail)
                    .HasColumnName("patientEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientFirstName)
                    .IsRequired()
                    .HasColumnName("patientFirstName")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientLastName)
                    .IsRequired()
                    .HasColumnName("patientLastName")
                    .HasMaxLength(50);

                entity.Property(e => e.PatientMobile)
                    .HasColumnName("patientMobile")
                    .HasMaxLength(13);

                entity.Property(e => e.PatientZipCode).HasColumnName("patientZipCode");

                entity.Property(e => e.Ssn).HasColumnName("SSN");

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_Gender");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Patient_States");
            });

            modelBuilder.Entity<PrescriptionD>(entity =>
            {
                entity.ToTable("prescriptionD");

                entity.Property(e => e.PrescriptionDid).HasColumnName("prescriptionDID");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.MedicineId).HasColumnName("medicineID");

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PrescriptionHid).HasColumnName("prescriptionHID");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.PrescriptionD)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prescriptionD_Medicine");

                entity.HasOne(d => d.PrescriptionH)
                    .WithMany(p => p.PrescriptionD)
                    .HasForeignKey(d => d.PrescriptionHid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prescriptionD_prescriptionH");
            });

            modelBuilder.Entity<PrescriptionH>(entity =>
            {
                entity.ToTable("prescriptionH");

                entity.Property(e => e.PrescriptionHid).HasColumnName("prescriptionHID");

                entity.Property(e => e.PrescriptionHdate)
                    .HasColumnName("prescriptionHDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitId).HasColumnName("VisitID");

                entity.HasOne(d => d.Visit)
                    .WithMany(p => p.PrescriptionH)
                    .HasForeignKey(d => d.VisitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_prescriptionH_Visit");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("roomID");

                entity.Property(e => e.AvailableBeds).HasColumnName("availableBeds");

                entity.Property(e => e.RoomNum).HasColumnName("roomNum");

                entity.Property(e => e.RoomTypeId).HasColumnName("roomTypeID");

                entity.Property(e => e.TotalBeds).HasColumnName("totalBeds");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Room)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Room_RoomType");
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.RoomTypeId).HasColumnName("roomTypeID");

                entity.Property(e => e.RoomTypeName)
                    .IsRequired()
                    .HasColumnName("roomTypeName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateId).HasColumnName("stateID");

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasColumnName("stateName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.Property(e => e.VisitId).HasColumnName("VisitID");

                entity.Property(e => e.DoctorId).HasColumnName("DoctorID");

                entity.Property(e => e.PatientId).HasColumnName("patientID");

                entity.Property(e => e.VisitDate).HasColumnType("datetime");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visit_Patient");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
