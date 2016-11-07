using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.UI.WebControls;

namespace Chiquimula.WebSite
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected override void OnInit(EventArgs e)
        {
            Page.Header.DataBind();
        }

        protected void LnkLogout_Click(object sender, EventArgs e)
        {
            Session["Ux"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}
