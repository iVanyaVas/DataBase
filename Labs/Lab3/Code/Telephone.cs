using System;
using System.Collections.Generic;

#nullable disable

namespace BDLab3
{
    public partial class Telephone
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Number { get; set; }

        public virtual Client IdNavigation { get; set; }
    }

    public class Telephone_UDI
    {
        public static void Insert(int id, int clentid, int number)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Telephone telephone = new Telephone();
                telephone.Id = id;
                telephone.ClientId = clentid;
                telephone.Number = number;
                db.Telephones.Add(telephone);
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Telephone telephone = db.Telephones.Find(id);
                db.Telephones.Remove(telephone);
                db.SaveChanges();
            }
        }

        public static void Update(int id, int clentid, int number)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Telephone telephone = db.Telephones.Find(id);
                telephone.ClientId = clentid;
                telephone.Number = number;
                db.Telephones.Update(telephone);
                db.SaveChanges();
            }
        }
    }
}
