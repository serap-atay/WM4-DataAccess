using NorthwindDb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindDb
{
    public partial class KategoriForm : Form
    {
        public KategoriForm()
        {
            InitializeComponent();
        }
        NorthwindContext _dbContext=new NorthwindContext();
        private void KategoriForm_Load(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            lstKategori.DataSource = _dbContext.Categories.ToList();
            lstKategori.DisplayMember = "CategoryName";
        }
        Category _selectedcategory;
        private void lstKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKategori.SelectedIndex == -1) return;
            _selectedcategory=(Category)lstKategori.SelectedItem;
            txtKategoriAdi.Text = _selectedcategory.CategoryName;
            txtAciklama.Text = _selectedcategory.Description;
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var yeni= new Category
                {
                    CategoryName=txtKategoriAdi.Text,
                    Description=txtAciklama.Text,
                };
                _dbContext.Categories.Add(yeni);
                _dbContext.SaveChanges();
                ListeyiDoldur();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            //hata alınca _dbContext instancesı sapıtıyor newlemek gerekiyor.
            if (_selectedcategory == null) return;            
            try
            {
                var category = _dbContext.Categories.Find(_selectedcategory.CategoryId);
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
                ListeyiDoldur();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //newlenen kısım
                _dbContext = new NorthwindContext();
            }
            finally
            {
                ListeyiDoldur();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedcategory == null) return;
            try
            {
                var category = _dbContext.Categories.Find(_selectedcategory.CategoryId);
                category.CategoryName = txtKategoriAdi.Text;
                category.Description = txtAciklama.Text;
                // sadece değişen kısmını güncelliyor diğer kısımlar aynı ==> entry
                //var entry = _dbContext.Entry(category);
                //change tracking -- ve -- fark alıyor --status =modified
                var updateEntry=_dbContext.Categories.Update(category);
                _dbContext.Categories.Update(category);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //newlenen kısım
                _dbContext = new NorthwindContext();
            }
            finally
            {
                ListeyiDoldur();
            }
        }
    }
}
