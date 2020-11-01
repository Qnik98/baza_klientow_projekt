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
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  wywoluje biblioteke sql i edytuje pozycie o danym ID
        /// </summary>
        /// <returns>
        /// metoda nic nie zwraca.
        /// </returns>
        private void Edytuj_Click(object sender, RoutedEventArgs e)    
        {
            SqlConnection sqlCon = new SqlConnection(Globals.ConnString);
            try
            {
                sqlCon.Open(); /// instrukcja która dodaje nam uaktualnione dane z "text box" do konkretnego wiersza (ID) bazy danych
                String query = "UPDATE  KLIENT_DANE set IMIE='" + this.IMIE.Text + "',NAZWISKO='" + this.NAZWISKO.Text + "',MIASTO='" + this.MIASTO.Text + "',ULICA='" + this.ULICA.Text + "',NUMER_DOMU='" + this.NUMERDOMU.Text + "',KOD_POCZTOWY='" + this.KOD_POCZTOWY.Text + "',NR_TELEFONU='" + this.NUMERDOMU.Text + "',NALEZNOSC='" + this.NALEZNOSC.Text + "' WHERE ID='" + this.ID.Text + "' ";
                SqlCommand createCommand = new SqlCommand(query, sqlCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("EDYTOWANO."); ///wyswietla okienko z napisem "edytowano"
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close(); ///ZAMYKA OKNO
        }
    }
}
