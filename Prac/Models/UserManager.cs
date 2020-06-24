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
    }
}