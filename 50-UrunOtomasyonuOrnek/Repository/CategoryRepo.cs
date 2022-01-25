using _50_UrunOtomasyonuOrnek.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50_UrunOtomasyonuOrnek.Repository
{
    public class CategoryRepo :RepositoryBase, IRepository<Category>
    {

        public CategoryRepo():base()
        {
            //Normalde önce burası çalışır sonra base classın constructurunu çalıştırı ama base anahtar kelimesi ile önce base class a gider.
        }
        public void Create(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            List<Category> categories=new List<Category>();

            SqlCommand command = new SqlCommand("SELECT CategoryID,CategoryName,Description FROM Categories", this.Connection);
            if (this.Connection.State == System.Data.ConnectionState.Closed) this.Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category()
                {
                    CategoryID = Convert.ToInt32(reader["CategoryID"]),
                    CategoryName = reader["CategoryName"].ToString(),
                    Description=reader["Description"].ToString(),
                }) ;
            }
            if (this.Connection.State == System.Data.ConnectionState.Open) this.Connection.Close();

            return categories;
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }
    }
}
