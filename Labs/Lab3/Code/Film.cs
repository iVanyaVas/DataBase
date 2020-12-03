using System;
using System.Collections.Generic;

#nullable disable

namespace BDLab3
{
    public partial class Film
    {
        public Film()
        {
            Sessions = new HashSet<Session>();
        }

        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public string Duration { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }

    public class Film_UDI
    {
        public static void Insert(int id, string film_name, string duration)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Film newfilm = new Film();

                newfilm.Duration = duration;
                newfilm.FilmId = id;
                newfilm.FilmName = film_name;

                db.Films.Add(newfilm);
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Film newfilm = db.Films.Find(id);
                db.Films.Remove(newfilm);
                db.SaveChanges();
            }
        }

        public static void Update(int id, string film_name, string duration)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Film newfilm = db.Films.Find(id);
                newfilm.FilmName = film_name;
                newfilm.Duration = duration;
                db.Films.Update(newfilm);
                db.SaveChanges();
            }
        }
    }
}
