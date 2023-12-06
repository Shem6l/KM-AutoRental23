﻿using System;
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
                updateVehicle();
                Response.Write("<script>alert('Vehicle price was updated');</script>");

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
                Response.Write("<script>alert('Vehicle added to database');</script>");
                clearform();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateVehicle()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Vehicles SET RentalRate = @rentrate WHERE Chassis_Number'"+ TextBox1.Text.Trim() +"'", con);

                cmd.Parameters.AddWithValue("@rentrate", RentRate.Text.Trim());
                

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Vehicle price updated successfully');</script>");
                clearform();
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
    }
}