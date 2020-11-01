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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace projekt2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        /// metoda nic nie zwracaie, wywoluje biblioteke sql
        private void Button_Click(object sender, RoutedEventArgs e)    
        {
            SqlConnection sqlCon = new SqlConnection(Globals.ConnString);
            //@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Programowanie_projekt; Integrated Security=True;");


            try                                                                 /// instrukcja dzięki której mamy dostęp do bazy danych 
                    {
                sqlCon.Open();
                String query = "SELECT * FROM KLIENT_DANE "; 
                SqlCommand createCommand = new SqlCommand(query, sqlCon);
                createCommand.ExecuteNonQuery();
                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("KLIENT_DANE");
                dataAdp.Fill(dt);
                        Pole.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt); 
                sqlCon.Close();
            }
                    catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 wnd = new Window1(); /// WYSWIETLA OKNO 
            wnd.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window2 wnd = new Window2(); /// WYSWIETLA OKNO 
            wnd.Show();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window3 wnd = new Window3(); /// WYSWIETLA OKNO 
            wnd.Show();
            
            
        }
    }
}
