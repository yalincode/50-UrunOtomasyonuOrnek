using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _50_UrunOtomasyonuOrnek
{
    using Repository;
    using Entities;
    using _50_UrunOtomasyonuOrnek.VM;

    public partial class Form1 : Form
    {
        ProductRepo productRepo;
        public Form1()
        {
            InitializeComponent();
            productRepo=new ProductRepo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grdProducts.DataSource= productRepo.GetVMProducts();
        }

        private void grdProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            var product=(grdProducts.DataSource as List<VMProduct>)[e.RowIndex];

            //Double Click yapıldığında form güncelleme modunda çalışır.
            ProductForm form = new ProductForm();
            form.Tag = product.ProductID;
            form.ShowDialog();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm=new ProductForm();
            productForm.ShowDialog();
        }
    }
}
