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
    public class StudentRequestService
    {
        StudentRequestRepo repo;
        IMapper mapper;

        public StudentRequestService(StudentRequestRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public List<StudentRequestInfoModel> GetAllStudentRequestsWithInfo()
        {
            var data = repo.GetAllStudentRequestsWithInfo();
            var mappedObj = mapper.Map<List<StudentRequestInfoModel>>(data);
            return mappedObj;
        }

        public List<StudentRequestModel> GetAllStudentRequests()
        {
            var data = repo.GetAllStudentRequests();
            var mappedObj = mapper.Map<List<StudentRequestModel>>(data);
            return mappedObj;
        }

        public StudentRequestModel GetStudentRequestById(int id)
        {
            var data = repo.GetStudentRequestById(id);
            var mappedObj = mapper.Map<StudentRequestModel>(data);
            return mappedObj;
        }

        public bool CreateStudentRequest(StudentRequestModel obj)
        {
            var mappedObj = mapper.Map<StudentRequest>(obj);
            var data = repo.CreateStudentRequest(mappedObj);
            return data;
        }

        public bool UpdateStudentRequest(StudentRequestModel obj)
        {
            var mappedObj = mapper.Map<StudentRequest>(obj);
            var data = repo.UpdateStudentRequest(mappedObj);
            return data;
        }

        public bool DeleteStudentRequest(int id)
        {
            var data = repo.DeleteStudentRequest(id);
            return data;
        }
    }
}
