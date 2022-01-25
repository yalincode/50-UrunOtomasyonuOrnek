using _50_UrunOtomasyonuOrnek.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _50_UrunOtomasyonuOrnek.VM;

namespace _50_UrunOtomasyonuOrnek.Repository
{
    using VM;
    public class ProductRepo
    {
        //Dışardan erişilmesinler diye private yaptık.
        private SqlConnection con;
        private string ConnectionString;
        public ProductRepo()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
            con = new SqlConnection(ConnectionString);
            
            // Bunun için referanslardan System.Configuration eklenmeli.
            //App.Config ten okuma yapmak için ConfigurationManager kullanılır.
            //Eğer 2 database varsa ayrı ayrı bu kodu tekrar yazmak gerekir.
        }

        private Product ProductMapping(SqlDataReader reader)
        {
            Product product = new Product();
            product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
            product.ProdutID = Convert.ToInt32(reader["ProductID"]);
            product.ProductName = (reader["ProductName"]).ToString();
            product.SupplierID = Convert.ToInt32(reader["SupplierID"]);
            product.QuantityPerUnit = (reader["QuantityPerUnit"]).ToString();
            product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
            product.UnitsInStock = Convert.ToInt16(reader["UnitsInStock"]);
            product.UnitsOnOrder = Convert.ToInt16(reader["UnitsOnOrder"]);
            product.ReorderLevel = Convert.ToInt16(reader["ReorderLevel"]);
            product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);
            return product;
        }


        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                SqlCommand command = new SqlCommand("Sp_Products", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if(con.State==ConnectionState.Closed) con.Open();
                SqlDataReader reader=command.ExecuteReader();
                while (reader.Read())
                {
                    var product = ProductMapping(reader);
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if(con.State==ConnectionState.Open) con.Close();
            }

            return products; //Sonucu geriye dönüyoruz.
        }

        public List<VMProduct> GetVMProducts()
        {
            List<VMProduct> products = new List<VMProduct>();

            try
            {
                SqlCommand command = new SqlCommand("Sp_Products", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (con.State == ConnectionState.Closed) con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    VMProduct product = new VMProduct();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = (reader["ProductName"]).ToString();
                    product.SupplierName = reader["SupplierName"].ToString();
                    product.CategoryName = (reader["CategoryName"]).ToString();
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return products; //Sonucu geriye dönüyoruz.
        }

        public Product Get(int ProductID)
        {
            Product product=null;
            try
            {
                SqlCommand command = new SqlCommand("Sp_Products", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ProductID", ProductID);
                if (con.State == ConnectionState.Closed) con.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    product=ProductMapping(reader);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }
            return product;
        }
    }
}
