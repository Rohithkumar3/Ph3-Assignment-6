using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string constr = "server=LAPTOP-CL65602K\\SQLEXPRESS;database=Assignment6;trusted_connection=true;";
        static void Main(string[] args)
        {
            DisplayProductRecords();
            InsertProduct();
            UpdateProduct();
            DeleteProduct();
        }
        static void DisplayProductRecords()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "Select * from Products"
                };
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("PID: \t\t" + reader["ProductId"]);
                    Console.WriteLine("ProductName: \t" + reader["ProductName"]);
                    Console.WriteLine("Price: \t\t" + reader["Price"]);
                    Console.WriteLine("Quantity: \t" + reader["Quantity"]);
                    Console.WriteLine("MfDate: \t" + reader["MfDate"]);
                    Console.WriteLine("ExpDate: \t" + reader["ExpDate"]);
                    Console.WriteLine("\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
        static void InsertProduct()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "insert into Products (ProductId, ProductName, Price, Quantity, MfDate, ExpDate) values (@Productid, @ProductName, @Price, @Quantity, @MfDate, @ExpDate)"
                };
                Console.WriteLine("Enter Product Id");
                cmd.Parameters.AddWithValue("@Productid", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter  Product Name");
                cmd.Parameters.AddWithValue("@ProductName", Console.ReadLine());
                Console.WriteLine("Enter Price");
                cmd.Parameters.AddWithValue("@Price", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product Quantity");
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(Console.ReadLine()));
                Console.WriteLine("Enter Product MfDate");
                cmd.Parameters.AddWithValue("@MfDate",Console.ReadLine());
                Console.WriteLine("Enter Product ExpDate");
                cmd.Parameters.AddWithValue("@ExpDate", Console.ReadLine());
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Record Inserted Successfully!!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.WriteLine("End of Program\n");
                Console.ReadKey();
            }
        }
        static void UpdateProduct()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "update Products set Quantity=@Quantity where productid=@Productid"
                };
                Console.WriteLine("Enter Product Id to update the Record");
                int Pid = int.Parse(Console.ReadLine());
                cmd.Parameters.AddWithValue("@Productid", Pid);
                Console.WriteLine("Enter Product Quantity");
                cmd.Parameters.AddWithValue("@Quantity", int.Parse(Console.ReadLine()));


                con.Open();
                int noe = cmd.ExecuteNonQuery();
                if (noe > 0)
                    Console.WriteLine($"Record Updated for ProductId {Pid} was Successful !!!");
            }
            catch (Exception ex)

            { Console.WriteLine("Error!!!" + ex.Message); }

            finally
            {
                con.Close();
                Console.WriteLine("End of Program\n");
                Console.ReadKey();
            }

        }
        static void DeleteProduct()
        {
            try
            {
                con = new SqlConnection(constr);
                cmd = new SqlCommand
                {
                    Connection = con,
                    CommandText = "delete from Products where ProductId=@Productid"
                };
                Console.WriteLine("Enter Product Id to delete");
                cmd.Parameters.AddWithValue("@Productid", int.Parse(Console.ReadLine()));

                con.Open();
                int noe = cmd.ExecuteNonQuery();
                if (noe > 0)
                {
                    Console.WriteLine("Record Deleted Successfully!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error!!!" + ex.Message);
            }
            finally
            {
                con.Close();
                Console.WriteLine("End of Program\n");
                Console.ReadKey();
            }

        }
    }
}

