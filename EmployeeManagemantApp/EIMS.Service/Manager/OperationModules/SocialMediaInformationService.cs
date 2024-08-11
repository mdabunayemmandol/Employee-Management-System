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
    public class SocialMediaInformationService
    {
        private ApplicationDbContext _dbContext;
        public SocialMediaInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public SocialMediaInformationViewModel Get(int id)
        {
            var entity = _dbContext.SocialMediaInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<SocialMediaInformation, SocialMediaInformationViewModel>(entity));
        }

        public IEnumerable<SocialMediaInformationViewModel> GetAll()
        {
            var entities = _dbContext.SocialMediaInformations
                .ToList().Select(Mapper.Map<SocialMediaInformation, SocialMediaInformationViewModel>);
            return entities;
        }

        public int Add(SocialMediaInformationViewModel vm)
        {
            var entity = Mapper.Map<SocialMediaInformationViewModel, SocialMediaInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.SocialMediaInformations.Add(entity);
            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }

        public int Update(int id, SocialMediaInformationViewModel vm)
        {
            var entity = _dbContext.SocialMediaInformations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.GeneralInformationId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.SocialMediaInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.SocialMediaInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
