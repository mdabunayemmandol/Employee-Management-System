using EIMS.Core.Model;
using EIMS.Core.Model.OperationModule;
using EIMS.Core.Model.SetupModule;
using EIMS.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Persistance.DatabaseFile
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<University> University { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<GeneralInformation> GeneralInformations { get; set; }
        public DbSet<EducationalInformation> EducationalInformations { get; set; }
        public DbSet<EmploymentInformation> EmploymentInformations { get; set; }
        public DbSet<FamilyInformation> FamilyInformations { get; set; }
        public DbSet<TrainingInformation> TrainingInformations { get; set; }
        public DbSet<SocialMediaInformation> SocialMediaInformations { get; set; }
    }
}
