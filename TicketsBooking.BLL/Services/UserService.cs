using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Repositories;
using TicketsBooking.DAL.EntityFramework;
using TicketsBooking.DAL.Interfaces;
using System.Security.Claims;
using System.Linq;
using AutoMapper;
using TicketsBooking.DTO.User;

namespace TicketsBooking.BLL.Services
{
    public class UserService : IServiceUser
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public User GetUser(string id)
        {
            return _unitOfWork.UserRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            var iteam = _unitOfWork.UserRepository.GetAll();
            return iteam;
        }

        public void ChangeUsername(User user, string name)
        {
            user.UserName = name;
            _unitOfWork.UserRepository.Update(user);
        }

        public void ChangeFirstname(User user, string firstname)
        {
            user.FirstName = firstname;
            _unitOfWork.UserRepository.Update(user);
        }

        public void ChangeLastname(User user, string lastname)
        {
            user.LastName = lastname;
            _unitOfWork.UserRepository.Update(user);
        }

        public void Delete(User user)
        {
            _unitOfWork.UserRepository.Delete(user.Id);
        }

        public User GetByName(string userName)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName).FirstOrDefault();

            return user;
        }
    }
}
