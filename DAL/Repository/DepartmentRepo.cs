using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class DepartmentRepo
    {
        TutorConnectContext db;
        public DepartmentRepo(TutorConnectContext db)
        {
            this.db = db;
        }

        public List<Department> GetAllDepartments()
        {
            return db.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            var data = db.Departments.Find(id);
            return data;
        }

        public bool CreateDepartment(Department Department)
        {
            var data = db.Departments.Add(Department);
            return db.SaveChanges() > 0;
        }

        public bool UpdateDepartment(Department Department)
        {
            var exDepartment = db.Departments.Find(Department.DepartmentId);

            if (exDepartment == null)
            {
                return false;
            }

            exDepartment.DepartmentName = Department.DepartmentName;
            return db.SaveChanges() > 0;
        }

        public bool DeleteDepartment(int id)
        {
            var data = db.Departments.Find(id);
            db.Departments.Remove(data);
            return db.SaveChanges() > 0;
        }
    }
}
