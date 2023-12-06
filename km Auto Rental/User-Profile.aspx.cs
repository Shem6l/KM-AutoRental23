using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace km_Auto_Rental
{
    public partial class User_Profile : System.Web.UI.Page
    {
        string strcon = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
                BindGridView();
            }
        }

        private void LoadUserProfile()
        {
            try
            {
                if (Session["FirstName"] != null)
                    Fnmprl.Text = Session["FirstName"].ToString();

                if (Session["LastName"] != null)
                    Lnamepfl.Text = Session["LastName"].ToString();

                if (Session["Telephone"] != null)
                    PhnPfl.Text = Session["Telephone"].ToString();

                if (Session["Email"] != null)
                    EmlPfl.Text = Session["Email"].ToString();

                if (Session["DriverNum"] != null)
                    DLpfl.Text = Session["DriverNum"].ToString();

                if (Session["Password"] != null)
                    PassPfl.Text = Session["Password"].ToString();

                if (Session["Username"] != null)
                    UsrPfl.Text = Session["Username"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        private void BindGridView()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Rentals WHERE DriversNumber ='" + Session["DriverNum"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                


                cmd.ExecuteNonQuery();
                con.Close();
                

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}
