using System;
using System.Data.SqlClient;
using NUnit.Framework;
using projekt2;

namespace projekt2UnitTests
{
    
    [TestFixture]
    public class UnitTests
    {
        [TestCase, Category("Bazowe")]
        public void Button_Click()
        {
            bool res = false;
            try
            {
                SqlConnection conn = new SqlConnection(Globals.ConnString);
                conn.Open();
                res = true;
            }
            catch (Exception ex)
            {
                res = false;
            }
            Assert.IsTrue(res);
            
        }
    
       

        [TestCase, Category("Window 3")]
        public void Usun_Click()
        {
            bool res = false;
            try
            {
                SqlConnection conn = new SqlConnection(Globals.ConnString);
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand createCommand = new SqlCommand("SELECT COUNT(0) FROM KLIENT_DANE", conn);
                    int maxNr = (int)createCommand.ExecuteScalar() - 1;

                    String query = $"DELETE FROM KLIENT_DANE WHERE ID = '" + maxNr + "'";
                    createCommand.CommandText = query;
                    int rows = createCommand.ExecuteNonQuery();

                    res = rows > 0;
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                res = false;
            }
            Assert.IsTrue(res);
        }
    }
}
