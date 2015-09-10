namespace EMS.Data.Configurations
{
    using EMS.Domain;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    internal class SalaryConfiguration : EntityTypeConfiguration<Salary>
    {
        public SalaryConfiguration()
        {
            this.ToTable("salary");
            this.HasKey(e => e.Id);

            this.Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Amount).HasColumnName("salary").HasColumnType("real").IsRequired();

            this.Property(e => e.EmployeeId).HasColumnName("emp_no").HasColumnType("integer").IsRequired();

            this.Property(e => e.FromDate).HasColumnName("from_date").HasColumnType("datetime").IsRequired();

            this.Property(e => e.ToDate).HasColumnName("to_date").HasColumnType("datetime").IsRequired();
        }
    }
}