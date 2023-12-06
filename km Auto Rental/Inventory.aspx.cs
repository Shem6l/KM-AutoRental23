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
    public partial class Inventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            InvTabl.DataBind();
            clearform();
        }

        protected void InvAddBtn_Click(object sender, EventArgs e)
        {
            if (checkifVehicleExist())
            {
                Response.Write("<script>alert('A vehicle with the chassis number already exists');</script>");
            }
            else
            {
                addnewVehicle();
            }
        }

        protected void InvUpBtn_Click(object sender, EventArgs e)
        {
            if (checkifVehicleExist())
            {
                if (String.IsNullOrWhiteSpace(RentRate.Text))
                {
                    if (String.IsNullOrWhiteSpace(TextBox2.Text)) {
                        Response.Write("<script>alert('Please enter vehicle plate number');</script>");
                    }
                    else
                    {
                        updateVehicleplate();
                        Response.Write("<script>alert('Vehicle plate was updated');</script>");
                    }
                }
                else
                {
                    updateVehiclerentrate();
                    Response.Write("<script>alert('Vehicle price was updated');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('A vehicle with the chassis number does not exists');</script>");
            }
        }

        protected void InvDelBtn_Click(object sender, EventArgs e)
        {
            if (checkifVehicleExist())
            {
                deleteVehicle();
                Response.Write("<script>alert('Vehicle was deleted');</script>");

            }
            else
            {
                Response.Write("<script>alert('Vehicle does not exist');</script>");
            }
        }

        protected void GoInvBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(TextBox1.Text))
            {
                getvehiclebyplate();
            }
            else if(String.IsNullOrEmpty(TextBox2.Text))
            {    
               getvehiclebyprice();
            }
            else
            {
                getvehiclebyChassis();
            }
            
        }

        void getvehiclebyprice()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Vehicles where RentalRate='" + RentRate.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0][0].ToString();
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    Vmake.Text = dt.Rows[0][2].ToString();
                    Model.Text = dt.Rows[0][3].ToString();
                    InvYear.Text = dt.Rows[0][4].ToString();
                    //RentRate.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Response.Write("<script>alert('INVALID OR NO INPUT');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        
        void getvehiclebyplate()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Vehicles where Plate_Number='" + TextBox2.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox1.Text = dt.Rows[0][0].ToString();
                    Vmake.Text = dt.Rows[0][2].ToString();
                    Model.Text = dt.Rows[0][3].ToString();
                    InvYear.Text = dt.Rows[0][4].ToString();
                    RentRate.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Response.Write("<script>alert('INVALID OR NO INPUT');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        
        

        void getvehiclebyChassis()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Vehicles where Chassis_Number='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                    Vmake.Text = dt.Rows[0][2].ToString();
                    Model.Text = dt.Rows[0][3].ToString();
                    InvYear.Text = dt.Rows[0][4].ToString();
                    RentRate.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Response.Write("<script>alert('INVALID NO INPUT');</script>");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkifVehicleExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Vehicles where Chassis_Number='" + TextBox1.Text.Trim() + "';", con);
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

        void addnewVehicle()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Vehicles (Chassis_Number, Plate_Number, Make, Model, Year, RentalRate) VALUES " +
                    "(@chasnum, @platenum, @make, @model, @year, @rentrate)", con);

                cmd.Parameters.AddWithValue("@chasnum", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@platenum", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@make", Vmake.Text.Trim());
                cmd.Parameters.AddWithValue("@model", Model.Text.Trim());
                cmd.Parameters.AddWithValue("@year", InvYear.Text.Trim());
                cmd.Parameters.AddWithValue("@rentrate", RentRate.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
               // Response.Write("<script>alert('Vehicle added to database');</script>");
                clearform();
                InvTabl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateVehiclerentrate()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Vehicles SET RentalRate = @rentrate WHERE Chassis_Number ='"+ TextBox1.Text.Trim() +"'", con);

                cmd.Parameters.AddWithValue("@rentrate", RentRate.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                //Response.Write("<script>alert('Vehicle price updated successfully');</script>");
                clearform();
                InvTabl.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteVehicle()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM [KMCarRentalDB].[dbo].[Vehicles] Where Chassis_Number ='" + TextBox1.Text.Trim() + "'", con);


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Vehicle was successfully deleted');</script>");
                clearform();
                InvTabl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clearform()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Vmake.Text = "";
            Model.Text = "";
            InvYear.Text = "";
            RentRate.Text = "";
        }

        void updateVehicleplate()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Vehicles SET Plate_Number = @platenum WHERE Chassis_Number ='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@platenum", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Vehicle plate updated successfully');</script>");
                clearform();
                InvTabl.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}