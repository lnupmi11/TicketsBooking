using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Entities;
using TicketsBooking.DAL.Interfaces;

namespace TicketsBooking.BLL.Services
{
    public class LikeServices : IServiceLike
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public LikeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(Like like)
        {
            if (like != null)
            {
                var ticket = _mapper.Map<Like>(like);
                _unitOfWork.LikeRepository.Create(like);
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.LikeRepository.Delete(id.ToString());
        }

        public Like Get(int id)
        {
            var like = _unitOfWork.LikeRepository.Get(id.ToString());
            var likeDto = _mapper.Map<Like>(like);

            return likeDto;
        }

        public IEnumerable<Like> GetAll()
        {
            var likes = _unitOfWork.LikeRepository.GetAll();
            var likesDTO = new List<Like>();

            foreach (var item in likes)
            {
                var like = _mapper.Map<Like>(item);
                likesDTO.Add(like);
            }

            return likesDTO;
        }

        public void Update(Like likeDTO)
        {
            var like = _mapper.Map<Like>(likeDTO);
            _unitOfWork.LikeRepository.Update(like);
            _unitOfWork.SaveChanges();
        }
    }
}