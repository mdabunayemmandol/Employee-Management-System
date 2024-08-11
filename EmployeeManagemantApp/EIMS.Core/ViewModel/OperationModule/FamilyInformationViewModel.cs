using EIMS.Core.Model.OperationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.ViewModel.OperationModule
{
    public class FamilyInformationViewModel
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string Relation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }

        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
}
