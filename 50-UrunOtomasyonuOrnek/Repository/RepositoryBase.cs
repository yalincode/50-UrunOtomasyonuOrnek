using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace _50_UrunOtomasyonuOrnek.Repository
{
    public abstract class RepositoryBase
    {
        SqlConnection connection = null;
        public RepositoryBase()
        {
            connection=new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
        }
        public SqlConnection Connection
        {
            get { return connection; }
        }

    }
}
