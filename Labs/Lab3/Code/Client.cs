using System;
using System.Collections.Generic;
using Npgsql;
   using System.Linq;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BDLab3
{
    public partial class Client
    {
        public Client()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public virtual Passport Passport { get; set; }
        public virtual Telephone Telephone { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public class Client_UDI
    {
        public static void Insert(int id, int age, string name)
        {
            using(CinemaContext db = new CinemaContext())
            {
                Client newclient = new Client();

                newclient.Id = id;
                newclient.Age = age;
                newclient.Name = name;

                db.Clients.Add(newclient);
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using(CinemaContext db = new CinemaContext())
            {
                Client client = db.Clients.Find(id);
                db.Clients.Remove(client);            
                db.SaveChanges();
            }
        }

        public static void Update(int id, int age, string name)
        {
            using (CinemaContext db = new CinemaContext())
            {
                Client client = db.Clients.Find(id);
                client.Name = name;
                client.Age = age;
                db.Clients.Update(client);
                db.SaveChanges();
            }
        }


    }
}
