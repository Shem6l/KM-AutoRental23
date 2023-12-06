using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace km_Auto_Rental
{
    public partial class Admin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Go_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Admins where AdminID='" + EmpID.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0][3].ToString();
                    EmpLnm.Text = dt.Rows[0][4].ToString();
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    TextBox3.Text = dt.Rows[0][2].ToString();
                    //TextBox3.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    Response.Write("<script>alert('No Employee with That ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteAdmin()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM Admins Where AdminID ='" + EmpID.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Admin was deleted successfully');</script>");
                //clearform();
                Employeetbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkifAdminExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Admins where AdminID='" + EmpID.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        protected void DelBtn_Click(object sender, EventArgs e)
        {
            if (checkifAdminExist())
            {
                deleteAdmin();
                //Response.Write("<script>alert('Admin was deleted');</script>");

            }
            else
            {
                Response.Write("<script>alert('Admin does not exist');</script>");
            }
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Admins (AdminID, FirstName, LastName, Password, Username) VALUES " +
                    "(@adminid, @fname, @lname, @pword, @usern)", con);

                cmd.Parameters.AddWithValue("@fname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@lname", EmpLnm.Text.Trim());
                cmd.Parameters.AddWithValue("@pword", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@usern", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@adminid", EmpID.Text.Trim());
                //cmd.Parameters.AddWithValue("@rentrate", RentRate.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Write("<script>alert('Vehicle added to database');</script>");
                //clearform();
                Employeetbl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateadmin()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Admins SET Password = @pword WHERE AdminID ='" + EmpID.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@pword", TextBox3.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Vehicle price updated successfully');</script>");
                clearform();
                Employeetbl.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void UpBtn_Click(object sender, EventArgs e)
        {
            if (checkifAdminExist())
            {
                updateadmin();
                clearform();
                //Response.Write("<script>alert('Admin was deleted');</script>");

            }
            else
            {
                Response.Write("<script>alert('Admin does not exist');</script>");
                clearform();
            }
        }

        void clearform()
        {
            EmpID.Text = "";
            EmpLnm.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            EmpMl.Text = "";
            //RentRate.Text = "";
        }
    }
}