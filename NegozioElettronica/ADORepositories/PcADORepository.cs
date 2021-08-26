using NegozioElettronica.Entities;
using NegozioElettronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NegozioElettronica.Entities.Pc;

namespace NegozioElettronica.ADORepositories
{
    class PcADORepository : IPcDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Elettronica;" +
                                    "Integrated Security = true;";
        public void Delete(Pc pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", pc.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Pc> Fetch()
        {
            List<Pc> pcs = new List<Pc>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Product where Discriminator = 'Pc'";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var qty = (int)reader["Quantity"];
                    var so = (EnumOperatingSystem)reader["OperatingSystem"];
                    var touch = (bool)reader["Touchscreen"];
                    var id = (int)reader["Id"];

                    Pc pc = new Pc(brand, model, qty, so, touch, id);

                    pcs.Add(pc);
                }
            }
            return pcs;
        }

        public Pc GetById(int? id)
        {
            Pc pc = new Pc();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Product where Id=@id";
                command.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var qty = (int)reader["Quantity"];
                    var so = (EnumOperatingSystem)reader["OperatingSystem"];
                    var touch = (bool)reader["Touchscreen"];

                    pc = new Pc(brand, model, qty, so, touch, id);
                }
            }
            return pc;
        }

        public void Insert(Pc pc)
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "insert into Product values (@brand,@model,@qty,@giga,@so,@touch,@inches,@discriminator)";
                    command.Parameters.AddWithValue("@brand", pc.Brand);
                    command.Parameters.AddWithValue("@model", pc.Model);
                    command.Parameters.AddWithValue("@qty", pc.Quantity);
                    command.Parameters.AddWithValue("@giga", DBNull.Value);
                    command.Parameters.AddWithValue("@so",(int)pc.OperatingSystem);
                    command.Parameters.AddWithValue("@touch", pc.TouchScreen);
                    command.Parameters.AddWithValue("@inches", DBNull.Value);
                    command.Parameters.AddWithValue("@discriminator", "Pc");

                    command.ExecuteNonQuery();
                }
            }

        public void Update(Pc pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Product set Brand = @brand,Model = @model, Quantity = @qty,Memory = @giga, OperatingSystem = @so,TouchScreen = @touch,Inches = @inches,Discriminator = @discriminator where Id = @id";
                command.Parameters.AddWithValue("@brand", pc.Brand);
                command.Parameters.AddWithValue("@model", pc.Model);
                command.Parameters.AddWithValue("@qty", pc.Quantity);
                command.Parameters.AddWithValue("@giga", DBNull.Value);
                command.Parameters.AddWithValue("@so", (int)pc.OperatingSystem);
                command.Parameters.AddWithValue("@touch", pc.TouchScreen);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", "Pc");
                command.Parameters.AddWithValue("@id", pc.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
