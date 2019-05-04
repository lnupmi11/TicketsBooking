using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DTO.Ticket;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IOrderService
    {
        void AddItemToBasket(string basketId, string itemId);
        void DeleteItemFromBasket(string basketId, string itemId);
        IEnumerable<TicketDTO> GetAllUserBasketItems(string basketId);
    }
}
