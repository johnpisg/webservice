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
    public partial class Edit : System.Web.UI.Page
    {
        public int SitioID
        {
            get { return Convert.ToInt32(Request.QueryString["id"]); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarInformacion(Convert.ToInt32(Request.QueryString["id"]));
            }

            LnkMasFotos.NavigateUrl = "~/SitioTuristico/AddFotos.aspx?id=" + SitioID;
        }

        private void MostrarInformacion(int id)
        {
            HdnSitioId.Value = "" + id;
            Sitio sitio = null;
            Imagen imagen = null;
            using(var db = new TourEntities())
            {
                sitio = (from s in db.Sitio
                         where s.id == id
                         select s).FirstOrDefault();

                if(sitio != null && sitio.imagenId != null)
                {
                    imagen = (from i in db.Imagen
                              where i.Id == sitio.imagenId
                              select i).FirstOrDefault();
                }
            }

            if (sitio != null)
            {
                TxtNombre.Text = sitio.nombre;
                TxtDatos.Text = sitio.datos;
                TxtDescripcion.Text = sitio.descripcion;
                TxtInfo.Text = sitio.info;
                TxtMasDatos.Text = sitio.masdatos;
                TxtPrecio.Text = sitio.precio.ToString();

                TxtLongitud.Text = sitio.longitud.ToString("0.000000");
                TxtLatitud.Text = sitio.latitud.ToString("0.000000");
                

                TxtTitulo.Text = sitio.titulo;
                if (sitio.horario != null)
                    ShowHorario(sitio.horario);

                if (imagen != null)
                {
                    ImagenPrincipal.ImageUrl = ResolveUrl(imagen.path);
                    ImagenPrincipal.ToolTip = imagen.Nombre;
                }

            } else
            {
                throw new KeyNotFoundException("Sitio no econtrado");
            }
        }

        private void ShowHorario(string horario)
        {
            //Jueves(06:00-20:00)|Viernes(06:00-20:00)|Sábado(06:00-20:00)|Domingo(06:00-20:00)|
            string [] dias = horario.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach(var dia in dias)
            {
                if(MostrarSiEsDia(dia, "Lunes", TxtDesdeLun, TxtHastaLun, ChkLun))
                {
                }
                else if(MostrarSiEsDia(dia, "Martes", TxtDesdeMar, TxtHastaMar, ChkMar))
                {
                }
                else if (MostrarSiEsDia(dia, "Miércoles", TxtDesdeMie, TxtHastaMie, ChkMie))
                {
                }
                else if (MostrarSiEsDia(dia, "Jueves", TxtDesdeJue, TxtHastaJue, ChkJue))
                {
                }
                else if (MostrarSiEsDia(dia, "Viernes", TxtDesdeVie, TxtHastaVie, ChkVie))
                {
                }
                else if (MostrarSiEsDia(dia, "Sábado", TxtDesdeSab, TxtHastaSab, ChkSab))
                {
                }
                else if (MostrarSiEsDia(dia, "Domingo", TxtDesdeDom, TxtHastaDom, ChkDom))
                {
                }
            }
        }

        private bool MostrarSiEsDia(string dia, string nombreDia, TextBox desde, TextBox hasta, CheckBox chk)
        {
            if (dia.Contains(nombreDia))
            {
                chk.Checked = true;
                var horas = dia.Replace(nombreDia, "").Replace("(", "").Replace(")", "");
                var hdh = horas.Split("-".ToCharArray());
                desde.Text = hdh[0];
                hasta.Text = hdh[1];
                return true;
            }
            return false;
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            var sitio = new Sitio();
            int id = Convert.ToInt32(HdnSitioId.Value);
            
            using (var db = new TourEntities())
            {
                sitio = (from s in db.Sitio
                            where s.id == id
                            select s).FirstOrDefault();

                if (sitio != null)
                {
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

                    sitio.longitud = Helper.ConvertToDecimal(TxtLongitud.Text);
                    sitio.latitud = Helper.ConvertToDecimal(TxtLatitud.Text);

                    if (HdnCambio.Value == "1")
                    {
                        string url = GuardarImagen();
                        var imagen = new Imagen();
                        imagen.Nombre = sitio.nombre;
                        imagen.path = url;

                        imagen.sitioId = sitio.id;
                        db.Imagen.Add(imagen);
                        db.Entry(imagen).State = System.Data.EntityState.Added;
                        db.SaveChanges();

                        sitio.imagenId = imagen.Id;
                    }
                    
                    db.Entry(sitio).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }                
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
                    var url = "~/Images/" + DateTime.Now.Ticks + "_" + FileName;
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