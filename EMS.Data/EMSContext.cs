namespace EMS.Data
{
    using EMS.Data.Configurations;
    using EMS.Domain;
    using System.Data.Entity;

    public partial class EMSContext : DbContext
    {
        public EMSContext()
            : base("name=EmployeeModelSQLite")
        {
            //  Database.SetInitializer<EmployeeContext>(null);
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentEmployee> DepartmentEmployees { get; set; }
        public virtual DbSet<DepartmentManager> DepartmentManagers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Title> Titles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<GenderType>();

            modelBuilder.Configurations.Add(new DepartmentConfiguration());
            modelBuilder.Configurations.Add(new DepartmentEmployeeConfiguration());
            modelBuilder.Configurations.Add(new DepartmentManagerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new SalaryConfiguration());
            modelBuilder.Configurations.Add(new TitleConfiguration());
        }
    }
}