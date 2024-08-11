using AutoMapper;
using EIMS.Core.CommonModel;
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
    public class GeneralInformationService
    {
        private ApplicationDbContext _dbContext;
        public GeneralInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public GeneralInformationViewModel Get(int id)
        {
            var entity = _dbContext.GeneralInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<GeneralInformation, GeneralInformationViewModel>(entity));
        }

        public IEnumerable<GeneralInformationViewModel> GetAll()
        {
            var entities = _dbContext.GeneralInformations
                .Include("Department")
                .Include("Designation")
                .ToList().Select(Mapper.Map<GeneralInformation, GeneralInformationViewModel>);
            return entities;
        }

        public int Add(GeneralInformationViewModel vm)
        {
            var entity = Mapper.Map<GeneralInformationViewModel, GeneralInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.GeneralInformations.Add(entity);
            _dbContext.SaveChanges();

            return entity.Id;
        }

        public int Update(int id, GeneralInformationViewModel vm)
        {
            var entity = _dbContext.GeneralInformations.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            _dbContext.SaveChanges();

            return entity.Id;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.GeneralInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.GeneralInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public string GenerateEmployeId()
        {
            int parsonalNo = 0;

            var list = _dbContext.GeneralInformations.ToList()
                .OrderByDescending(c => c.Id).FirstOrDefault();

            if (list == null)
            {
                var code = "NSSL-" + "000001";
                return code;
            }

            {
                string[] parts = list.EmployeId.Split('-');
                parsonalNo = Convert.ToInt32(parts[1]);
            }

            var traineeParsonalNo = "NSSL-" + (parsonalNo + 1).ToString().PadLeft(5, '0');
            return traineeParsonalNo;
        }
    }
}