using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_UrunOtomasyonuOrnek.Entities
{
    public class Product
    {
        public int ProdutID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; } //Soru işareti koyarsak nullable olabilir yani null alabilir.
        public int? CategoryID { get; set; }//yada Nulable<int> yazılabilir.
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
