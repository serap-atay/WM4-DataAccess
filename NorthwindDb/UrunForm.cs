using Microsoft.EntityFrameworkCore;
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
    public partial class UrunForm : Form
    {
        public UrunForm()
        {
            InitializeComponent();
        }
        NorthwindContext _dbContext = new NorthwindContext();
        private void UrunForm_Load(object sender, EventArgs e)
        {
            listeyiDoldur();
        }

        private void listeyiDoldur()
        {
            lstUrunler.DataSource = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .ToList();
            lstUrunler.DisplayMember = "ProductName";

            cmbKategori.DataSource = _dbContext.Categories.ToList();
            cmbKategori.DisplayMember = "CategoryName";
            cmbKategori.ValueMember = "CategoryId";

            cmbSupplier.DataSource = _dbContext.Suppliers.ToList();
            cmbSupplier.DisplayMember = "CompanyName";

        }
        private Product _selectedproduct;
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null) return;
            _selectedproduct = (Product)lstUrunler.SelectedItem;
            txtUrunAdi.Text = _selectedproduct.ProductName;
            nUnitPrice.Value = _selectedproduct.UnitPrice.GetValueOrDefault();
            cbDiscounting.Checked = _selectedproduct.Discontinued;

            cmbKategori.SelectedItem = _selectedproduct.Category;
            cmbSupplier.SelectedItem = _selectedproduct.Supplier;
        }

        private Category _selectedcategory;
        private Supplier _selectedsupplier;
        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedItem != null)
                _selectedcategory = (Category)cmbKategori.SelectedItem;
            else
                _selectedcategory = null;
            if (cmbSupplier.SelectedItem != null)
                _selectedsupplier = (Supplier)cmbSupplier.SelectedItem;
            else
                _selectedsupplier = null;

            var yeni = new Product()
            {
                UnitPrice = nUnitPrice.Value,
                ProductName = txtUrunAdi.Text,
                Discontinued = cbDiscounting.Checked,
                CategoryId = _selectedcategory == null ? null : _selectedcategory.CategoryId,
                SupplierId = _selectedsupplier?.SupplierId

            };
            try
            {
                _dbContext.Products.Add(yeni);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                _dbContext = new NorthwindContext();
            }
            finally
            {
                listeyiDoldur();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (_selectedcategory == null) return;
            try
            {
                var product = _dbContext.Products.Find(_selectedproduct.ProductId);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
                listeyiDoldur();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                //newlenen kısım
                _dbContext = new NorthwindContext();
            }
            finally
            {
                listeyiDoldur();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (_selectedcategory == null) return;
            if (cmbKategori.SelectedItem != null)
                _selectedcategory = (Category)cmbKategori.SelectedItem;
            else
                _selectedcategory = null;
            if (cmbSupplier.SelectedItem != null)
                _selectedsupplier = (Supplier)cmbSupplier.SelectedItem;
            else
                _selectedsupplier = null;
            try
            {
                var product = _dbContext.Products.Find(_selectedproduct.ProductId);
                product.ProductName = txtUrunAdi.Text;
                product.UnitPrice = nUnitPrice.Value;
                product.Discontinued = cbDiscounting.Checked;
                product.CategoryId = _selectedcategory == null ? null : _selectedcategory.CategoryId;
                product.SupplierId = _selectedsupplier?.SupplierId;

                var updateEntry = _dbContext.Products.Update(product);
                _dbContext.Products.Update(product);

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
                listeyiDoldur();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtUrunAdi.Text = "";
            cbDiscounting.Checked = false;
        }

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            var productlar = _dbContext.Products
                .Include(x => x.ProductName)
                .ToList();
            foreach (var kelime in productlar)
            {
            }



        }
    }
}

