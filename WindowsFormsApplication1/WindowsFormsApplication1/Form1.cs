using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public string Blagajnik;

        public Form1()
        {
            InitializeComponent();

            izdelki.Items.Clear();
            var cmd = DB.GetCommand("select id, sifra, ime, cena, ddv from izdelki order by ime");
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                var id = r.GetInt32(0);
                var sifra = r.GetString(1);
                var ime = r.GetString(2);
                var cena = r.GetDouble(3);
                var ddv = r.GetDouble(4);

                izdelki.Items.Add(new izdelek { Id = id, Sifra = sifra, Ime = ime, Cena = cena, Ddv = ddv });
            }

            izdelki.SelectedIndex = 0;
        }

        private void novracun_Click(object sender, EventArgs e)
        {
            var cmd = DB.GetCommand("novracun");
            cmd.CommandType = CommandType.StoredProcedure;
            var r = cmd.ExecuteReader();

            r.Read();
            var id = r.GetInt32(0);
            var st = r.GetString(1);

            stevilka.Text = st;
            postavke.Items.Clear();
        }

        private void dodajanje_Click(object sender, EventArgs e)
        {
            var idizdelka = ((izdelek)izdelki.SelectedItem).Id;
            var stevilkaracuna = stevilka.Text;

            var cmd2 = DB.GetCommand("select id from racuni where stevilka = '" + stevilkaracuna + "'");
            var r2 = cmd2.ExecuteReader();
            r2.Read();
            var idracuna = r2.GetInt32(0);

            var cmd = DB.GetCommand("dodajizdelek");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idracuna", idracuna);
            cmd.Parameters.AddWithValue("idizdelka", idizdelka);
            var r = cmd.ExecuteReader();

            postavke.Items.Clear();
            while (r.Read())
            {
                var ime = r.GetString(0);
                var neto = r.GetDouble(1);
                var bruto = r.GetDouble(2);

                postavke.Items.Add(new ListViewItem(new string[] { ime, neto.ToString ("###,##0.00"), bruto.ToString("###,##0.00") }));
            }

            var cmd3 = DB.GetCommand("select zaplacilo from racuni where stevilka = '" + stevilkaracuna + "'");
            var r3 = cmd3.ExecuteReader();
            r3.Read();
            var zaplacilo = r3.GetDouble(0);
            znesek.Text = zaplacilo.ToString("###,##0.00");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ImeBlagajnika.Text = "Blagajnik: " + Blagajnik;
        }
    }

    public class izdelek
    {
        public int Id;
        public string Sifra;
        public string Ime;
        public double Cena;
        public double Ddv;

        public override string ToString()
        {
            return Ime + " " + Cena.ToString("###,##0.00");
        }
    }
}
