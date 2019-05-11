using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using System.Linq;
using AutoMapper;
using TicketsBooking.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TicketsBooking.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        private IServiceTicket _serviceTicket;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IServiceTicket serviceTicket)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _serviceTicket = serviceTicket;
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

                basket = _unitOfWork.BasketRepository.GetQuery().Include(t=>t.Tickets).Where(t => t.UserId == user.Id).FirstOrDefault();
                basket.Tickets.Add(item);
                _unitOfWork.SaveChanges();
            }
        }

        public void DeleteItemFromBasket(string userName, string itemId)
        {
            var item = _unitOfWork.TicketRepository.Get(itemId);
            var basket = _unitOfWork.UserRepository.GetQuery().Include(u => u.Basket)
                                                        .Include(u => u.Basket.Tickets)
                                                        .FirstOrDefault(u => u.UserName == userName)
                                                        .Basket;
            if (item != null && basket != null)
            {
                basket.Tickets.Remove(item);
                _unitOfWork.SaveChanges();
            }
        }

        public IEnumerable<TicketDTO> GetAllUserBasketItems(string userId)
        {
            var basket = _unitOfWork.BasketRepository.GetQuery().Include(t => t.Tickets)
                .Where(t => t.UserId == userId).FirstOrDefault();
            if (basket != null && basket.Tickets != null)
            {
                var itemsDTO = new List<TicketDTO>();

                foreach (var ticket in basket.Tickets)
                {
                    var itemDTO = _mapper.Map<TicketDTO>(ticket);
                    itemsDTO.Add(itemDTO);
                }

                return itemsDTO;
            }

            return new List<TicketDTO>();
        }
    }
}
