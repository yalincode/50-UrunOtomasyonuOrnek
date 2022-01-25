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
    public partial class ProductForm : Form
    {
        CategoryRepo categoryRepo;
        SupplierRepo supplierRepo;
        ProductRepo productRepo;
        public ProductForm()
        {
            InitializeComponent();
            categoryRepo = new CategoryRepo();
            supplierRepo = new SupplierRepo();
            productRepo = new ProductRepo();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillData();
        }

        private void FillData()
        {
            int ProductID = Convert.ToInt32(this.Tag);
            if (ProductID>0)
            {
                var product = productRepo.Get(ProductID);
                if (ProductID!=0)
                {
                    txtProductName.Text = product.ProductName;
                    cmbCategoryID.SelectedValue=product.CategoryID;
                    txtQuantityPerUnit.Text = product.QuantityPerUnit;
                    nuUnitPrice.Value = Convert.ToDecimal(product.UnitPrice);
                    cmbSuplierID.SelectedValue = product.SupplierID;
                    nuUnitsInStock.Value = Convert.ToDecimal(product.UnitsInStock);//numericupdown decimal ister.Oyüzden Convert yap.
                    nuUnitsOnOrder.Value = Convert.ToDecimal(product.UnitsOnOrder);
                    nuReorderLevel.Value = Convert.ToDecimal(product.ReorderLevel);
                    cbDiscontinued.Checked=product.Discontinued;

                }
            }
        }

        private void FillControl()
        {
            FillCategory();
            FillSuppliers();
        }

        private void FillSuppliers()
        {
            var suppliers = supplierRepo.Get();
            cmbSuplierID.DisplayMember = "CompanyName";
            cmbSuplierID.ValueMember = "SupplierID";
            cmbSuplierID.DataSource = suppliers;
        }

        private void FillCategory()
        {
            var categories = categoryRepo.Get();
            cmbCategoryID.DisplayMember = "CategoryName";
            cmbCategoryID.ValueMember = "CategoryID";
            cmbCategoryID.DataSource = categories;
        }
    }
}
