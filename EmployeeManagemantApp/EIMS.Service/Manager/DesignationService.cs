using AutoMapper;
using EIMS.Core.Model.SetupModule;
using EIMS.Core.ViewModel.SetupModule;
using EIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Service.Manager
{
    public class DesignationService
    {
        private ApplicationDbContext _dbContext;
        public DesignationService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public DesignationViewModel Get(int id)
        {
            var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);

            //var model = new DesignationViewModel()
            //{
            //    Id = entity.Id,
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    IsActive = entity.IsActive
            //};
            return (Mapper.Map<Designation, DesignationViewModel>(entity));
        }

        public IEnumerable<DesignationViewModel> GetAll()
        {
            var entities = _dbContext.Designations.ToList().Select(Mapper.Map<Designation, DesignationViewModel>);
            return entities;
        }

        public int Add(DesignationViewModel vm)
        {
            var entity = Mapper.Map<DesignationViewModel, Designation>(vm);
            _dbContext.Designations.Add(entity);
            return _dbContext.SaveChanges();
        }

        public object Get(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, DesignationViewModel vm)
        {
            var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _dbContext.Designations.SingleOrDefault(c => c.Id == id);
            _dbContext.Designations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
