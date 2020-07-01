using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LPEntities;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LPAccess
{
    public class UserServices
    {
        private static readonly string objConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection _objSqlConn;
        public User SaveUserDetails(User user)
        {
            _objSqlConn = new SqlConnection(objConnectionString);
            SqlCommand sqlComm = new SqlCommand("saveUserDetails", _objSqlConn);
            try
            {
                if (_objSqlConn.State != ConnectionState.Open)
                    _objSqlConn.Open();
                DataTable ds = new DataTable();
                sqlComm.Parameters.AddWithValue("@UserID", user.UserID);
                sqlComm.Parameters.AddWithValue("@UserName", user.Name);
                sqlComm.Parameters.AddWithValue("@EmailID", user.Email);
                sqlComm.Parameters.AddWithValue("@Gender", user.Gender);
                sqlComm.Parameters.AddWithValue("@Password", user.Password);
                sqlComm.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);
                sqlComm.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                sqlComm.Parameters.AddWithValue("@City", user.CityName);
                sqlComm.Parameters.AddWithValue("@Address", user.Address);
                sqlComm.Parameters.AddWithValue("@IsDelete", user.IsDelete);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter { SelectCommand = sqlComm };
                da.Fill(ds);

                if (ds.Rows.Count == 1)
                {
                    user.Error = ds.Rows[0]["Error"].ToString();
                    user.ErrorCode = Convert.ToInt32(ds.Rows[0]["ErrorCode"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlComm.Connection.Close();
            }
            return user;
        }
        public User UpdateUserDetails(User user)
        {
            _objSqlConn = new SqlConnection(objConnectionString);
            SqlCommand sqlComm = new SqlCommand("updateUserDetails", _objSqlConn);
            try
            {
                if (_objSqlConn.State != ConnectionState.Open)
                    _objSqlConn.Open();
                DataTable ds = new DataTable();
                sqlComm.Parameters.AddWithValue("@UserID", user.UserID);
                sqlComm.Parameters.AddWithValue("@UserName", user.Name);
                sqlComm.Parameters.AddWithValue("@EmailID", user.Email);
                sqlComm.Parameters.AddWithValue("@Gender", user.Gender);
                sqlComm.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                sqlComm.Parameters.AddWithValue("@City", user.CityName);
                sqlComm.Parameters.AddWithValue("@Address", user.Address);
                sqlComm.Parameters.AddWithValue("@IsDelete", user.IsDelete);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter { SelectCommand = sqlComm };
                da.Fill(ds);

                if (ds.Rows.Count == 1)
                {
                    user.Error = ds.Rows[0]["Error"].ToString();
                    user.ErrorCode = Convert.ToInt32(ds.Rows[0]["ErrorCode"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlComm.Connection.Close();
            }
            return user;
        }
        public List<User> GetUserDetails()
        {
            _objSqlConn = new SqlConnection(objConnectionString);

            SqlCommand sqlComm = new SqlCommand("selUserDetails", _objSqlConn);
            List<User> ulist = new List<User>();
            try
            {
                if (_objSqlConn.State != ConnectionState.Open)

                    _objSqlConn.Open();

                DataTable ds = new DataTable();
                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter { SelectCommand = sqlComm };
                da.Fill(ds); if (ds.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        DataRow dr = ds.Rows[i];
                        ulist.Add(new User
                        {
                            UserID = (dr["UserID"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["UserID"].ToString()),
                            Name = (dr["UserName"] == DBNull.Value) ? null : dr["UserName"].ToString(),
                            Gender = (dr["Gender"] == DBNull.Value) ? null : dr["Gender"].ToString(),
                            Email = (dr["EmailID"] == DBNull.Value) ? null : dr["EmailID"].ToString(),
                            PhoneNumber = (dr["PhoneNumber"] == DBNull.Value) ? null : dr["PhoneNumber"].ToString(),
                            CityName = (dr["City"] == DBNull.Value) ? null : dr["City"].ToString(),
                            Address = (dr["Address"] == DBNull.Value) ? null : dr["Address"].ToString()

                        }); ;
                    }
                }
            }
            catch (Exception ex) { }
            finally
            {
                sqlComm.Connection.Close();
            }

            return ulist;
        }

        public User updateUserPassword(User user)
        {
            _objSqlConn = new SqlConnection(objConnectionString);
            SqlCommand sqlComm = new SqlCommand("updUserPassword", _objSqlConn);
            try
            {
                if (_objSqlConn.State != ConnectionState.Open)
                    _objSqlConn.Open();
                DataTable ds = new DataTable();
                //sqlComm.Parameters.AddWithValue("@UserID", user.UserID);
                sqlComm.Parameters.AddWithValue("@UserName", user.Name);
                sqlComm.Parameters.AddWithValue("@EmailID", user.Email);
                sqlComm.Parameters.AddWithValue("@Password", user.Password);
                sqlComm.Parameters.AddWithValue("@ConfirmPassword", user.ConfirmPassword);
                sqlComm.Parameters.AddWithValue("@IsDelete", user.IsDelete);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter { SelectCommand = sqlComm };
                da.Fill(ds);

                if (ds.Rows.Count == 1)
                {

                    user.Error = ds.Rows[0]["Error"].ToString();
                    user.ErrorCode = Convert.ToInt32(ds.Rows[0]["ErrorCode"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlComm.Connection.Close();
            }
            return user;
        }
        public User GetUserLogin(User user)
        {
            _objSqlConn = new SqlConnection(objConnectionString);
            SqlCommand sqlComm = new SqlCommand("selUserLogin", _objSqlConn);
            try
            {
                if (_objSqlConn.State != ConnectionState.Open)
                    _objSqlConn.Open();
                DataTable ds = new DataTable();
                //sqlComm.Parameters.AddWithValue("@UserID", user.UserID);               
                sqlComm.Parameters.AddWithValue("@EmailID", user.Email);
                sqlComm.Parameters.AddWithValue("@Password", user.Password);

                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter { SelectCommand = sqlComm };
                da.Fill(ds);

                if (ds.Rows.Count == 1)
                {
                    user.UserID = (ds.Rows[0]["UserID"] == DBNull.Value) ? 0 : Convert.ToInt32(ds.Rows[0]["UserID"].ToString());
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                sqlComm.Connection.Close();
            }
            return user;
        }
        public Media SaveImageDetails(Media fum)
        {
            return fum;
        }
    }
}

