using _50_UrunOtomasyonuOrnek.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_UrunOtomasyonuOrnek.Repository
{
    internal class SupplierRepo :RepositoryBase,IRepository<Supplier>
    {
        public void Create(Supplier item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> Get()
        {
            List<Supplier> suppliers = new List<Supplier>();

            SqlCommand command = new SqlCommand("select SupplierID,CompanyName,ContactName,ContactTitle from Suppliers", this.Connection);
            if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                suppliers.Add(new Supplier()
                {
                    SupplierID = Convert.ToInt32(reader["SupplierID"]),
                    CompanyName = reader["CompanyName"].ToString(),
                    ContactName = reader["ContactName"].ToString(),
                    ContactTitle = reader["ContactTitle"].ToString(),
                });
            }
            if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();

            return suppliers;
        }

        public Supplier GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Supplier item)
        {
            throw new NotImplementedException();
        }
    }
}
