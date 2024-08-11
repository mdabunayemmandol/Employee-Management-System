using AutoMapper;
using EIMS.Core.Model;
using EIMS.Core.ViewModel;
using EIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Service.Manager
{
    public class DepartmentService
    {
        private ApplicationDbContext _dbContext;
        public DepartmentService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public DepartmentViewModel Get(int id) 
        {
            var entity = _dbContext.Departments.SingleOrDefault(c => c.Id == id);

            //var model = new DepartmentViewModel()
            //{
            //    Id = entity.Id,
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    IsActive = entity.IsActive
            //};
            return (Mapper.Map<Department, DepartmentViewModel>(entity));
        }
        public IEnumerable<DepartmentViewModel> GetAll()
        {
            var entities = _dbContext.Departments.ToList().Select(Mapper.Map<Department, DepartmentViewModel>);
            return entities;
        }
        public int Add(DepartmentViewModel vm)
        {
            var entity = Mapper.Map<DepartmentViewModel, Department>(vm);
            _dbContext.Departments.Add(entity);
           return _dbContext.SaveChanges();
        }

        public object Get(object id)
        {
            throw new NotImplementedException();
        }

        public int Update(int id,DepartmentViewModel vm)
        {
            var entity = _dbContext.Departments.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _dbContext.SaveChanges();
        }
        public int Remove(int id)
        {
            var entity = _dbContext.Departments.SingleOrDefault(c => c.Id == id);
            _dbContext.Departments.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
