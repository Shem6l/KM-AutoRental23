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
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Admins where Username='" + AdmName.Text.Trim() + "'AND password='"+ Admpassrd.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('" + dr.GetValue(1).ToString() + "');</script>");
                        Session["Username"] = dr.GetValue(1).ToString();
                        Session["FirstName"] = dr.GetValue(3).ToString();
                        Session["LastName"] = dr.GetValue(4).ToString();
                        Session["AdminID"] = dr.GetValue(0).ToString();
                        Session["role"] = "Admin";
                        
                    }
                    Response.Redirect("Vehicle-Rent.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
                
            }
            catch (Exception ex){
                
            }
        }
    }
}