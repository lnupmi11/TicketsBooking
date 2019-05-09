using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using System.Linq;
using AutoMapper;
using TicketsBooking.DAL.Entities;

namespace TicketsBooking.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void AddItemToBasket(string userName, string itemId)
        {
            var item = _unitOfWork.TicketRepository.Get(itemId);
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName).First();
            if (item != null && user != null)
            {
                var basket = _unitOfWork.BasketRepository.GetAll().Where(t => t.UserId == user.Id).FirstOrDefault();
                if (basket == null)
                {
                    _unitOfWork.BasketRepository.Create(new Basket()
                    {
                        UserId = user.Id,
                        Tickets = new List<Ticket>()
                    });
                    _unitOfWork.SaveChanges();
                }

                basket = _unitOfWork.BasketRepository.GetAll().Where(t => t.UserId == user.Id).FirstOrDefault();
                basket.Tickets.Add(item);
                _unitOfWork.SaveChanges();
            }
        }

        public void DeleteItemFromBasket(string userName, string itemId)
        {
            var item = _unitOfWork.TicketRepository.Get(itemId);
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName).First();
            if (item != null && user != null)
            {
                user.Basket.Tickets.Remove(item);
                _unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<TicketDTO> GetAllUserBasketItems(string userId)
        {
            var basket = _unitOfWork.BasketRepository.GetAll().Where(u => u.UserId == userId).FirstOrDefault();
            if (basket != null && basket.Tickets != null)
            {
                var itemsDTO = new List<TicketDTO>();
                foreach (var item in basket.Tickets)
                {
                    var itemDTO = _mapper.Map<TicketDTO>(item);
                    itemsDTO.Add(itemDTO);
                }
                return itemsDTO;
            }

            return new List<TicketDTO>();
        }
    }
}
