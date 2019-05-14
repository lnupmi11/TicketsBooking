using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TicketsBooking.DAL.Entities
{
    public enum Roles
    {
        [Description("Admin")]
        Admin,
        [Description("User")]
        User,
    }
}
