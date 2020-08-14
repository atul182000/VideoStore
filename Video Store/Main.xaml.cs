using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Video_Store;

namespace Video_Store
{
   // main ui logic
    public partial class Main : Window
    {
        Customers Obj_Customer = new Customers() ;
        Videos Obj_Movies = new Videos();
        MoviesRented Obj_Rented = new MoviesRented();
        

        public int CustID;
        public int MovieID;

        public Main()
        {
            InitializeComponent();
            dateissue_txt.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }
      
        private void clearTB()
        {
            Movieid_txt.Text = "";
            Customerid_txt.Text = "";
            Title_txt.Text = "";
            Plot_txt.Text = "";
            Genre_txt.Text = "";
            Year_tx.Text = "";
            Rating_txt.Text = "";
            Movieid_txt.Text = "";
            copies_txt.Text = "";
            First_txt.Text = "";
            Last_txt.Text = "";
            Address_txt.Text = "";
            Phone_txt.Text = "";
        }
        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (First_txt.Text != "" && Last_txt.Text != "" && Address_txt.Text != "" && Phone_txt.Text != "")
            {
               string FirstName = First_txt.Text;
               string LastName = Last_txt.Text;
               string Address = Address_txt.Text;
               string Phone = Phone_txt.Text;
               int CustID = Convert.ToInt32(Customerid_txt.Text);
               Obj_Customer.UpdateCustomer(CustID , FirstName, LastName, Address, Phone);//this code passes the variable to UpdateCustomer Method in Register Class
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                clearTB();
            }
            else
            {
                
                    MessageBox.Show("Please Fill all the Details");
                
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            
            if (First_txt.Text != "" && Last_txt.Text != "" && Address_txt.Text != "" && Phone_txt.Text != "")
            {
                Obj_Customer.AddCustomer( First_txt.Text, Last_txt.Text, Address_txt.Text, Phone_txt.Text);//this code passes the variable to Addcustomer method in Customer Class

                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                clearTB();

            }
            else
            {

                MessageBox.Show("Please Fill all the Details Of Customer Form");

            }
        }

        private void Deletecustomer_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (Customerid_txt.Text != "")
            { 
            int CustID = Convert.ToInt32(Customerid_txt.Text);
            MessageBoxResult dialogResult = MessageBox.Show("Are Your Sure You want To Delete This Customer ?",
                   "Customer", MessageBoxButton.YesNo);
            if (dialogResult.ToString() == "Yes")
            {
                Obj_Customer.DeleteCustomer(CustID);//this code passes the variable to DeleteCustomer method in Customer Class

                    MessageBox.Show("Customer Deleted");
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                clearTB();
               
            }
          }
            else
            {
                MessageBox.Show("First select The Customer Your Wish To Delete ");
            }
    }

        private void Customer_load(object sender, RoutedEventArgs e)
        {
            Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
        }

