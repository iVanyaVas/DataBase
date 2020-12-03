using System;
using System.Collections.Generic;

#nullable disable

namespace BDLab3
{
    public partial class SeatRow
    {
        public SeatRow()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int SeatId { get; set; }
        public int RowId { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }


    public class SeatRow_UDI
    {
        public static void Insert(int id, int seatid, int rowid)
        {
            using (CinemaContext db = new CinemaContext())
            {
                SeatRow newseat = new SeatRow();
                newseat.Id = id;
                newseat.RowId = rowid;
                newseat.SeatId = seatid;

                db.SeatRows.Add(newseat);
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                SeatRow newseat = db.SeatRows.Find(id);
                db.SeatRows.Remove(newseat);
                db.SaveChanges();
            }
        }

        public static void Update(int id, int seatid, int rowid)
        {
            using (CinemaContext db = new CinemaContext())
            {
                SeatRow newseat = db.SeatRows.Find(id);
                newseat.RowId = rowid;
                newseat.SeatId = seatid;
                db.SeatRows.Update(newseat);
                db.SaveChanges();
            }
        }
    }
}
