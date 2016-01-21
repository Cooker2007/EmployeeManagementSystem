namespace EMS.Data.Configurations
{
    using EMS.Domain;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    internal class TitleConfiguration : EntityTypeConfiguration<Title>
    {
        public TitleConfiguration()
        {
            this.ToTable("title");
            this.HasKey(e => e.DatabaseId);

            this.Property(e => e.DatabaseId)
                .HasColumnName("id")
                .HasColumnType("integer")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(e => e.Guid).HasColumnName("guid").HasColumnType("UNIQUEIDENTIFIER").IsRequired();

            this.Property(e => e.Name).HasColumnName("title").HasColumnType("varchar").IsRequired();

            this.Property(e => e.EmployeeId).HasColumnName("emp_no").HasColumnType("integer").IsRequired();

            this.Property(e => e.FromDate).HasColumnName("from_date").HasColumnType("datetime").IsRequired();

            this.Property(e => e.ToDate).HasColumnName("to_date").HasColumnType("datetime");
        }
    }
}