        private void SelectBookRow_Edit(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)Customer_data.SelectedItems[0];//this code is Used to transfer values from the data grid to textbox
                Customerid_txt.Text = Convert.ToString(row["CustID"]);
                First_txt.Text = Convert.ToString(row["FirstName"]);
                Last_txt.Text = Convert.ToString(row["Lastname"]);
                Address_txt.Text = Convert.ToString(row["Address"]);
                Phone_txt.Text = Convert.ToString(row["Phone"]);

                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;

            }
            catch(Exception ex)
            {
                MessageBox.Show("No Row available to select"+ex.Source);
            }
        
        }

        private void AddMovies_Click(object sender, RoutedEventArgs e)
        {
            
            if (Rating_txt.Text != "" && Title_txt.Text != "" && Year_tx.Text != "" &&  Plot_txt.Text != "" && Genre_txt.Text != "" && copies_txt.Text != "")
            {
                int Mov_year = Convert.ToInt32(Year_tx.Text);//this code is used to put the value of year text box to varibles so we can calculate the rent
                int copies = Convert.ToInt32(copies_txt.Text);
                string rent;
                if (2018 - Mov_year > 5)//this if statement checks if the movie is older that five years
                {
                    rent = "2";//if the move is older that 5 year then rent is 2
                        
                }
                else
                {
                    rent = "5";//else rent is 5 
                }

                Obj_Movies.AddMovies(Rating_txt.Text, Title_txt.Text, Year_tx.Text, rent, Plot_txt.Text, Genre_txt.Text, copies);//this code passes the variable to AddMovies in movie Class

                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                clearTB();
            }
            else
            {

                MessageBox.Show("Please Fill all the Details Of Movie Form");

            }
        }

        private void UpdateMovies_Click(object sender, RoutedEventArgs e)
        {
            if (Rating_txt.Text != "" && Title_txt.Text != "" && Year_tx.Text != "" && Plot_txt.Text != "" &&
                Genre_txt.Text != "" && copies_txt.Text != "")
            {
                int MovieID = Convert.ToInt32(Movieid_txt.Text);
                int copies = Convert.ToInt32(copies_txt.Text);


                string Title = Title_txt.Text;
                string Rating = Rating_txt.Text;
                string Plot = Plot_txt.Text;
                string Genre = Genre_txt.Text;
                int Year = Convert.ToInt32(Year_tx.Text);
                Obj_Movies.UpdateMovie(MovieID, Rating, Title, Year, Plot, Genre, copies);//this code passes the variable to Updatemovie method in Register Class

                MessageBox.Show("Video Updated");
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                clearTB();
            }
            else
            {

                MessageBox.Show("Please Fill all the Details Of Movie Form");

            }
        }

        private void DeleteMovie(object sender, RoutedEventArgs e)
        {

            if (Movieid_txt.Text != "")
            {

                


                MessageBoxResult dialogResult = MessageBox.Show("Are Your Sure You want To Delete This Movie ?",
                    "movie", MessageBoxButton.YesNo);
                if (dialogResult.ToString() == "Yes")
                {
                     int movie = Convert.ToInt32(Movieid_txt.Text);
                    Obj_Movies.DeleteMovie(movie);//this code passes the variable to DeleteMovie in Movie Class

                    Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                    Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                    Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                    clearTB();
                }
            }
            else
            {
                MessageBox.Show("Select The Customer You Wish To Delete First");
            }
        }

        private void Video_loaded(object sender, RoutedEventArgs e)
        {
           Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
        }

        private void SelectMovieRow_Edit(object sender, MouseButtonEventArgs e)
        {// below code is used to take the values od datagrid and put it in the textbox
            try
            {
                DataRowView row = (DataRowView)Video_data.SelectedItems[0];
                Title_txt.Text = Convert.ToString(row["Title"]);
                Plot_txt.Text = Convert.ToString(row["Plot"]);
                Genre_txt.Text = Convert.ToString(row["Genre"]);
                Year_tx.Text = Convert.ToString(row["Year"]);
                Rating_txt.Text = Convert.ToString(row["Rating"]);
                Movieid_txt.Text = Convert.ToString(row["MovieID"]);
                copies_txt.Text = Convert.ToString(row["copies"]);

                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No row available to select"+ex.Source);
            }
           
        }

       

        

        private void Returned_Click(object sender, RoutedEventArgs e)
        {
            if (Rmid_txt.Text != "")
            {
                int RMID = Convert.ToInt32(Rmid_txt.Text);
                int MovieID = Convert.ToInt32(Movieid_txt.Text);



                Obj_Rented.UpdateRented(RMID, MovieID, Convert.ToDateTime(dateissue_txt.Text), DateTime.Now);//this code passes the variable to UpdateRented Method in Rented Class

                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                clearTB();
            }
            else
            {
                MessageBox.Show("Select The Movie You Wish To Return First by Double Clicking ");

            }

        }

      

        private void Issue_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Movieid_txt.Text != "" && Customerid_txt.Text != "" && dateissue_txt.Text != "")
            {
                if (copies_txt.Text != "0")

                {

                    int MovieID = Convert.ToInt32(Movieid_txt.Text);
                    int Customerid = Convert.ToInt32(Customerid_txt.Text);
                    dateissue_txt.Text = DateTime.Today.ToString("dd-MM-yyyy");
                    int copies = Convert.ToInt32(copies_txt.Text);
                    int isout = 1;


                    //this code passes the variable to Addrented Method in rented Class
                    Obj_Rented.AddRented(MovieID, Customerid, DateTime.Now, copies, isout);
                    Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                    Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                    Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                    Movieid_txt.Text = "";
                    Customerid_txt.Text = "";
                    Title_txt.Text = "";
                    Plot_txt.Text = "";
                    Genre_txt.Text = "";
                    Year_tx.Text = "";
                    Rating_txt.Text = "";
                    Movieid_txt.Text = "";
                    copies_txt.Text = "";
                    First_txt.Text = "";
                    Last_txt.Text = "";
                    Address_txt.Text = "";
                    Phone_txt.Text = "";

                }


                else
                {
                    MessageBox.Show("No more copies Left To Rent");
                }
            }
            else
            {
                MessageBox.Show("First Select Movie and Customer by double clicking on them");
            }
        }

        

        private void SlectRented(object sender, MouseButtonEventArgs e)
        { 
            try
            {
                //below code is used to put data from DataGrid in Textbox
                DataRowView row = (DataRowView)Rental_data.SelectedItems[0];
                Movieid_txt.Text = Convert.ToString(row["MovieIDFK"]);
                Customerid_txt.Text = Convert.ToString(row["CustIDFK"]);
                Rmid_txt.Text = Convert.ToString(row["RMID"]);
                dateissue_txt.Text = Convert.ToString(row["DateRented"]);
                dateretuned_txt.Text = DateTime.Now.ToString("dd-MM-yyyy");



                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No Rows Available"+ ex.Source);
            }
           
        }

        private void video_load(object sender, RoutedEventArgs e)
        {
           
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;

        }

        private void rented(object sender, RoutedEventArgs e)
        {
           
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if(Rmid_txt.Text != "")
            { 
                int RMID = Convert.ToInt32(Rmid_txt.Text);
                dateretuned_txt.Text = DateTime.Today.ToString("dd-MM-yyyy");
                int MovieID = Convert.ToInt32(Movieid_txt.Text);


                //this code passes the variable to UpdateMovie in Rented Class
                Obj_Rented.UpdateRented(RMID, MovieID, Convert.ToDateTime(dateissue_txt.Text), DateTime.Now);

                Video_data.ItemsSource = Obj_Movies.ListMovies().DefaultView;
                Rental_data.ItemsSource = Obj_Rented.ListRented().DefaultView;
                Customer_data.ItemsSource = Obj_Customer.Listcustomer().DefaultView;
                Movieid_txt.Text = "";
                Customerid_txt.Text = "";
                Title_txt.Text = "";
                Plot_txt.Text = "";
                Genre_txt.Text = "";
                Year_tx.Text = "";
                Rating_txt.Text = "";
                Movieid_txt.Text = "";
                copies_txt.Text = "";
                First_txt.Text = "";
                Last_txt.Text = "";
                Address_txt.Text = "";
                Phone_txt.Text = "";
            }
            else
            {
                MessageBox.Show("First Select Movie From The Rented table by double clicking on them");
            }

        }

        private void Topcust_btn_Click(object sender, RoutedEventArgs e)
        {
            Obj_Rented.TopCustomer();//this code passes the variable to TopCustomer Method in Rented Class
        }

        private void Topmovie_Click(object sender, RoutedEventArgs e)
        {   //this code passes the variable to TopMovie Method in Rented Class
            Obj_Rented.TopMovie();
        }

       
    }
}
