using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Sepet : System.Web.UI.Page
{
    public int ToplamDonder(int UserID)
    {
    string baglantiYolu=ConfigurationManager.AppSettings["baglantiYolu"];
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select sum(Adet*fiyati) as toplam from SepetItem inner join Urunler on SepetItem.UrunID=Urunler.UrunID where UserID=@puserid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@puserid", UserID);
            baglanti.Open();
            SqlDataReader sonuc = komut.ExecuteReader();
            int toplam = 0;
        while(sonuc.Read())
        {
            toplam = Convert.ToInt32(sonuc["toplam"]);
        }
        baglanti.Close();
        return toplam;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Convert.ToBoolean(Session["giris"]) == true)
        {
            //sepetitemdan select ile veri cek
            string baglantiYolu=ConfigurationManager.AppSettings["baglantiYolu"];
            SqlConnection baglanti = new SqlConnection(baglantiYolu);
            string sql = "select ItemNo,UrunAdi, Adet, Fiyati, tarih from SepetItem inner join Urunler on Urunler.UrunID=SepetItem.UrunID where UserID=@puserid";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@puserid", Convert.ToInt32(Session["UserID"]));
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            DataSet sepettekiler = new DataSet();
            baglanti.Open();
            adaptor.Fill(sepettekiler);
            baglanti.Close();
            GridView1.DataSource = sepettekiler.Tables[0];
            GridView1.DataBind();

        }
        else 
        {
            Response.Redirect("login.aspx");
        }

        Label1.Text = ToplamDonder(Convert.ToInt32(Session["UserID"])).ToString();
    }
}