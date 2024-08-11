using AutoMapper;
using EIMS.Core.Model.SetupModule;
using EIMS.Core.ViewModel;
using EIMS.Core.ViewModel.SetupModule;
using EIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Service.Manager
{
    public class SubjectService
    {
        private ApplicationDbContext _dbContext;
        public SubjectService()
        {
            _dbContext = new ApplicationDbContext();
        }
        public SubjectViewModel Get(int id)
        {
            var entity = _dbContext.Subject.SingleOrDefault(c => c.Id == id);

            //var model = new DepartmentViewModel()
            //{
            //    Id = entity.Id,
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    IsActive = entity.IsActive
            //};
            return (Mapper.Map<Subject, SubjectViewModel>(entity));
        }
        public IEnumerable<SubjectViewModel> GetAll()
        {
            var entities = _dbContext.Subject.ToList().Select(Mapper.Map<Subject, SubjectViewModel>);
            return entities;
        }

        public int Add(SubjectViewModel vm)
        {
            var entity = Mapper.Map<SubjectViewModel, Subject>(vm);
            _dbContext.Subject.Add(entity);
            return _dbContext.SaveChanges();
        }


        public object Get(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id, SubjectViewModel vm)
        {
            var entity = _dbContext.Subject.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _dbContext.Subject.SingleOrDefault(c => c.Id == id);
            _dbContext.Subject.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
