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
    public class FamilyInformationService
    {
        private ApplicationDbContext _dbContext;
        public FamilyInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public FamilyInformationViewModel Get(int id)
        {
            var entity = _dbContext.FamilyInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<FamilyInformation, FamilyInformationViewModel>(entity));
        }

        public IEnumerable<FamilyInformationViewModel> GetAll()
        {
            var entities = _dbContext.FamilyInformations
                .ToList().Select(Mapper.Map<FamilyInformation, FamilyInformationViewModel>);
            return entities;
        }

        public int Add(FamilyInformationViewModel vm)
        {
            var entity = Mapper.Map<FamilyInformationViewModel, FamilyInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.FamilyInformations.Add(entity);
            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }

        public int Update(int id, FamilyInformationViewModel vm)
        {
            var entity = _dbContext.FamilyInformations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.FamilyInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.FamilyInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
