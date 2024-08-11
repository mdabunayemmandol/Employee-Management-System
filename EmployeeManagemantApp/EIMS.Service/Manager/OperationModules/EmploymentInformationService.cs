using AutoMapper;
using EIMS.Core.Model.OperationModule;
using EIMS.Core.ViewModel.OperationModule;
using EIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Service.Manager.OperationModules
{
    public class EmploymentInformationService
    {
        private ApplicationDbContext _dbContext;
        public EmploymentInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public EmploymentInformationViewModel Get(int id)
        {
            var entity = _dbContext.EmploymentInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<EmploymentInformation, EmploymentInformationViewModel>(entity));
        }

        public IEnumerable<EmploymentInformationViewModel> GetAll()
        {
            var entities = _dbContext.EmploymentInformations
                .ToList().Select(Mapper.Map<EmploymentInformation, EmploymentInformationViewModel>);
            return entities;
        }

        public int Add(EmploymentInformationViewModel vm)
        {
            var entity = Mapper.Map<EmploymentInformationViewModel, EmploymentInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.EmploymentInformations.Add(entity);
            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }
        public int Update(int id, EmploymentInformationViewModel vm)
        {
            var entity = _dbContext.EmploymentInformations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }
        public int Remove(int id)
        {
            var entity = _dbContext.EmploymentInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.EmploymentInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
