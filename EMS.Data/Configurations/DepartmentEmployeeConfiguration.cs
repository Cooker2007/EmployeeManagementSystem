namespace EMS.Data.Configurations
{
    using EMS.Domain;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    internal class DepartmentEmployeeConfiguration : EntityTypeConfiguration<DepartmentEmployee>
    {
        public DepartmentEmployeeConfiguration()
        {
            // Table
            this.ToTable("dept_emp");

            // Key
            this.HasKey(e => e.Id);

            // Properties
            this.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Guid).HasColumnName("guid").HasColumnType("varchar");

            this.Property(e => e.DepartmentId).HasColumnName("dept_no").HasColumnType("varchar").IsRequired();

            this.Property(e => e.EmployeeId).HasColumnName("emp_no").HasColumnType("integer").IsRequired();

            this.Property(e => e.FromDate).HasColumnName("from_date").HasColumnType("datetime").IsRequired();

            this.Property(e => e.ToDate).HasColumnName("to_date").HasColumnType("datetime").IsRequired();
        }
    }
}