using NegozioElettronica.Entities;
using NegozioElettronica.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.ADORepositories
{
    class TvADORepository : ITvDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Elettronica;" +
                                    "Integrated Security = true;";

        public void Delete(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Tv> Fetch()
        {
            List<Tv> tvs = new List<Tv>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Product where Discriminator = 'Tv'";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var qty = (int)reader["Quantity"];
                    var inches = (int)reader["Inches"];
                    var id = (int)reader["Id"];

                    Tv tv = new Tv(brand, model, qty, inches, id);

                    tvs.Add(tv);
                }
            }
            return tvs;
        }

        public Tv GetById(int? id)
        {
            Tv tv = new Tv();

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
                    var inches = (int)reader["Inches"];

                    tv = new Tv(brand, model, qty, inches, id);
                }
            }
            return tv;
        }

        public void Insert(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Product values (@brand,@model,@qty,@giga,@so,@touch,@inches,@discriminator)";
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@qty", tv.Quantity);
                command.Parameters.AddWithValue("@giga", DBNull.Value);
                command.Parameters.AddWithValue("@so", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inches", tv.Inches);
                command.Parameters.AddWithValue("@discriminator", "Tv");

                command.ExecuteNonQuery();
            }
        }

        public void Update(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Product set Brand = @brand,Model = @model, Quantity = @qty,Memory = @giga, OperatingSystem = @so,TouchScreen = @touch,Inches = @inches,Discriminator = @discriminator where Id = @id";
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@qty", tv.Quantity);
                command.Parameters.AddWithValue("@giga", DBNull.Value);
                command.Parameters.AddWithValue("@so", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inches", tv.Inches);
                command.Parameters.AddWithValue("@discriminator", "Tv");
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
