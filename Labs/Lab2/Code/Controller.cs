using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace BD2
{
    public class Controller
    {
        static public void Menu(NpgsqlConnection con)
        {
          
            while(true)
            {
                Console.Clear();
                Console.WriteLine("\tMain menu");
                Console.WriteLine("0 => Show one table\n1 => Insert data\n2 => Delete  \n3 => Update data\n4 => Search text \n5 => Randomize data in Film \n6 => Exit");
                int param = Convert.ToInt32(Console.ReadLine());
                switch (param)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine(" 1 => Client \n 2 => Film \n 3 => Room \n 4 => Passport \n 5 => Session \n 6 => Telephone \n 7 => Ticket\n");
                        int show = Convert.ToInt32(Console.ReadLine());
                        switch(show)
                        {
                            case 0:
                                break;
                            case 1:
                                Backend.ReaderClient(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                Backend.ReaderFilm(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 3:
                                Backend.ReaderRoom(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                Backend.ReaderPassport(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                Backend.ReaderSession(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 6:
                                Backend.ReaderTelephone(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 7:
                                Backend.ReaderTicket(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 1:
                         Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine("1 => Client \n 2 => Film \n 3 => Room \n 4 => Passport \n 5 => Session \n 6 => Telephone \n 7 => Ticket\n");
                        int insert = Convert.ToInt32(Console.ReadLine());
                        switch(insert)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Age: ");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string name = Console.ReadLine();
                                Backend.AddClient(con,id,age,name);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Film Id: ");
                                int film_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string film_name = Console.ReadLine();
                                Console.WriteLine("Duration: ");
                                string film_duration = Console.ReadLine();
                                Backend.AddFilm(con,film_id,film_name,film_duration);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 3:
                                //Room
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Room Id: ");
                                int room_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Room colour: ");
                                string room_colour = Console.ReadLine();
                                Backend.AddRoom(con, room_id, room_colour);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                //Passport
                                Console.WriteLine("To add Passport, insert new client");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 5:
                                //Session
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Session id: ");
                                int ses_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Film id:");
                                int st_film_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Room id: ");
                                int st_room_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Date: ");
                                DateTime date = Convert.ToDateTime(Console.ReadLine());
                                Backend.AddSession(con, ses_id, st_film_id,st_room_id,date);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 6:
                                //Telephone
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Telephone id");
                                int teleph_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Client id: ");
                                int cl_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Number: ");
                                int number = Convert.ToInt32(Console.ReadLine());
                                Backend.AddTelephone(con, teleph_id, cl_id, number);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 7:
                                //Ticket
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Ticket ID: ");
                                int ticket_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Place id: ");
                                int place_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Client id: ");
                                int client_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Session id: ");
                                int session_id = Convert.ToInt32(Console.ReadLine());
                                Backend.AddTicket(con, ticket_id, place_id, client_id, session_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine("1 => Client \n 2 => Film \n 3 => Room \n 4 => Session \n 5 => Passport  \n 6 => Telephone \n 7 => Ticket \n");
                        int delete = Convert.ToInt32(Console.ReadLine());
                        switch(delete)
                        {
                            case 1:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Backend.DeleteClient(con, id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Film Id: ");
                                int film_id = Convert.ToInt32(Console.ReadLine());
                                Backend.DeleteFilm(con, film_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 3:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Room Id: ");
                                int room_id = Convert.ToInt32(Console.ReadLine());
                                Backend.DeleteRoom(con, room_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4:
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Session Id: ");
                                int session_id = Convert.ToInt32(Console.ReadLine());
                                Backend.DeleteSession(con, session_id);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Choose the Table name");
                        Console.WriteLine("1 => Client \n 2 => Film \n 3 => Room \n 4 =>Passport \n 5 => Session \n 6 => Telephone \n 7 => Ticket\n");
                        int update = Convert.ToInt32(Console.ReadLine());
                        switch(update)
                        {
                            case 1://Client
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Id: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Age: ");
                                int age = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string name = Console.ReadLine();
                                Backend.UpdateClient(con,id,age,name);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2://Film
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Film Id: ");
                                int film_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Name: ");
                                string film_name = Console.ReadLine();
                                Backend.UpdateFilm(con,film_id,film_name);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 3://Room
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Room Id: ");
                                int room_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Room colour: ");
                                string room_colour = Console.ReadLine();
                                Backend.UpdateRoom(con, room_id, room_colour);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 4://Passport
                                break;
                            case 5://Session
                                break;
                            case 6://Telephone
                                Console.WriteLine("Input data: ");
                                Console.WriteLine("Telephone id");
                                int teleph_id = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Number: ");
                                int number = Convert.ToInt32(Console.ReadLine());
                                Backend.UpdateTelephone(con, teleph_id, number);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 7://Ticket
                                break;
                            default:
                                break;

                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Choose search");
                        Console.WriteLine("1 => Поиск кинозала по цвету  и по фильмам которые будут в нём показываться  \n 2 => Поиск кинозала, где будет сидеть клиент по идентификатором его паспорта та цветом комнаты");
                        int search = Convert.ToInt32(Console.ReadLine());
                        switch(search)
                        {
                            case 1:
                                Backend.DynamicSearch1(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            case 2:
                                Backend.DynamicSearch2(con);
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                            default:
                                Console.WriteLine("Incorrect input");
                                Console.WriteLine("To proceed press Enter");
                                Console.ReadKey(true);
                                break;
                                
                        }
                        break;
                    case 5:
                        Backend.RandomFilm(con);
                        Console.WriteLine("To proceed press Enter");
                        Console.ReadKey(true);

                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
           

        }
    }
}
