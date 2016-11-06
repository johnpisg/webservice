using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;

namespace Chiquimula.WebSite
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var visibleTables = Global.DefaultModel.VisibleTables;
            if (visibleTables.Count == 0)
            {
                throw new InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
            }

            visibleTables = visibleTables.Where(t => t.DisplayName != "Imagen"
                                                        && t.DisplayName != "Video")
                                                        .ToList();

            Menu1.DataSource = visibleTables;
            Menu1.DataBind();
        }

        public string GetUrlMenu(string tableName)
        {
            return ResolveUrl("~/" + tableName + "/List.aspx");
        }

        public string GetTableAlias(string tableName)
        {
            switch (tableName)
            {
                case "Sitio": return "Sitio turístico";                
            }

            return tableName;
        }

    }
}
