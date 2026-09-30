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
    public class DepartmentService
    {
        DepartmentRepo repo;
        IMapper mapper;

        public DepartmentService(DepartmentRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public List<DepartmentModel> GetAllDepartments()
        {
            var data = repo.GetAllDepartments();
            var mappedObj = mapper.Map<List<DepartmentModel>>(data);
            return mappedObj;
        }

        public DepartmentModel GetDepartmentById(int id)
        {
            var data = repo.GetDepartmentById(id);
            var mappedObj = mapper.Map<DepartmentModel>(data);
            return mappedObj;
        }

        public bool CreateDepartment(DepartmentModel obj)
        {
            var mappedObj = mapper.Map<Department>(obj);
            var data = repo.CreateDepartment(mappedObj);
            return data;
        }

        public bool UpdateDepartment(DepartmentModel obj)
        {
            var mappedObj = mapper.Map<Department>(obj);
            var data = repo.UpdateDepartment(mappedObj);
            return data;
        }

        public bool DeleteDepartment(int id)
        {
            var data = repo.DeleteDepartment(id);
            return data;
        }
    }
}
