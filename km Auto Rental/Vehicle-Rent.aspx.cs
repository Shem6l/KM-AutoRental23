using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Reflection;

namespace km_Auto_Rental
{
    public partial class Vehicle_Rent : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        private void BindGridView()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strcon))
                {
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    string sql = "SELECT * FROM Rentals";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            GridViewRental.DataSource = reader;
                            GridViewRental.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void issue_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Rentals (AdminiID, DriversNumber, Chassis_Number, StartDate, EndDate, TotalCost, PaymentMethod) VALUES " +
                    "(@Adminid, @driversnum, @chassisnum, @startdate, @enddate, @totalcost, @paymentm)", con);

                cmd.Parameters.AddWithValue("@Adminid", Session["AdminID"]);
                cmd.Parameters.AddWithValue("@driversnum", ClID.Text.Trim());
                cmd.Parameters.AddWithValue("@chassisnum", Lnamepfl.Text.Trim());
                cmd.Parameters.AddWithValue("@startdate", UsrPfl.Text.Trim());
                cmd.Parameters.AddWithValue("@enddate", Nwpss.Text.Trim());
                cmd.Parameters.AddWithValue("@totalcost", "0");
                cmd.Parameters.AddWithValue("@paymentm", "cash");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Rent Successful.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Look1_Click(object sender, EventArgs e)
        {
            if (checkifRentalExist())
            {
                getrentalbyChassis();
            }
            else
            {
                Response.Write("<script>alert('INVALID NO INPUT');</script>");
            }
        }

        bool checkifRentalExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Rentals where Chassis_Number='" + Lnamepfl.Text.Trim() + "';", con);
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

        void getrentalbyChassis()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Rentals where Chassis_Number='" + Lnamepfl.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    ClID.Text = dt.Rows[0][2].ToString();
                    UsrPfl.Text = dt.Rows[0][4].ToString();
                    Nwpss.Text = dt.Rows[0][5].ToString();
                    //InvYear.Text = dt.Rows[0][4].ToString();
                    //RentRate.Text = dt.Rows[0][5].ToString();
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

        /*void addnewRental()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Rentals (RentalID, AdminID, DriversNumber, Chassis_Number, StartDate, EndDate, TotalCost, PaymentMethod) VALUES " +
                    "(@rid, @adminid, @dnum, @cnum, @sdate, @enddate, @tcost, @payment)", con);

               // cmd.Parameters.AddWithValue("@rid", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@platenum", TextBox2.Text);
                cmd.Parameters.AddWithValue("@make", Vmake.Text.Trim());
                cmd.Parameters.AddWithValue("@model", Model.Text.Trim());
                cmd.Parameters.AddWithValue("@year", InvYear.Text.Trim());
                cmd.Parameters.AddWithValue("@rentrate", RentRate.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                // Response.Write("<script>alert('Vehicle added to database');</script>");
                //clearform();
                //InvTabl.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }*/
    }
}
