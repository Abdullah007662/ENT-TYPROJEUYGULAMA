using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENTİTYPROJEUYGULAMA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityÜrünEntities db = new DbEntityÜrünEntities();
        private void button4_Click(object sender, EventArgs e)// Ekleme
        {
            TBL_KATEGORİ t = new TBL_KATEGORİ();
            t.AD = textBox2.Text;
            db.TBL_KATEGORİ.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }

        private void button2_Click(object sender, EventArgs e)//Silme
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.TBL_KATEGORİ.Find(x);
            db.TBL_KATEGORİ.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");

        }

        private void button1_Click(object sender, EventArgs e)//Listeleme
        {
            var kategoriler = db.TBL_KATEGORİ.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void button3_Click(object sender, EventArgs e)//Güncelle
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktgr = db.TBL_KATEGORİ.Find(x);
            ktgr.AD = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");

        }
    }
}
