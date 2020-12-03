using System;
using System.Collections.Generic;

#nullable disable

namespace BDLab3
{
    public partial class Room
    {
        public Room()
        {
            Sessions = new HashSet<Session>();
        }

        public int RoomId { get; set; }
        public string RoomColour { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }


    public class Room_UDI
    {
        public static void Insert(int id, string colour)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Room newroom = new Room();
                newroom.RoomColour = colour;
                newroom.RoomId = id;

                db.Rooms.Add(newroom);
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Room newroom = db.Rooms.Find(id);
                db.Rooms.Remove(newroom);
                db.SaveChanges();
            }
        }

        public static void Update(int id, string colour)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Room newroom = db.Rooms.Find(id);
                newroom.RoomColour = colour;
                db.Rooms.Update(newroom);
                db.SaveChanges();
            }
        }
    }
}
