using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace km_Auto_Rental
{
    public partial class Login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from Customers where Username='" + sigusername.Text.Trim() + "'AND password='" + signpassrd.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //Response.Write("<script>alert('" + dr.GetValue(0).ToString() + "');</script>");
                        Session["Username"] = dr.GetValue(4).ToString();
                        Session["FirstName"] = dr.GetValue(1).ToString();
                        Session["LastName"] = dr.GetValue(2).ToString();
                        Session["Telephone"] = dr.GetValue(6).ToString();
                        Session["Email"] = dr.GetValue(3).ToString();
                        Session["DriverNum"] = dr.GetValue(0).ToString();
                        Session["Password"] = dr.GetValue(5).ToString();
                        Session["role"] = "customer";
                    }
                    Response.Redirect("User-Profile.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Reg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Client Sign-Up.aspx");

        }
    }
}