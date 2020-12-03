using System;
using System.Collections.Generic;

#nullable disable

namespace BDLab3
{
    public partial class Session
    {
        public Session()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int StFilmId { get; set; }
        public int StRoomId { get; set; }
        public DateTime Date { get; set; }

        public virtual Film StFilm { get; set; }
        public virtual Room StRoom { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
    public class Session_UDI
    {
        public static void Insert(int id, int filmid, int roomid, DateTime date)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Session newsession = new Session();
                newsession.Id = id;
                newsession.StFilmId = filmid;
                newsession.StRoomId = roomid;
                newsession.Date = date;
                db.Sessions.Add(newsession);
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Session newsession = db.Sessions.Find(id);
                db.Sessions.Remove(newsession);
                db.SaveChanges();
            }
        }

        public static void Update(int id, int filmid, int roomid, DateTime date)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Session newsession = db.Sessions.Find(id);
                newsession.StRoomId = roomid;
                newsession.StFilmId = filmid;
                newsession.Date = date;
                db.Sessions.Update(newsession);
                db.SaveChanges();
            }
        }
    }
}
