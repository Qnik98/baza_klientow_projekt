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
using System.Data;
using System.Data.SqlClient;

namespace projekt2
{
    /// <summary>
    /// Logika interakcji dla klasy Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        
        /// <summary>
        ///  wywoluje biblioteke sql i usuwa pozycie o danym ID
        /// </summary>
        /// <returns>
        /// metoda nic nie zwraca.
        /// </returns>
        private void Usun_Click(object sender, RoutedEventArgs e)   
        {
            SqlConnection sqlCon = new SqlConnection(Globals.ConnString);
            try
            {
                sqlCon.Open(); 
                String query = "DELETE FROM KLIENT_DANE WHERE ID='" + this.ID.Text + "'";
                SqlCommand createCommand = new SqlCommand(query, sqlCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("USUNIĘTO."); 
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close(); 
        }
    }
}
