using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;

namespace PollutionMap
{

    public partial class Autentificare : Form
    {
        private StreamReader sr;
        private SqlConnection con = null;
        private SqlCommand cmd = null;
        private string conStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True;";
        public Autentificare()
        {

            InitializeComponent();
            con = new SqlConnection(conStr);
            cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            PopuleazaTabelaHarti();
            SelectToateHartile();
            PopuleazaTabelaMasurare();
            SelectToateMasuratorile();

        }
        private void SelectToateHartile()
        {
            string query = PopuleazaTabelaHarti();
            query = "SELECT * FROM Harti";
            cmd.CommandText = query;
            var dr = cmd.ExecuteReader(); ///pentru Select pt a se executa
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close(); // important sa inchizi!! 
            dGVHarti.DataSource = dt;

        }
        private string PopuleazaTabelaHarti()
        {
            /// luam din resurse harti.txt
            string path = Directory.GetCurrentDirectory() + @"\Resurse\harti.txt";
            sr = new StreamReader(path);
            string line = "";
            string query = "INSERT INTO Harti(NumeHarta, FisierHarta) VALUES (@nume, @fisier);";
            while((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split('#');
                string numeHarta = s[0];
                string fisierHarta = s[1];
                cmd.Parameters.AddWithValue("nume", numeHarta);
                cmd.Parameters.AddWithValue("fisier", fisierHarta);
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery(); ///pentru Insert into, delete, update
                cmd.Parameters.Clear();

            }
            sr.Close();
            return query;
        }
        private void SelectToateMasuratorile()
        {
            string query = PopuleazaTabelaMasurare();
            query = "SELECT * FROM Masurare";
            cmd.CommandText = query;
            var dr = cmd.ExecuteReader(); ///pentru Select pt a se executa
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close(); // important sa inchizi!! 
            dGVMasurare.DataSource = dt;

        } 

    private int GetIdHarti(string harta)
        {
            con.Close();
            con = new SqlConnection(conStr);
            con.Open();

            string query = "SELECT IdHarta FROM Harti WHERE NumeHarta = '" + harta + " '";
            cmd = new SqlCommand(query,con);
            var dr = cmd.ExecuteReader();
            dr.Read();
            int id = int.Parse(dr[0].ToString());
            dr.Close();
            return id;

        }
        private string PopuleazaTabelaMasurare()
        {
            string path = Directory.GetCurrentDirectory() + @"\Resurse\masurari.txt";
            sr = new StreamReader(path);
            string line = "";
            string query = "INSERT INTO Masurare(IdHarta, PozitieX, PozitieY, ValoareMasurare,DataMasurare) VALUES (@idHarta, @pozitieX, @pozitieY, @valoareMasurare, @data);";
            while ((line = sr.ReadLine()) != null)
            {
                string[] s = line.Split('#');
                string numeHarta = s[0];
                int idHarta = GetIdHarti(numeHarta);
                int pozitieX = int.Parse(s[1]);
                int pozitieY = int.Parse(s[2]);
                double valoareMasurare = double.Parse(s[3]);
                DateTime dataMasurare = DateTime.ParseExact(s[4], "dd/MM/yyyy HH:mm", null); 
                cmd.Parameters.AddWithValue("idHarta", idHarta);
                cmd.Parameters.AddWithValue("pozitieX", pozitieX);
                cmd.Parameters.AddWithValue("pozitieY", pozitieY);
                cmd.Parameters.AddWithValue("valoareMasurare", valoareMasurare);
                cmd.Parameters.AddWithValue("data", dataMasurare);
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery(); ///pentru Insert into, delete, update
                cmd.Parameters.Clear();

            }
            sr.Close();
            return query;
        }
        
    }
}
