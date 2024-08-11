using EIMS.Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.Model.OperationModule
{
    public class FamilyInformation: BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public string Relation { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Remark { get; set; }
    }
}
