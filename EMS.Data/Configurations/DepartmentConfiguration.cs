using EMS.Domain;

namespace EMS.Data.Configurations
{
    using System.Data.Entity.ModelConfiguration;

    internal class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            // Table
            this.ToTable("department");

            // Primary Key
            this.HasKey(e => e.PersistenceId);

            // Properties
            this.Property(e => e.PersistenceId)
                .HasColumnName("dept_no")
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(4)
                .IsFixedLength();


            this.Property(e => e.Guid).HasColumnName("guid").HasColumnType("UNIQUEIDENTIFIER").IsRequired();
            this.Property(e => e.Name).HasColumnName("dept_name").HasColumnType("varchar").IsRequired().HasMaxLength(40);

            // Relationships
            this.HasMany(e => e.Employees).WithRequired(e => e.Department).HasForeignKey(e => e.DepartmentId).WillCascadeOnDelete(false);

            this.HasMany(e => e.Managers).WithRequired(e => e.Department).HasForeignKey(e => e.DepartmentId).WillCascadeOnDelete(false);
        }
    }
}