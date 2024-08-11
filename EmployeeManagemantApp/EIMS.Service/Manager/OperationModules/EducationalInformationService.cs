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
    public class EducationalInformationService
    {
        private ApplicationDbContext _dbContext;
        public EducationalInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public EducationalInformationViewModel Get(int id)
        {
            var entity = _dbContext.EducationalInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<EducationalInformation, EducationalInformationViewModel>(entity));
        }

        public IEnumerable<EducationalInformationViewModel> GetAll()
        {
            var entities = _dbContext.EducationalInformations
                .Include("Subject")
                .Include("University")
                .ToList().Select(Mapper.Map<EducationalInformation, EducationalInformationViewModel>);
            return entities;
        }

        public int Add(EducationalInformationViewModel vm)
        {
            var entity = Mapper.Map<EducationalInformationViewModel, EducationalInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.EducationalInformations.Add(entity);
            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }
        public int Update(int id, EducationalInformationViewModel vm)
        {
            var entity = _dbContext.EducationalInformations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }
        public int Remove(int id)
        {
            var entity = _dbContext.EducationalInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.EducationalInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
