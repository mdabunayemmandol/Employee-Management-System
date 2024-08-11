using EIMS.Core.CommonModel;
using EIMS.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.Model.OperationModule
{
    public class GeneralInformation: BaseDomain
    {
        public int Id { get; set; }
        [Required]
        public string EmployeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Fathername { get; set; }
        public string Mothername { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NationalId { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Religon { get; set; }
        public string MaritialStatus { get; set; }
        public DateTime JObJoiningDate { get; set; }
        [Required]
        public string Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int DesignationId { get; set; }
        public Designation Designation { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
    }
}
