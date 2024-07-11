using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeriTabanı1;

namespace VeriTablosuDenemeler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //## VERİNİN ÇEKİLİP TABLOYA EKLENMESİ
            string baglantıS = @"Data Source=.\SQLEXPRESS;Initial Catalog=odevler;Integrated Security=True;";
            string[] columnNames = GetColumnNames(baglantıS, "ogrenciler");  // sütün isimleri alınır
            VeriTablo tablo = new VeriTablo(columnNames);  // tablo yaratılır
            List<string[]> SQLVeriListesi = GetRows(baglantıS, "ogrenciler");  // veri çekilir
            foreach (string[] vektor in SQLVeriListesi)
            {
                tablo.SatirEkle(vektor);
            }


            Console.WriteLine(tablo[0]);  // bir kayıta (satıra erişim)
            Console.WriteLine(tablo[0, 2]);  // alan indexi ile string kullanarak hücreye erişim

            Console.WriteLine(tablo[0,"soyisim"]);  //  alan adı ile string kullanarak hücreye erişim

            Console.WriteLine("tüm tabloyu görmek için bir tuşa basın");
            Console.ReadKey();
            Console.Clear();
            tablo.yazdir();


 

        }





        static string[] GetColumnNames(string connectionString, string tableName)
        {
            List<string> columnNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string columnName = reader["COLUMN_NAME"].ToString();
                            columnNames.Add(columnName);
                        }
                    }
                }
            }

            return columnNames.ToArray();
        }  // fonksiyon sonu


        static List<string[]> GetRows(string connectionString, string tableName)
        {
            List<string[]> rows = new List<string[]>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Assuming all columns are strings for simplicity
                            string[] rowValues = new string[reader.FieldCount];
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                rowValues[i] = reader[i].ToString();
                            }
                            rows.Add(rowValues);
                        }
                    }
                }
            }
            return rows;
        }



    }  // program sınıfı
}  // isim alanı






//## ALANLAR  ----------  ----------  ----------  ----------
//## NİTELİKLER  ----------  ----------  ----------  ----------
//## OLUŞTURUCULAR  ----------  ----------  ----------  ----------
//## İNDEXLER  ----------  ----------  ----------  ----------
//## METODLAR  ----------  ----------  ----------  ----------