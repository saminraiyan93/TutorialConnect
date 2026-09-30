using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using BLL.Models;
using AutoMapper;
using DAL.EF.Tables;

namespace BLL.Service
{
    public class CourseService
    {
        CourseRepo repo;
        IMapper mapper;

        public CourseService(CourseRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public List<CourseInfoModel> GetAllCourseWithInfo()
        {
            var data = repo.GetAllCourseWithInfo();
            var mappedObj = mapper.Map<List<CourseInfoModel>>(data);
            return mappedObj;
        }

        public List<CourseModel> GetAllCourses()
        {
            var data = repo.GetAllCourses();
            var mappedObj = mapper.Map<List<CourseModel>>(data);
            return mappedObj;
        }

        public CourseModel GetCourseById(int id)
        {
            var data = repo.GetCourseById(id);
            var mappedObj = mapper.Map<CourseModel>(data);
            return mappedObj;
        }

        public bool CreateCourse(CourseModel obj)
        {
            var mappedObj = mapper.Map<Course>(obj);
            var data = repo.CreateCourse(mappedObj);
            return data;
        }

        public bool UpdateCourse(CourseModel obj)
        {
            var mappedObj = mapper.Map<Course>(obj);
            var data = repo.UpdateCourse(mappedObj);
            return data;
        }

        public bool DeleteCourse(int id)
        {
            var data = repo.DeleteCourse(id);
            return data;
        }
    }
}
