using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace km_Auto_Rental
{
    public partial class User_Profile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           Fnmprl.Text = Session["FirstName"].ToString();
           Lnamepfl.Text = Session["LastName"].ToString();
           Fnmprl.Text = Session["FirstName"].ToString();
           Fnmprl.Text = Session["FirstName"].ToString();
        }
    }
}