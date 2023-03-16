using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class sepeteAt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            string baglantiYolu = ConfigurationManager.AppSettings["baglantiYolu"].ToString();
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "insert into SepetItem values(@puserid,@purunid,@ptarih,1)";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@puserid", Convert.ToInt32(Session["UserID"]));
            int urunID = Convert.ToInt32(Request.Params["UrunID"]);
            komut.Parameters.AddWithValue("@purunid", urunID);
            komut.Parameters.AddWithValue("@ptarih", DateTime.Now.Date.Date);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            Response.Write("Sepete Eklendi");
        }
        else
        {
            Response.Redirect("login.aspx");
        }
    }
}