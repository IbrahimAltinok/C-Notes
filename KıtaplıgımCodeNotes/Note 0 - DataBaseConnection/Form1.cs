using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace medicalData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-FTOS96GG;Initial Catalog=hastalar;Integrated Security=True");
        

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from hasta_takip_listesi", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem() ;
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["hasta_adi"].ToString());

                ekle.SubItems.Add(oku["hasta_soyadi"].ToString());
                ekle.SubItems.Add(oku["dogum_tarihi"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                ekle.SubItems.Add(oku["doktor_adi"].ToString());
                ekle.SubItems.Add(oku["doktor_soyadi"].ToString());


                listView1.Items.Add(ekle);


            }

            baglan.Close();

        }
    }
}
