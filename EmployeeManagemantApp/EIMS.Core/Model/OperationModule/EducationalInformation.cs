﻿using EIMS.Core.CommonModel;
using EIMS.Core.Model.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.Model.OperationModule
{
    public class EducationalInformation: BaseDomain
    {
        public int Id { get; set; }
        public int GeneralInformationId { get; set; }
        public GeneralInformation GeneralInformation { get; set; }
        public int UniversityId { get; set; }
        public University University { get; set; }
        public string InstituteName { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string SubjectName { get; set; }
        public string Result { get; set; }
        public string PassingYear { get; set; }
        public string Duration { get; set; }
        public string BoardName { get; set; }
        public string Remark { get; set; }
    }
}
