using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    class Customers
    {         // SQL Objects: Connection, command,  and reader

        SqlConnection Conn_customer = new SqlConnection("Data Source=HEHEHEHEHEHEEHE;Initial Catalog=VideoStore;Integrated Security=True");

        SqlCommand cmd_customer = new SqlCommand();

        SqlDataReader Reader_customer;

        String Query_customer;

        public IEnumerable DefaultView { get; internal set; }

        internal object CustomerDG()
        {
            throw new NotImplementedException();
        }

     
        public DataTable Listcustomer()
        {
            DataTable  dt = new DataTable();
            try
            {// fetch data from db into customers view
                cmd_customer.Connection = Conn_customer;
                Query_customer = "Select * from Coustmer";

                cmd_customer.CommandText = Query_customer;
                Conn_customer.Open();

                Reader_customer = cmd_customer.ExecuteReader();

                if (Reader_customer.HasRows)
                {
                    dt.Load(Reader_customer);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (Reader_customer != null)
                {
                    Reader_customer.Close();
                }

                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }

        }


        
        public void AddCustomer(string FirstName, string LastName, string Address, string Phone)
        {// add new customer in db
            try
            {
                cmd_customer.Parameters.Clear();
                cmd_customer.Connection = Conn_customer;

                

                Query_customer = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";

                
                cmd_customer.Parameters.AddWithValue("@FirstName", FirstName );
                cmd_customer.Parameters.AddWithValue("@LastName", LastName );
                cmd_customer.Parameters.AddWithValue("@Address", Address );
                cmd_customer.Parameters.AddWithValue("@Phone", Phone );

                cmd_customer.CommandText = Query_customer;

                //open conn
                Conn_customer.Open();

                // Execute query
                cmd_customer.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close 
                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }
        }

        public void DeleteCustomer(Int32 CustID)
        {//delete customer from db
            try
            {
                cmd_customer .Parameters.Clear();
                cmd_customer.Connection = this.Conn_customer;

                //check if customer rented a movie 
                String Strr = "";
                Strr = "select Count(*) from RentedMovies where CustIDFK= @CustID";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                cmd_customer.Parameters.Add(parameterArray[0]);

                cmd_customer.CommandText = Strr;
                Conn_customer .Open();
                // check if customer has not rented the movie 
                //it will be deleted if not 
               // othersie the customer have to return the movie 
               // then delete a movie
                int count = Convert.ToInt32(cmd_customer.ExecuteScalar());
                if (count == 0)
                {
                    Strr = "Delete from Coustmer where CustID like @CustID";
                    cmd_customer.CommandText = Strr;
                    cmd_customer.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                }
                else
                {
                    MessageBox.Show("Customer has rented the movie. First take the movie back than you can delete the customer");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.Conn_customer != null)
                {
                    this.Conn_customer.Close();
                }
            }
        }

    

    public void UpdateCustomer(int CustID, string FirstName, string LastName, string Address, string Phone)
        {//update customer record in db
            try
            {
                cmd_customer.Parameters.Clear();
                cmd_customer.Connection = Conn_customer;
                Query_customer = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                cmd_customer.Parameters.AddWithValue("@CustID", CustID);
                cmd_customer.Parameters.AddWithValue("@FirstName", FirstName);
                cmd_customer.Parameters.AddWithValue("@LastName", LastName );
                cmd_customer.Parameters.AddWithValue("@Address", Address);
                cmd_customer.Parameters.AddWithValue("@Phone", Phone);

                cmd_customer.CommandText = Query_customer;

                //open conn
                Conn_customer.Open();

                // Execute query
                cmd_customer.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // finally close conn
                if (Conn_customer != null)
                {
                    Conn_customer.Close();
                }
            }
        }

    }
}   

