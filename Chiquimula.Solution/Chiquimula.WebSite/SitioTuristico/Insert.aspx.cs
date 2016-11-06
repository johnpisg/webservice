using System;
using Chiquimula.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Chiquimula.WebSite.SitioTuristico
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtDesdeDom.Text = TxtDesdeLun.Text = TxtDesdeJue.Text
                    = TxtDesdeMar.Text = TxtDesdeMie.Text = TxtDesdeSab.Text
                    = TxtDesdeVie.Text = "06:00";

                TxtHastaDom.Text = TxtHastaLun.Text = TxtHastaJue.Text
                    = TxtHastaMar.Text = TxtHastaMie.Text = TxtHastaSab.Text
                    = TxtHastaVie.Text = "20:00";
            }
        }
        

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            var sitio = new Sitio();
            sitio.nombre = TxtNombre.Text;
            sitio.titulo = TxtTitulo.Text;
            sitio.descripcion = TxtDescripcion.Text;
            double prec = 0.0;
            double.TryParse(TxtPrecio.Text, out prec);
            sitio.precio = prec;
            sitio.ranking = 0;
            sitio.horario = GetHorarioString();
            sitio.datos = TxtDatos.Text;
            sitio.info = TxtInfo.Text;
            sitio.masdatos = TxtMasDatos.Text;

            string url = GuardarImagen();
            var imagen = new Imagen();
            imagen.Nombre = sitio.nombre;
            imagen.path = url;            
            
            using(var db = new TourEntities())
            {
                db.Sitio.Add(sitio);
                db.Entry(sitio).State = System.Data.EntityState.Added;
                db.SaveChanges();

                imagen.sitioId = sitio.id;
                db.Imagen.Add(imagen);
                db.Entry(imagen).State = System.Data.EntityState.Added;
                db.SaveChanges();

                sitio.imagenId = imagen.Id;
                db.Entry(sitio).State = System.Data.EntityState.Modified;
                db.SaveChanges();
            }

            Response.Redirect("~/Sitio/List.aspx", false);
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
                    var url = "~/Images/" + FileName;
                    UploadImage.SaveAs(Server.MapPath(url));
                    return url;
                }
            }
            return "";
        }

        private string GetHorarioString()
        {
            string h = "";
            if (ChkLun.Checked)
            {
                h = h + string.Format("Lunes({0}-{1})", TxtDesdeLun.Text, TxtHastaLun.Text);
                h = h + "|";
            }
            if (ChkMar.Checked)
            {
                h = h + string.Format("Martes({0}-{1})", TxtDesdeMar.Text, TxtHastaMar.Text);
                h = h + "|";
            }
            if (ChkMie.Checked)
            {
                h = h + string.Format("Miércoles({0}-{1})", TxtDesdeMie.Text, TxtHastaMie.Text);
                h = h + "|";
            }
            if (ChkJue.Checked)
            {
                h = h + string.Format("Jueves({0}-{1})", TxtDesdeJue.Text, TxtHastaJue.Text);
                h = h + "|";
            }
            if (ChkVie.Checked)
            {
                h = h + string.Format("Viernes({0}-{1})", TxtDesdeVie.Text, TxtHastaVie.Text);
                h = h + "|";
            }
            if (ChkSab.Checked)
            {
                h = h + string.Format("Sábado({0}-{1})", TxtDesdeSab.Text, TxtHastaSab.Text);
                h = h + "|";
            }
            if (ChkDom.Checked)
            {
                h = h + string.Format("Domingo({0}-{1})", TxtDesdeDom.Text, TxtHastaDom.Text);
                h = h + "|";
            }
            return h;
        }
    }
}