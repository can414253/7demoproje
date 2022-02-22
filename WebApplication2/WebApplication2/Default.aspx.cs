using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select Ad from Kullanicilar", "Server=DESKTOP-N3VPKFS\\SQLEXPRESS; Database=MVC; trusted_connection=true");
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=DESKTOP-N3VPKFS\\SQLEXPRESS; Database=MVC; trusted_connection=true");
            SqlCommand cmd = new SqlCommand("select Ad from Kullanicilar where Ad=@Ad and Sifre=@Sifre", con);
            cmd.Parameters.AddWithValue("@Ad", TextBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", TextBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Redirect("Webform1.aspx");
            }
            else
            {
                Response.Write("Kullanıcı adı veya şifre hatalı.");
            }
            con.Close();
        }
    }
}