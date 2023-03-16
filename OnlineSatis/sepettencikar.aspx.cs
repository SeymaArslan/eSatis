using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class sepettencikar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int itemNo = Convert.ToInt32(Request.Params["ItemNo"]);
        int userID = Convert.ToInt32(Session["UserID"]);
        string baglantiYolu=ConfigurationManager.AppSettings["baglantiYolu"];
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        string sql = "delete from SepetItem where ItemNo=@pitem and UserID=@puser";
        SqlCommand komut = new SqlCommand(sql, baglanti);
        komut.Parameters.AddWithValue("@pitem", itemNo);
        komut.Parameters.AddWithValue("@puser", userID);
        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();
        Response.Redirect("sepet.aspx");
    }
}