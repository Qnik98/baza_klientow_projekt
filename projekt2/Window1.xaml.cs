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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window 
    {
        public Window1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  wywoluje biblioteke sql i dodaje pozycie o danym ID
        /// </summary>
        /// <returns>
        /// metoda nic nie zwraca.
        /// </returns>
        private void Dodaj_Click(object sender, RoutedEventArgs e)  
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\.; Initial Catalog=Programowanie_projekt; Integrated Security=True;");
            try
            {
                sqlCon.Open();  /// instrukcja która dodaje nam wartości z "textbox" do bazy danych
                String query = "INSERT INTO KLIENT_DANE (ID,IMIE,NAZWISKO,MIASTO,ULICA,NUMER_DOMU,KOD_POCZTOWY,NR_TELEFONU,NALEZNOSC) values('" + this.ID.Text + "','" + this.IMIE.Text + "','" + this.NAZWISKO.Text + "','" + this.MIASTO.Text + "','" + this.ULICA.Text + "','" + this.NUMERDOMU.Text + "','" + this.KOD_POCZTOWY.Text + "','" + this.TELEFON.Text + "','" + this.NALEZNOSC.Text + "')";
                SqlCommand createCommand = new SqlCommand(query, sqlCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("DODANO."); ///wyswietla okienko z napisem "DODANO"
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
