using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Ticket;
using System.Linq;
using AutoMapper;

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
                user.Basket.Tickets.Add(item);
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

        public IEnumerable<TicketDTO> GetAllUserBasketItems(string userName)
        {
            var user = _unitOfWork.UserRepository.GetAll().Where(u => u.UserName == userName).First();
            if(user != null)
            {
                if (user.Basket != null)
                {
                    var items = user.Basket.Tickets;
                    var itemsDTO = new List<TicketDTO>();
                    foreach (var item in items)
                    {
                        var itemDTO = _mapper.Map<TicketDTO>(item);
                        itemsDTO.Add(itemDTO);
                    }
                }
                return new List<TicketDTO>();
            }

            return new List<TicketDTO>();
        }
    }
}
