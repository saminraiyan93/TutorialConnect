using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Models;
using DAL.EF.Tables;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<StudentRequest, StudentRequestModel>().ReverseMap();
            CreateMap<TutorOffering, TutorOfferingModel>().ReverseMap();

            CreateMap<Course, CourseInfoModel>().
                ForMember(dest => dest.CourseDepartmentName,
                    src => src.MapFrom(x => x.Department.DepartmentName));

            CreateMap<TutorOffering, TutorOfferingInfoModel>()
                .ForMember(
                    dest => dest.UserName,
                    src => src.MapFrom(x => x.User.UserName)
                )
                .ForMember(
                    dest => dest.CourseName,
                    src => src.MapFrom(x => x.Course.CourseName)

                )
                .ForMember(
                    dest => dest.DepartmentName,
                    src => src.MapFrom(x => x.Course.Department.DepartmentName)
                );

            CreateMap<StudentRequest, StudentRequestInfoModel>()
                .ForMember(
                    dest => dest.UserName,
                    src => src.MapFrom(x => x.User.UserName)
                )
                .ForMember(
                    dest => dest.CourseName,
                    src => src.MapFrom(x => x.Course.CourseName)
                )
                .ForMember(
                    dest => dest.DepartmentName,
                    src => src.MapFrom(x => x.Course.Department.DepartmentName)
                );


        }
    }
}
