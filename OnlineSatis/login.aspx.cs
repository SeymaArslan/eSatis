using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string baglantiYolu = ConfigurationManager.AppSettings["baglantiYolu"].ToString();

        SqlConnection baglanti = new SqlConnection(baglantiYolu);
        string sql = "select * from Users where Username=@pusername and Password=@pPassword";
        SqlCommand komut = new SqlCommand(sql, baglanti);
        komut.Parameters.AddWithValue("@pusername", TextBox1.Text);
        komut.Parameters.AddWithValue("@pPassword", TextBox2.Text);
        baglanti.Open();

        SqlDataReader kayitlar =komut.ExecuteReader();
        if (kayitlar.HasRows == true)
        {
            Session["giris"] = true;
            while (kayitlar.Read())
            {
                Session["UserID"] = kayitlar["UserID"];
                Session["isim"] = kayitlar["Adi"];
                Session["soyisim"] = kayitlar["Soyadi"];
                baglanti.Close();
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            Response.Write("Hatali giris");
        }
        baglanti.Close();
    }
}