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
#nullable disable
namespace NorthwindDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NorthwindContext _dbContext = new NorthwindContext();
        private int _offset = 0,_pagesize=10,_maxpage=0;

        private void btnIleri_Click(object sender, EventArgs e)
        {
            if (_offset+1 ==_maxpage) return;
            _offset++;
            RaporuGöster();
        }

 

        private void Form1_Load_1(object sender, EventArgs e)
        {
            RaporuGöster();

            var query7 = from cat in _dbContext.Categories
                         join prod in _dbContext.Products on cat.CategoryId equals prod.CategoryId
                         join sup in _dbContext.Suppliers on prod.SupplierId equals sup.SupplierId
                         group new { cat, prod,sup } by new
                         {
                             cat.CategoryName,
                             sup.CompanyName
                            
                         }
                         into cats
                         select new
                         {
                             CategoryName=cats.Key.CategoryName,
                             CompanyName=cats.Key.CompanyName,
                             Count= cats.Count()
                         };
            dataGridView1.DataSource = query7
                .OrderBy(x=>x.CategoryName)
                .ThenByDescending(x=>x.Count)
                .ToList();

            var query8 = from cat in _dbContext.Categories
                         join prod in _dbContext.Products on cat.CategoryId equals prod.CategoryId
                         join sup in _dbContext.Suppliers on prod.SupplierId equals sup.SupplierId
                         group new { cat, prod, sup } by new
                         {
                             cat.CategoryName,
                             sup.CompanyName

                         }
                         into cats
                         select new
                         {
                             CategoryName = cats.Key.CategoryName,
                             CompanyName = cats.Key.CompanyName,
                             Cost = cats.Sum(x=>x.prod.UnitPrice*x.prod.UnitsInStock)
                         };
            dataGridView1.DataSource = query8
                .OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.Cost)
                .ToList();

            var query9 = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .GroupBy(x => new { x.Category.CategoryName, x.Supplier.CompanyName })
                .Select(x => new
                {
                    x.Key.CategoryName,
                    x.Key.CompanyName,
                    Cost=x.Sum(p=>p.UnitsInStock*p.UnitPrice)

                });

            var query10 = _dbContext.OrderDetails
                .Include(x => x.Product)
                .GroupBy(x => new { x.Product.ProductName })
                .Select(x => new
                {
                    ProductName = x.Key.ProductName,
                    Cost = Math.Round(x.Sum(p => p.UnitPrice * p.Quantity * (decimal)(1 - p.Discount)),2)
                });
                dataGridView1.DataSource = query10
                .OrderBy(x => x.ProductName)
                .ThenByDescending(x => x.Cost)
                .ToList();

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            if (_offset == 0) return;
            _offset--;
            RaporuGöster();
        }

        private void RaporuGöster()
        {
            lblSayfa.Text = $"{_offset + 1}";
            var query6 = _dbContext.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .Select(x => new
                {
                    x.Category.CategoryName,
                    x.ProductName,
                    x.UnitPrice,
                    x.Supplier.CompanyName
                });
            if (_maxpage==0)
            {
                _maxpage=(int)Math.Ceiling(query6.Count()/Convert.ToDouble(_pagesize));
            }
            query6.Count(x => x.UnitPrice < 20);
            query6.Sum(x=>x.UnitPrice);
            query6.Average(x=>x.UnitPrice);
            query6.Max(x => x.UnitPrice);
            query6.Min(x => x.UnitPrice);
            query6.Any();
            if (query6.All(x=>x.CategoryName!="Beverages"))
            {

            }
            var result = query6
                .OrderBy(x => x.CategoryName)
                .Skip(_offset * _pagesize)
                .Take(_pagesize)
                .ToList();
            dataGridView1.DataSource=result;

        }
       
    }
}
