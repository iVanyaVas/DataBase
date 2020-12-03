using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

#nullable disable

namespace BDLab3
{
    public partial class Passport
    {
        public int Id { get; set; }

        public virtual Client IdNavigation { get; set; }
    }

    public class Passport_UDI
    {
        public static void Insert(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Passport pass = new Passport();
                pass.Id = id;
                db.Passports.Add(pass);
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using(CinemaContext db = new CinemaContext())
            {
                Passport pass = db.Passports.Find(id);
                db.Passports.Remove(pass);
                db.SaveChanges();
            }
        }
    }

}
