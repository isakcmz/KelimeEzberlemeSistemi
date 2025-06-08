using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KelimeEzberlemeSistemi
{
    public static class VeriTabani
    {
        private static string baglantiCumlesi = "Data Source=LAPTOP-SPG6ILB4\\SQLEXPRESS;Initial Catalog=KelimeEzberlemeDB;Integrated Security=True";
        public static SqlConnection Baglanti => new SqlConnection(baglantiCumlesi);
    }
}
