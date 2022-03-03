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
    public partial class SiparisForm : Form
    {
        public SiparisForm()
        {
            InitializeComponent();
        }
        NorthwindContext _dbContext=new NorthwindContext();
        private void SiparisForm_Load(object sender, EventArgs e)
        {
           
            ListeyiDoldur();
        }

        private void ListeyiDoldur()
        {
            lstProducts.DataSource = UrunAra();
            lstProducts.DisplayMember = "ProductName";
            cmbEmployee.DataSource = _dbContext.Employees.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();
            cmbShippers.DataSource = _dbContext.Shippers.ToList();
            cmbShippers.DisplayMember = "CompanyName";
            cmbCustomer.DataSource = _dbContext.Customers
                .OrderBy(x=>x.CompanyName)
                .ToList();
            cmbCustomer.DisplayMember = "CompanyName";
        }
        private List<Product> UrunAra(Func<Product,bool> predicate=null)
        {
            return predicate == null ? _dbContext.Products
                .OrderBy(x => x.ProductName).ToList():
                _dbContext.Products.Where(predicate)
                .OrderBy(x => x.ProductName).ToList();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            string text = txtAra.Text.ToLower();
            lstProducts.DataSource = UrunAra(x=>x.ProductName.ToLower().Contains(text));
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            //transaction
            using(var tran=_dbContext.Database.BeginTransaction())
            {
                var customer=cmbCustomer.SelectedItem as Customer;
                var employee=cmbEmployee.SelectedItem as Employee;
                var shipper=cmbShippers.SelectedItem as Shipper;
                try
                {
                    var order = new Order()
                    {
                        CustomerId=customer?.CustomerId,
                        EmployeeId=employee?.EmployeeId,
                        ShipVia=shipper?.ShipperId,
                        Freight=nFreight.Value,
                        OrderDate=DateTime.Now,
                        RequiredDate=dtpRequiredDate.Value,
                        ShipAddress=txtShipAdress.Text,
                        ShipCity=txtShipCity.Text,
                        ShipName=txtShipName.Text,
                        ShipPostalCode=txtShipPostalCode.Text,
                        ShipRegion=txtShipRegion.Text,
                        ShipCountry=txtShipCountry.Text,
                    };
                    _dbContext.Orders.Add(order);
                    _dbContext.SaveChanges();
                    //sepet foreach
                    _dbContext.SaveChanges();

                    tran.Commit();
                    //messagebox
                }
                catch (Exception ex)
                {

                    tran.Rollback();
                    MessageBox.Show("Sipariş işleminizde bir hata oluştu.");
                    _dbContext=new NorthwindContext();
                }
            }
        }
    }
}
