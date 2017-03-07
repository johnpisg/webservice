using Chiquimula.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chiquimula.WebSite.SitioTuristico
{
    public partial class AddVideo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarVideos();
            }
        }

        private void MostrarVideos()
        {
            //obtener las imagenes del sitio
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var lista = new List<Video>();
            using (var db = new TourEntities())
            {
                var sitio = (from s in db.Sitio
                             where s.id == id
                             select s).FirstOrDefault();
                LblTitulo.Text = "Videos del sitio: [" + sitio.nombre + "]";

                lista = (from i in db.Video
                         where i.sitioId == id
                         select i).ToList();
            }
            RepeaterVideos.DataSource = lista;
            RepeaterVideos.DataBind();
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            using (var db = new TourEntities())
            {
                var sitio = (from s in db.Sitio
                             where s.id == id
                             select s).FirstOrDefault();

                if (sitio != null)
                {
                    string url = GuardarVideo();
                    var video = new Video();
                    video.Nombre = sitio.nombre;
                    video.path = url;

                    video.sitioId = sitio.id;
                    db.Video.Add(video);
                    db.Entry(video).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }
            }

            MostrarVideos();
        }

        private string GuardarVideo()
        {
            if (!string.IsNullOrEmpty(HdnUrl.Value))
            {
                string url = HdnUrl.Value;
                if (url.ToLower().Contains("www.youtube.com/embed/"))
                {
                    return url;
                }
            }
            return "";
        }

        protected void LnkEliminar_Command(object sender, CommandEventArgs e)
        {
            var id = Convert.ToInt32(e.CommandArgument);
            try
            {
                using (var db = new TourEntities())
                {
                    var video = (from i in db.Video
                                 where i.Id == id
                                 select i).FirstOrDefault();
                    if (video != null)
                    {
                        db.Video.Remove(video);
                        db.Entry(video).State = System.Data.EntityState.Deleted;
                        db.SaveChanges();
                    }
                }

                MostrarVideos();
            }
            catch
            {

            }
        }
    }
}