using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsBooking.Models;

namespace TicketsBooking.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(List<TicketViewModel> flightViewModel)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>ID</th>
                                        <th>Location from</th>
                                        <th>Location to</th>
                                        <th>Price</th>
                                    </tr>");

            foreach (var item in flightViewModel)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", item.Id, item.LocationFrom, item.LocationTo, item.Price);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
