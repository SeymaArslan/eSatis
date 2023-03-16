using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public DataSet UrunleriCek()
    {
        string baglantiYolu = ConfigurationManager.AppSettings["baglantiYolu"].ToString();
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        string sql = "select * from Urunler";
        SqlCommand komut = new SqlCommand(sql, baglanti);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        DataSet urunler = new DataSet();
        baglanti.Open();
        adaptor.Fill(urunler);
        baglanti.Close();
        return urunler;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }
        else 
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }

        /*DataSet kategoriler = new DataSet();
        kategoriler = KategorileriCek();
        Repeater1.DataSource = kategoriler.Tables[0];
        Repeater1.DataBind();
        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
        }*/

        DataSet urunler = new DataSet();
        urunler = UrunleriCek();
        Repeater1.DataSource = urunler.Tables[0];
        Repeater1.DataBind();
        
    }

    /*public DataSet KategorileriCek()
    {
        //string baglantiYolu = ConfigurationManager.ConnectionStrings["baglantiString"].ToString();
        string baglantiYolu = ConfigurationManager.AppSettings["baglantiYolu"].ToString();
        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        string sql = "select * from Kategoriler";
        SqlCommand komut = new SqlCommand(sql, baglanti);
        SqlDataAdapter adaptor = new SqlDataAdapter(komut);
        baglanti.Open();
        DataSet kategoriler = new DataSet();
        adaptor.Fill(kategoriler);
        baglanti.Close();
        return kategoriler;

    }*/
}