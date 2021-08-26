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
    class CellPhoneADORepository : ICellPhoneDbManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                    "Initial Catalog = Elettronica;" +
                                    "Integrated Security = true;";
        public void Delete(CellPhone cellPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = "delete from Product where Id = @id";
                command.Parameters.AddWithValue("@id", cellPhone.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<CellPhone> Fetch()
        {
            List<CellPhone> cellPhones = new List<CellPhone>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;
                command.CommandText = "select * from Product where Discriminator = 'CellPhone'";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var qty = (int)reader["Quantity"];
                    var giga = (int)reader["Memory"];
                    var id = (int)reader["Id"];

                    CellPhone cellPhone = new CellPhone(brand, model, qty, giga, id);

                    cellPhones.Add(cellPhone);
                }
            }
            return cellPhones;
        }

        public CellPhone GetById(int? id)
        {
            CellPhone cellPhone = new CellPhone();

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
                    var giga = (int)reader["Memory"];

                    cellPhone = new CellPhone(brand,model,qty, giga, id);
                }
            }
            return cellPhone;
        }

        public void Insert(CellPhone cellPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Product values (@brand,@model,@qty,@giga,@so,@touch,@inches,@discriminator)";
                command.Parameters.AddWithValue("@brand", cellPhone.Brand);
                command.Parameters.AddWithValue("@model", cellPhone.Model);
                command.Parameters.AddWithValue("@qty", cellPhone.Quantity);
                command.Parameters.AddWithValue("@giga", cellPhone.Memory);
                command.Parameters.AddWithValue("@so", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", "CellPhone");

                command.ExecuteNonQuery();
            }
        }

        public void Update(CellPhone cellPhone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Product set Brand = @brand,Model = @model, Quantity = @qty,Memory = @giga, OperatingSystem = @so,TouchScreen = @touch,Inches = @inches,Discriminator = @discriminator where Id = @id";
                command.Parameters.AddWithValue("@brand", cellPhone.Brand);
                command.Parameters.AddWithValue("@model", cellPhone.Model);
                command.Parameters.AddWithValue("@qty", cellPhone.Quantity);
                command.Parameters.AddWithValue("@giga", cellPhone.Memory);
                command.Parameters.AddWithValue("@so", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@inches", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", "CellPhone");
                command.Parameters.AddWithValue("@id", cellPhone.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
