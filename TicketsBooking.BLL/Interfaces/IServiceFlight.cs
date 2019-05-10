using System;
using System.Collections.Generic;
using System.Text;
using TicketsBooking.DTO.Flight;

namespace TicketsBooking.BLL.Interfaces
{
    public interface IServiceFlight
    {
        void Create(FlightDTO ticket);
        void Delete(int id);
        void Update(FlightDTO ticket);
        IEnumerable<FlightDTO> GetAll();
        FlightDTO Get(int id);
    }
}
