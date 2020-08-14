using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    public class Authentication
    {
        SqlConnection conn = new SqlConnection("Data Source=HEHEHEHEHEHEEHE;Initial Catalog=VideoStore;Integrated Security=True");

        SqlCommand cmd = new SqlCommand();

        SqlDataReader reader;

        String query;



        public bool Login_method(string username, string password)
        { //Authenticate User
            try
            {
                cmd.Connection = conn;

                query = "Select username, password from userdata where UserName =  @UserName  and Password =  @password ";

             
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@password", password);

                cmd.CommandText = query;
                conn.Open();

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void Regis_method(string username, string password)
        { // this method is used to insert user details in the user table
            try
            {
                cmd.Parameters.Clear();
                cmd.Connection = conn;

                query = "Insert into userdata (UserName, Password) Values(@user, @pass)";
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@pass", password);

                cmd.CommandText = query;
                //connection opened
                conn.Open();

                // get data stream
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // show error Message
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                // close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        // property to test db connection
        public bool TestConnection
        { get {
                if(conn.State==System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                return true;
            }
        }

    }
}
