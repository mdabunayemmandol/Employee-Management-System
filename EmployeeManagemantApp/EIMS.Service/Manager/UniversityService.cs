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
    public class UniversityService
    {
        private ApplicationDbContext _dbContext;
        public UniversityService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public UniversityViewModel Get(int id)
        {
            var entity = _dbContext.University.SingleOrDefault(c => c.Id == id);

            //var model = new DepartmentViewModel()
            //{
            //    Id = entity.Id,
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    IsActive = entity.IsActive
            //};
            return (Mapper.Map<University, UniversityViewModel>(entity));
        }
        public IEnumerable<UniversityViewModel> GetAll()
        {
            var entities = _dbContext.University.ToList().Select(Mapper.Map<University, UniversityViewModel>);
            return entities;
        }
        public int Add(UniversityViewModel vm)
        {
            var entity = Mapper.Map<UniversityViewModel, University>(vm);
            _dbContext.University.Add(entity);
            return _dbContext.SaveChanges();
        }
        public object Get(object id)
        {
            throw new NotImplementedException();
        }
        public int Update(int id, UniversityViewModel vm)
        {
            var entity = _dbContext.University.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            var entity = _dbContext.University.SingleOrDefault(c => c.Id == id);
            _dbContext.University.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
