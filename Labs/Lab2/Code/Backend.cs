using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BD2
{
   public class Backend
   {
        public static void ExecuteQuery(NpgsqlCommand _cmd)
        {
            try
            {
                _cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
               
            }
        }
       static public void ReaderClient(NpgsqlConnection con)
        {
            Console.WriteLine("Client");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Client\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t {rdr.GetName(2),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetInt32(1),-3}\t {rdr.GetString(2),10}");
            }
            rdr.Close();
        }
        static public void ReaderFilm(NpgsqlConnection con)
        {
            Console.WriteLine("Film");
            Console.WriteLine("--------------------------------------------------------");
            var sql = $"select * from \"Film\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-10}\t {rdr.GetName(1),-20}\t {rdr.GetName(2),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-10} \t {rdr.GetString(1),-20} \t {rdr.GetString(2),15}");
            }
            rdr.Close();
        }

        static public void ReaderPassport(NpgsqlConnection con)
        {
            Console.WriteLine("Passport");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Passport\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} ");
            }
            rdr.Close();
        }

        static public void ReaderRoom(NpgsqlConnection con)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Room");
            Console.WriteLine("----------------------------");
            var sql = $"select * from \"Room\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-7}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-7} ");
            }
            rdr.Close();
        }

        static public void ReaderSeatRow(NpgsqlConnection con)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Seat/Row");
            Console.WriteLine("--------------------------------------");
            var sql = $"select * from \"Seat/Row\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-7} \t {rdr.GetName(2),-15}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetInt32(1),-7} \t{rdr.GetInt32(2),-15} ");
            }
            rdr.Close();
        }

        static public void ReaderSession(NpgsqlConnection con)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Session");
            Console.WriteLine("------------------------------------------------------------------");
            var sql = $"select * from \"Session\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-7}\t {rdr.GetName(2),-14} \t {rdr.GetName(3),-21}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetInt32(1),-7} \t {rdr.GetInt32(2),-14} \t {rdr.GetDate(3),-21} ");
            }
            rdr.Close();
        }
        static public void ReaderTelephone(NpgsqlConnection con)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Telephone");
            Console.WriteLine("------------------------------------------------------------------");
            var sql = $"select * from \"Telephone\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-7}\t {rdr.GetName(2),-14}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetInt32(1),-7} \t {rdr.GetInt32(2),-14}");
            }
            rdr.Close();
        }
        static public void ReaderTicket(NpgsqlConnection con)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Ticket");
            Console.WriteLine("------------------------------------------------------------------");
            var sql = $"select * from \"Ticket\"";
            var cmd = new NpgsqlCommand(sql, con);
            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-7}\t {rdr.GetName(2),-14} \t {rdr.GetName(3),-21}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t\t {rdr.GetInt32(1),-7} \t {rdr.GetInt32(2),-14} \t {rdr.GetInt32(3),-21} ");
            }
            rdr.Close();
        }

        static public void addValue(NpgsqlCommand _cmd,string name, object value)
        {
            _cmd.Parameters.AddWithValue("name", value); //GOOD CODE ORGANIZATION
        }
        static public void Execute(NpgsqlCommand _cmd)
        {
            ExecuteQuery(_cmd);
        }
        static public void AddClient(NpgsqlConnection con, int id, int age, string name)//add client and passport
        {
            var sql = "insert into \"Client\"(id,age,name) VALUES(@id, @age, @name)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("age", age);
            cmd.Parameters.AddWithValue("name", name);
            cmd.Prepare();

            Execute(cmd);
            sql = "insert into \"Passport\"(id) VALUES(@id)";
            cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Prepare();

            Execute(cmd);
            Console.WriteLine("row inserted");
        }
        static public void AddTelephone(NpgsqlConnection con, int id, int client_id, int number)//add telephone
        {
            var sql = "insert into \"Telephone\"(id,client_id,number) VALUES(@id, @client_id, @number)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("client_id", client_id);
            cmd.Parameters.AddWithValue("number", number);
            cmd.Prepare();

            Execute(cmd);
        }
        static public void AddRoom(NpgsqlConnection con, int room_id, string room_colour)//add room
        {
            var sql = "insert into \"Room\"(room_id,room_colour) VALUES(@room_id, @room_colour)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("room_id", room_id);
            cmd.Parameters.AddWithValue("room_colour", room_colour);
            cmd.Prepare();

            Execute(cmd);

        }

        static public void AddFilm(NpgsqlConnection con, int film_id, string film_name, string duration)
        {
            var sql = "insert into \"Film\"(film_id,film_name,duration) VALUES(@film_id, @film_name,@duration)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("film_id", film_id);
            cmd.Parameters.AddWithValue("film_name", film_name);
            cmd.Parameters.AddWithValue("duration", duration);
            cmd.Prepare();

            Execute(cmd);
        }

        static public void AddSession(NpgsqlConnection con, int session_id, int film_id, int room_id, DateTime date)
        {
            var sql = "insert into \"Session\"(id,st_film_id,st_room_id,date) VALUES(@id,@st_film_id, @st_room_id,@date)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("id", session_id);
            cmd.Parameters.AddWithValue("st_film_id",film_id);
            cmd.Parameters.AddWithValue("st_room_id", room_id);
            cmd.Parameters.AddWithValue("date", date);
            cmd.Prepare();

            Execute(cmd);
        }

        static public void AddTicket(NpgsqlConnection con, int ticket_id, int place_id, int client_id, int session_id)
        {
            var sql = "insert into \"Ticket\"(ticket_id,place_id,client_id,session_id) VALUES(@ticket_id,@place_id, @client_id,@session_id)";
            var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("ticket_id", ticket_id);
            cmd.Parameters.AddWithValue("place_id", place_id);
            cmd.Parameters.AddWithValue("client_id", client_id);
            cmd.Parameters.AddWithValue("session_id", session_id);
            cmd.Prepare();

            Execute(cmd);
        }
        static public void DeleteClient(NpgsqlConnection con, int id)//using on delete cascade
        {
            var sql = $"DELETE FROM \"Client\" WHERE id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        /* static void DeleteTicket(NpgsqlConnection con, int id)//delete ticket
          {
              var sql = $"DELETE FROM \"Ticket\" WHERE ticket_id=" + id;
              var cmd = new NpgsqlCommand(sql, con);
              cmd.ExecuteNonQuery();
          }*/

            static public void DeleteFilm(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"Film\" WHERE film_id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void DeleteRoom(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"Room\" WHERE room_id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        static public void DeleteSession(NpgsqlConnection con, int id)
        {
            var sql = $"DELETE FROM \"Session\" WHERE id=" + id;
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void UpdateClient(NpgsqlConnection con, int id, int age, string name)
        {
            var sql = $"UPDATE \"Client\" SET age={age}, name ='{name}' WHERE id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        static public void UpdateFilm(NpgsqlConnection con, int id, string film_name)
        {
            var sql = $"UPDATE \"Film\" SET film_name ='{film_name}' WHERE film_id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }
        static public void UpdateRoom(NpgsqlConnection con, int room_id, string room_colour)
        {
            var sql = $"UPDATE \"Room\" SET room_colour ='{room_colour}' WHERE room_id = {room_id} ";
            var cmd = new NpgsqlCommand(sql, con);
             Execute(cmd);
        }
        static public void UpdateTelephone(NpgsqlConnection con, int id, int number)
        {
            var sql = $"UPDATE \"Telephone\" SET number ='{number}' WHERE id = {id} ";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);
        }

        static public void RandomFilm(NpgsqlConnection con)
        {
            Console.WriteLine("Num of randomized rows: ");
            int num = Convert.ToInt32(Console.ReadLine());
            //var rand_char = "chr(trunc(65+random()*25)::int)";
            string[] masstr = new string[num];
            for (int j = 0; j < num; j++) masstr[j] += " chr(trunc(65+random()*25)::int)";
            string rand_char = String.Join("||",masstr);       
            for(int i=0; i<num;i++)
            {
                var sql = $"insert into \"Film\"(film_id,film_name,duration) VALUES((random()*10000)::int , {rand_char} ,{rand_char})";
                var cmd = new NpgsqlCommand(sql, con);
                Execute(cmd);
            }
           
        }

        static public void DynamicSearch1(NpgsqlConnection con)
        {
            Console.WriteLine("Поиск кинозала по цвету  и по фильмам которые будут в нём показываться");
            string room_colour, film_name;
            Console.WriteLine("Цвет комнаты: ");
            room_colour = Console.ReadLine();
            Console.WriteLine("Название фильма: ");
            film_name = Console.ReadLine();

            var sql = $"select room_id,room_colour,film_id,duration from \"Room\" " +
                $"inner join \"Session\" on \"Room\".room_id =\"Session\".st_room_id " +
                $"inner join \"Film\" on \"Session\".st_film_id = \"Film\".film_id  "+
                $"   WHERE room_colour = '{room_colour}' and film_name = '{film_name}'";
            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t \t{rdr.GetName(2),10}\t {rdr.GetName(3),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t\t {rdr.GetInt32(2),10} \t\t {rdr.GetString(3),10}");
            }
            rdr.Close();
        }
        static public void DynamicSearch2(NpgsqlConnection con)
        {
            Console.WriteLine("Поиск кинозала, где будет сидеть клиент по идентификатором его паспорта та цветом комнаты");
            int pass_id;
            string room_colour;
            Console.WriteLine("Идентификатор паспорта: ");
            pass_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Цвет  комнаты: ");
            room_colour = Console.ReadLine();

            var sql =$"select \"Room\".room_id,\"Room\".room_colour, \"Passport\".id, \"Client\".name "+
            "from \"Passport\" "+ 
            "inner join \"Client\" on \"Passport\".id = \"Client\".id " +
            "inner join \"Ticket\" on \"Ticket\".client_id = \"Client\".id "+
            "inner join \"Session\" on \"Ticket\".session_id = \"Session\".id " +
            "inner join \"Room\" on \"Session\".st_room_id = \"Room\".room_id " +
            $"where \"Passport\".id = {pass_id} and \"Room\".room_colour = '{room_colour}'";

            var cmd = new NpgsqlCommand(sql, con);
            Execute(cmd);

            NpgsqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine($"{rdr.GetName(0),-4}\t {rdr.GetName(1),-4}\t {rdr.GetName(2),10}\t {rdr.GetName(3),10}");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr.GetInt32(0),-4} \t {rdr.GetString(1),-3}\t\t {rdr.GetInt32(2),10} \t {rdr.GetString(3),10}");
            }
            rdr.Close();

        }

    }
}
