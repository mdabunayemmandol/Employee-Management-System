using AutoMapper;
using EIMS.Core.CommonModel;
using EIMS.Core.Model;
using EIMS.Core.Model.OperationModule;
using EIMS.Core.Model.SetupModule;
using EIMS.Core.ViewModel;
using EIMS.Core.ViewModel.OperationModule;
using EIMS.Core.ViewModel.SetupModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIMS.Core.AutoMapperConfigurations
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";
        public MappingsProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Designation, DesignationViewModel>();
            CreateMap<DesignationViewModel, Designation>();

            CreateMap<University, UniversityViewModel>();
            CreateMap<UniversityViewModel, University>();

            CreateMap<Subject, SubjectViewModel>();
            CreateMap<SubjectViewModel, Subject>();

            CreateMap<GeneralInformation, GeneralInformationViewModel>()
               .ForMember(vm => vm.BirthDate,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.BirthDate)))
                   .ForMember(dto => dto.JObJoiningDate,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.JObJoiningDate)));

            CreateMap<GeneralInformationViewModel, GeneralInformation>()
                .ForMember(dto => dto.BirthDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.BirthDate)))
                .ForMember(dto => dto.JObJoiningDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.JObJoiningDate)));

            CreateMap<EducationalInformation, EducationalInformationViewModel>();
            CreateMap<EducationalInformationViewModel, EducationalInformation>();

            CreateMap<EmploymentInformation, EmploymentInformationViewModel>();
            CreateMap<EmploymentInformationViewModel, EmploymentInformation>();

            CreateMap<FamilyInformation, FamilyInformationViewModel>();
            CreateMap<FamilyInformationViewModel, FamilyInformation>();

            CreateMap<TrainingInformation, TrainingInformationViewModel>();
            CreateMap<TrainingInformationViewModel, TrainingInformation>();

            CreateMap<SocialMediaInformation, SocialMediaInformationViewModel>();
            CreateMap<SocialMediaInformationViewModel, SocialMediaInformation>();
        }
    }
}
