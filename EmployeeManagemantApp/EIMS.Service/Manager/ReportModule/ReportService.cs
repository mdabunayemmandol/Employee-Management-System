using AutoMapper;
using EIMS.Core.Model.OperationModule;
using EIMS.Core.ViewModel.OperationModule;
using EIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Service.Manager.ReportModule
{
    public class ReportService
    {
        private ApplicationDbContext _dbContext;

        public ReportService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public List<GeneralInformationViewModel> GetAll()
        {
            var entities = _dbContext.GeneralInformations
                .Include("Department")
                .Include("Designation")
                .ToList().Select(Mapper.Map<GeneralInformation, GeneralInformationViewModel>);
            return entities.ToList();
        }
    }
}
