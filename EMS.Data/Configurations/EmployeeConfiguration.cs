using EMS.Domain;

namespace EMS.Data.Configurations
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    internal class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            // Table
            this.ToTable("employee");

            // Key
            this.HasKey(e => e.DatabaseId);

            // Properties
            this.Property(e => e.DatabaseId)
                .HasColumnName("emp_no")
                .HasColumnType("integer")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.FirstName)
                .HasColumnName("first_name")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(14);

            this.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(16);

            this.Property(e => e.Guid).HasColumnName("guid").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

#pragma warning disable 618
            this.Property(e => e.GenderDatabase).HasColumnName("gender").HasColumnType("varchar").HasMaxLength(1).IsRequired();
#pragma warning restore 618

            this.Property(e => e.BirthDate).HasColumnName("birth_date").HasColumnType("datetime").IsRequired();

            this.Property(e => e.HireDate).HasColumnName("hire_date").HasColumnType("datetime").IsRequired();

            // Relationships
            this.HasMany(e => e.Departments).WithRequired(e => e.Employee).HasForeignKey(e => e.EmployeeId).WillCascadeOnDelete(false);

            this.HasMany(e => e.Managers).WithRequired(e => e.Employee).HasForeignKey(e => e.EmployeeId).WillCascadeOnDelete(false);

            this.HasMany(e => e.Salaries).WithRequired(e => e.Employee).HasForeignKey(e => e.EmployeeId).WillCascadeOnDelete(false);

            this.HasMany(e => e.Titles).WithRequired(e => e.Employee).HasForeignKey(e => e.EmployeeId).WillCascadeOnDelete(false);

            // this.Ignore(e => e.Gender);
        }
    }
}