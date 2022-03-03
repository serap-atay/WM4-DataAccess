﻿using North_DbFirst.Models;
using North_DbFirst.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace North_DbFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NorthwindContext _dbContext=new NorthwindContext();

        private void Form1_Load(object sender, EventArgs e)
        {
            var query1 = _dbContext.Categories.Select(x => new CategoryViewModel(){ //lambda expression
               CategoryName= x.CategoryName,
               Description= x.Description,
               Picture= x.Picture,
               ProductCount=x.Products.Count
            }).ToList();   
            dataGridView1.DataSource = query1;

            var query2 = from cat in _dbContext.Categories //linq 
                         join prod in _dbContext.Products on cat.CategoryId equals prod.CategoryId
                         where prod.UnitPrice > 20
                         select new
                         {
                             cat.CategoryName,
                             prod.ProductName,
                             prod.UnitPrice

                         };
            dataGridView1.DataSource = query2
                .OrderBy(x => x.CategoryName)
                .ThenByDescending(x => x.UnitPrice)
                .ToList();

            var query3=_dbContext.Products.Select(x=> new
            {
                x.Category.CategoryName,
                x.ProductName,
                x.UnitPrice
            }).OrderBy(x=> x.CategoryName).ThenByDescending(x=> x.UnitPrice).ToList();
            dataGridView1.DataSource = query3;

        }
    }
}
