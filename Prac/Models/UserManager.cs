using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prac.Models
{
    public class UserManager
    {
        public void AddUser(User user)
        {
            user.UserType = "Normal";
            using (SqlConnection cn = new SqlConnection("data source=ADMIN-PC\\SQLEXPRESS; initial catalog=something; integrated security=sspi;"))
            {
                using (SqlCommand cmd= new SqlCommand("register_user",cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fname", user.FirstName);
                    cmd.Parameters.AddWithValue("@lname", user.LastName);
                    cmd.Parameters.AddWithValue("@email_id", user.EmailId);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (SqlException)
                    {
                        throw;
                    }
                    finally
                    {
                        if (cn.State==System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                    
                }
            }
        }

        public User GetUser(User user)
        {
            using (SqlConnection cn= new SqlConnection("data source= ADMIN-PC\\SQLEXPRESS; initial catalog= something; integrated security=sspi "))
            {
                using (SqlCommand cmd= new SqlCommand("get_user", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email_id", user.EmailId);

                    try
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            user.FirstName =Convert.ToString( dr["fname"]);
                            user.LastName =Convert.ToString( dr["lname"]);
                            user.Password =Convert.ToString( dr["password"]);
                            user.UserType =Convert.ToString( dr["user_type_name"]);
                        }
                    }
                    catch (SqlException)
                    {

                        throw;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }

            return user;
        }

        public bool VerifyLogin(User user)
        {
            bool c;
            using (SqlConnection cn = new SqlConnection("data source= ADMIN-PC\\SQLEXPRESS; initial catalog= something; integrated security=sspi "))
            {
                using (SqlCommand cmd = new SqlCommand("verify_user", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email_id", user.EmailId);
                    cmd.Parameters.AddWithValue("@password", user.Password);

                    try
                    {
                        cn.Open();
                         c = Convert.ToBoolean(cmd.ExecuteScalar());

                    }
                    catch (SqlException)
                    {

                        throw;
                    }
                    finally
                    {
                        if (cn.State==System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }

            return c;
        }

        public bool VerifyEmailId(User user)
        {
            bool c;
            using (SqlConnection cn = new SqlConnection("data source= ADMIN-PC\\SQLEXPRESS; initial catalog= something; integrated security=sspi "))
            {
                using (SqlCommand cmd = new SqlCommand("verify_email_id", cn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email_id", user.EmailId);

                    try
                    {
                        cn.Open();
                        c = Convert.ToBoolean(cmd.ExecuteScalar());

                    }
                    catch (SqlException)
                    {

                        throw;
                    }
                    finally
                    {
                        if (cn.State == System.Data.ConnectionState.Open)
                        {
                            cn.Close();
                        }
                    }
                }
            }

            return c;
        }
    }
}