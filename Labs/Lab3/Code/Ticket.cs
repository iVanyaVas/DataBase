using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace BDLab3
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int PlaceId { get; set; }
        public int ClientId { get; set; }
        public int SessionId { get; set; }

        public virtual Client Client { get; set; }
        public virtual SeatRow Place { get; set; }
        public virtual Session Session { get; set; }
    }

    public class Ticket_UDI
    {
        public static void Insert(int id, int placeid, int clientid, int sessionid)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Ticket ticket = new Ticket();
                ticket.TicketId = id;
                ticket.SessionId = sessionid;
                ticket.ClientId = clientid;
                ticket.PlaceId = placeid;
                db.Tickets.Add(ticket);
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Ticket ticket = db.Tickets.Find(id);
                db.Tickets.Remove(ticket);
                db.SaveChanges();
            }
        }

        public static void Update(int id, int placeid, int clientid, int sessionid)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Ticket ticket = db.Tickets.Find(id);
                ticket.SessionId = sessionid;
                ticket.ClientId = clientid;
                ticket.PlaceId = placeid;
                db.Tickets.Update(ticket);
                db.SaveChanges();
            }
        }
    }
}
