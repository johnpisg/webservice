using Chiquimula.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chiquimula.WebSite
{
    public partial class Login : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            Page.Header.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Ux"] = null;
            }
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = null;
            using(var db = new TourEntities())
            {
               user = (from u in db.Usuario
                            where u.Usuario1.ToLower() == TxtUsername.Text.ToLower()
                            select u).FirstOrDefault();
            }

            if(user == null)
            {
                PanelError.Visible = true;
            }else
            {
                var pass = Crypto.Decrypt(user.Password);
                if(pass == TxtPassword.Text)
                {
                    Session["Ux"] = TxtUsername.Text;
                    Response.Redirect("Default.aspx", false);
                }else
                {
                    PanelError.Visible = true;
                }
            }
        }
    }
}