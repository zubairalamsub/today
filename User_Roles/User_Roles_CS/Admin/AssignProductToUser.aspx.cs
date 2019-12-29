using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace User_Login_CS.Admin
{
    public partial class AssignProductToUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT UserId, Username FROM Users Where RoleId=2"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        con.Open();
                        ddlUser.DataSource = cmd.ExecuteReader();
                        ddlUser.DataTextField = "Username";
                        ddlUser.DataValueField = "UserId";
                        ddlUser.DataBind();
                        con.Close();
                    }
                }
                ddlUser.Items.Insert(0, new ListItem("--Select Customer--", "0"));
            }
        }

        [WebMethod]
        
        public static void SaveUser(int UserId,string BrandNameEng)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Showproduct VALUES(@UserId, @BrandNameEng)"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@BrandNameEng", BrandNameEng);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
      }
 }

//public class User
//{
//    public string Username { get; set; }
//    public string Password { get; set; }
//}
