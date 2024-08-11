using AutoMapper;
using EIMS.Core.Model.OperationModule;
using EIMS.Core.ViewModel;
using EIMS.Core.ViewModel.OperationModule;
using EIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Service.Manager.OperationModules
{
    public class TrainingInformationService
    {
        private ApplicationDbContext _dbContext;
        public TrainingInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public TrainingInformationViewModel Get(int id)
        {
            var entity = _dbContext.TrainingInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<TrainingInformation, TrainingInformationViewModel>(entity));
        }

        public IEnumerable<TrainingInformationViewModel> GetAll()
        {
            var entities = _dbContext.TrainingInformations
                .ToList().Select(Mapper.Map<TrainingInformation, TrainingInformationViewModel>);
            return entities;
        }

        public int Add(TrainingInformationViewModel vm)
        {
            var entity = Mapper.Map<TrainingInformationViewModel, TrainingInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.TrainingInformations.Add(entity);
            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }

        public int Update(int id, TrainingInformationViewModel vm)
        {
            var entity = _dbContext.TrainingInformations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.TrainingInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.TrainingInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
