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
    public partial class Formİstatistik : Form
    {
        public Formİstatistik()
        {
            InitializeComponent();
        }
        DbEntityÜrünEntities db = new DbEntityÜrünEntities();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void Formİstatistik_Load(object sender, EventArgs e)
        {
            TplktgSys.Text = db.TBL_KATEGORİ.Count().ToString();
            TplUrnSys.Text = db.TBL_ÜRÜN.Count().ToString();
            AktfMsys.Text = db.TBL_MÜŞTERİ.Count(x => x.DURUM ==true).ToString();
            PsfmüşSys.Text = db.TBL_MÜŞTERİ.Count(x => x.DURUM == false).ToString();
            TplStkSys.Text = db.TBL_ÜRÜN.Sum(x => x.STOK).ToString();
            KsdTutar.Text = db.TBL_SATIŞ.Sum(x => x.FİYAT).ToString()+"TL";
            EnYFYÜrn.Text = (from x in db.TBL_ÜRÜN orderby x.FİYAT descending select x.URUNAD).FirstOrDefault();
            label13.Text = (from x in db.TBL_ÜRÜN orderby x.FİYAT ascending select x.URUNAD).FirstOrDefault();
            ByzEşySys.Text = db.TBL_ÜRÜN.Count(x => x.KATEGORİ == 1).ToString();
            TplBzdSys.Text = db.TBL_ÜRÜN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            ŞhrSys.Text = (from x in db.TBL_MÜŞTERİ select x.ŞEHİR).Distinct().Count().ToString();
            EnFzlÜrnMrk.Text = db.MARKAGETİR().FirstOrDefault();
        }
    }
}
