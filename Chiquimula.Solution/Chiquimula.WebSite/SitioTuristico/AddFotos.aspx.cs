using Chiquimula.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Chiquimula.WebSite.SitioTuristico
{
    public partial class AddFotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarImagenes();
            }
        }

        private void MostrarImagenes()
        {
            //obtener las imagenes del sitio
            int id = Convert.ToInt32(Request.QueryString["id"]);
            var lista = new List<Imagen>();
            using (var db = new TourEntities())
            {
                var sitio = (from s in db.Sitio
                             where s.id == id
                             select s).FirstOrDefault();
                LblTitulo.Text = "Imágenes del sitio: [" + sitio.nombre + "]";

                lista = (from i in db.Imagen
                         where i.sitioId == id
                         select i).ToList();
            }
            RepeaterImages.DataSource = lista;
            RepeaterImages.DataBind();
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
                    string url = GuardarImagen();
                    var imagen = new Imagen();
                    imagen.Nombre = sitio.nombre;
                    imagen.path = url;

                    imagen.sitioId = sitio.id;
                    db.Imagen.Add(imagen);
                    db.Entry(imagen).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }
            }

            MostrarImagenes();
        }

        private string GuardarImagen()
        {
            if (UploadImage.PostedFile != null)
            {
                string fileExt = Path.GetExtension(UploadImage.FileName);
                if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".png")
                {
                    string FileName = Path.GetFileName(UploadImage.PostedFile.FileName);
                    //Save files to disk
                    var url = "~/Images/" + DateTime.Now.Ticks + "_" + FileName;
                    UploadImage.SaveAs(Server.MapPath(url));
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
                    var img = (from i in db.Imagen
                               where i.Id == id
                               select i).FirstOrDefault();
                    if(img!= null)
                    {
                        db.Imagen.Remove(img);
                        db.Entry(img).State = System.Data.EntityState.Deleted;
                        db.SaveChanges();
                    }
                }

                MostrarImagenes();
            }
            catch
            {

            }
        }
    }
}