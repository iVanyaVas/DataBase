using System;
using System.Data.SqlTypes;
using Npgsql;
using BD2;

namespace Version
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cs = "Host=127.0.0.1;Username=postgres;Password=qwerty;Database=Cinema";
            var con = new NpgsqlConnection(cs);
            con.Open();
            Controller.Menu(con);
            con.Close();
        }

        
    }
}