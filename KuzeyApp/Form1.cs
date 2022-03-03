using KuzeyApp.Data;
using KuzeyApp.Models;
using KuzeyApp.Repository;
using KuzeyApp.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuzeyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        KuzeyContext _dbContext=new KuzeyContext();
        private KategoriRepo _kategoriRepo=new KategoriRepo();
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //_dbContext.Kategoriler.Add(new Kategori()
            //{
            //    Ad = "Kategori",
            //    Aciklama = "aciklama"
            //});
            //_dbContext.SaveChanges();
            var kategori=(new Kategori()
            {
                Ad = "Kategori",
                Aciklama = "aciklama"
            });
            _kategoriRepo.Add(kategori);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var kategori = _dbContext.Kategoriler.First();
            kategori.Aciklama = "Güncel aciklama";
            _dbContext.SaveChanges();
        }

        private void btnSıl_Click(object sender, EventArgs e)
        {
            var kategori = _dbContext.Kategoriler.First();
            _dbContext.Kategoriler.Remove(kategori);
            _dbContext.SaveChanges();
        }

        private void btnTedarikciEkle_Click(object sender, EventArgs e)
        {

        }
    }
}
