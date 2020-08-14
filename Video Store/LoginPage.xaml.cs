using System;
using System.Collections.Generic;
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

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        Authentication Obj_Login = new Authentication();
        public LoginPage()
        { 
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

      
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            (new Window1()).Show();
            this.Close();
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            if (Obj_Login.Login_method(Username_txtbox.Text, Password_txtbox.Text))//this code passes the variable to Login_method in Login Class 

            {
                MessageBox.Show("Login Successful");
                (new Main()).Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Invalid User Name or Password");
                (new LoginPage()).Show();
                this.Close();
            }

        }
    }
}
