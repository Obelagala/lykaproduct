using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPEntities;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace LPAccess
{
    public class CitiesServices
    {
        private static readonly string objConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        SqlConnection _objSqlConn;
        public List<Cities> GetCities()
        {
            _objSqlConn = new SqlConnection(objConnectionString);
            SqlCommand sqlComm = new SqlCommand("selCities", _objSqlConn);
            List<Cities> _cities = new List<Cities>();
            try
            {
                if (_objSqlConn.State != ConnectionState.Open)

                    _objSqlConn.Open();

                DataTable ds = new DataTable();
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter { SelectCommand = sqlComm };
                da.Fill(ds);
                if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        DataRow dr = ds.Rows[i];
                        _cities.Add(new Cities
                        {
                            CityID = (dr["CityID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CityID"].ToString()),
                            CityName = (dr["CityName"] == DBNull.Value) ? null : dr["CityName"].ToString(),

                        }); ;

                    }
                }
               
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlComm.Connection.Close();
            }
            return _cities;
        }
    }
}
