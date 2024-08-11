using EIMS.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.Model.OperationModule
{
    public class TrainingInformation: BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string CourseName { get; set; }
        public string Result { get; set; }
        public string InstituteName { get; set; }
        public string Institute { get; set; }
        public string Duration { get; set; }
        public string Year { get; set; }
        public string Remark { get; set; }
    }
}
