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
    public partial class FormÜrünler : Form
    {
        public FormÜrünler()
        {
            InitializeComponent();
        }
        DbEntityÜrünEntities db = new DbEntityÜrünEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBL_ÜRÜN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.STOK,
                                            x.MARKA,
                                            x.TBL_KATEGORİ.AD,
                                            x.DURUMM,
                                            x.FİYAT,
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBL_ÜRÜN t = new TBL_ÜRÜN();
            t.URUNAD = TXTÜRÜNADI.Text;
            t.MARKA = TXTMARKA.Text;
            t.STOK = short.Parse(TXTSTOK.Text);
            t.KATEGORİ = int.Parse(comboBox1.SelectedValue.ToString());
            t.FİYAT = decimal.Parse(TXTFİYAT.Text);
            t.DURUMM = true;
            db.TBL_ÜRÜN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kaydedildi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid);
            var ürün = db.TBL_ÜRÜN.Find(x);
            db.TBL_ÜRÜN.Remove(ürün);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var ürün = db.TBL_ÜRÜN.Find(x);
            ürün.URUNAD = TXTÜRÜNADI.Text;
            ürün.MARKA = TXTMARKA.Text;
            ürün.STOK = short.Parse(TXTSTOK.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FormÜrünler_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBL_KATEGORİ select new { x.ID, x.AD }).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;
        }
    }
}
