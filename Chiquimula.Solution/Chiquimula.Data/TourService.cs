using Chiquimula.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.Data
{
    public class TourService
    {
        public List<SitioDto> GetAllSitios()
        {
            var lista = new List<SitioDto>();
            var listaDom = new List<Sitio>();

            using (var db = new TourEntities())
            {
                listaDom = (from s in db.Sitio
                         select s).ToList();

                foreach (var dom in listaDom)
                {
                    var sitio = new SitioDto()
                    {
                        id = dom.id,
                        datos = dom.datos,
                        descripcion = dom.descripcion,
                        horario = dom.horario,
                        imagenId = dom.imagenId,
                        info = dom.info,
                        latitud = dom.latitud,
                        longitud = dom.longitud,
                        masdatos = dom.masdatos,
                        nombre = dom.nombre,
                        precio = dom.precio,
                        ranking = dom.ranking,
                        titulo = dom.titulo,
                        imagenes = new List<string>(),
                        videos = new List<string>()
                    };
                    //obtener las imagenes URL y videos.

                    var imagenes = (from i in db.Imagen
                                    where i.sitioId == dom.id
                                    select i).ToList();
                    imagenes.ForEach(x =>
                    {
                        sitio.imagenes.Add(x.path);
                    });

                    var videos = (from i in db.Video
                                  where i.sitioId == dom.id
                                  select i).ToList();
                    videos.ForEach(x =>
                    {
                        sitio.videos.Add(x.path);
                    });

                    lista.Add(sitio);
                }
            }
            
            return lista;
        }
     
        public RankDto Rankear(RankDto dto)
        {
            using(var db = new TourEntities())
            {
                var sitio = (from s in db.Sitio
                             where s.id == dto.SitioId
                             select s).FirstOrDefault();

                if(sitio != null)
                {
                    var rankActual = sitio.ranking;
                    var usersActual = sitio.rankingUsers + 1;
                    var rankDado = dto.Rank;

                    float newRank = Convert.ToSingle((rankActual * (usersActual - 1) + rankDado) / usersActual);
                    dto.RankingActual = newRank;

                    sitio.ranking = newRank;
                    sitio.rankingUsers = usersActual;

                    db.Entry(sitio).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
            }

            return dto;
        }   
    }
}
