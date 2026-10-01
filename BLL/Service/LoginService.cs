using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;
using BLL.Models;
using AutoMapper;


namespace BLL.Service
{
    public class LoginService
    {
        UserRepo repo;
        IMapper mapper;
        public LoginService(UserRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public UserModel GetUserByEmailAndPassword(string email, string password)
        {
            var data = repo.GetUserByEmailAndPassword(email, password);
            var mappedObj = mapper.Map<UserModel>(data);
            return mappedObj;
        }
    }
}
