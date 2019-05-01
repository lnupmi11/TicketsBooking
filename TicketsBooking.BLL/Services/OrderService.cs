using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.BLL.Interfaces;
using TicketsBooking.DAL.Interfaces;
using TicketsBooking.DTO.Cart;

namespace TicketsBooking.BLL.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddItemToBasket(string userName, string itemId)
        {
            var item = _unitOfWork.TicketRepository.Get(itemId);
            if (item != null)
            {
               
                _unitOfWork.SaveChanges();
            }
        }

        public void DeleteItemFromBasket(string userName, string itemId)
        {
            var item = _unitOfWork.TicketRepository.Get(itemId);
            if (item != null)
            {
                
                
            }
        }

        public IEnumerable<CartItemDTO> GetAllUserBasketItems(string userName)
        {
            return null;
        }
    }
}
