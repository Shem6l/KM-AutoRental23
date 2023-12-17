using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace km_Auto_Rental
{
    public partial class Admin_Login1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AdmLgin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    // Use parameterized queries to prevent SQL injection
                    SqlCommand cmdAdmin = new SqlCommand("SELECT * FROM Admins WHERE Username = @Username AND Password = @Password", con);
                    cmdAdmin.Parameters.AddWithValue("@Username", AdmName.Text.Trim());
                    cmdAdmin.Parameters.AddWithValue("@Password", Admpassrd.Text.Trim());

                    SqlCommand cmdMasterAdmin = new SqlCommand("SELECT * FROM Master_Admin WHERE Username = @Username AND Password = @Password", con);
                    cmdMasterAdmin.Parameters.AddWithValue("@Username", AdmName.Text.Trim());
                    cmdMasterAdmin.Parameters.AddWithValue("@Password", Admpassrd.Text.Trim());

                    using (SqlDataReader dr = cmdAdmin.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                SetSessionVariables(dr, "Admin");
                            }
                            Response.Redirect("Vehicle-Rent.aspx");
                            return;
                        }
                    }

                    using (SqlDataReader dr2 = cmdMasterAdmin.ExecuteReader())
                    {
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            {
                                SetSessionVariables(dr2, "Master_Admin");
                            }
                            Response.Redirect("Master_Admin_Dash.aspx");
                            return;
                        }
                    }

                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                Response.Write("<script>alert('An error occurred');</script>");
            }
        }

        private void SetSessionVariables(SqlDataReader dr, string role)
        {
            Session["Username"] = dr.GetValue(1).ToString();
            Session["FirstName"] = dr.GetValue(3).ToString();
            Session["LastName"] = dr.GetValue(4).ToString();
            Session["AdminID"] = dr.GetValue(0).ToString();
            Session["role"] = role;
        }

    }
}