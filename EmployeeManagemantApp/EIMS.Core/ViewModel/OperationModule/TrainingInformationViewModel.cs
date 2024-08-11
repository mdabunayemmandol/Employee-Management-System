using EIMS.Core.Model.OperationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.ViewModel.OperationModule
{
    public class TrainingInformationViewModel
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

        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
}
