using EIMS.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.Model.OperationModule
{
    public class EmploymentInformation: BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        public string OverSeasExperience { get; set; }
        public string CompanyAddress { get; set; }
        public string Remark { get; set; }
    }
}
