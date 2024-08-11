using EIMS.Core.Model.OperationModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.ViewModel.OperationModule
{
    public class SocialMediaInformationViewModel
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string ProfileName { get; set; }
        public string ProfileLink { get; set; }
        public string Remark { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
}
