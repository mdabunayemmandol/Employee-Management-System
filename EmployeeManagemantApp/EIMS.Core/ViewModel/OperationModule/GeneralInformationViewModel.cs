using EIMS.Core.Model;
using EIMS.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.ViewModel.OperationModule
{
    public class GeneralInformationViewModel
    {
        public int Id { get; set; }
        [Required]
        public string EmployeId { get; set; }
        [Required]
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string NationalId { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Religon { get; set; }
        public string MaritialStatus { get; set; }
        public string JObJoiningDate { get; set; }

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
