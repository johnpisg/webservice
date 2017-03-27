using Chiquimula.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chiquimula.Data
{
    public class TourService
    {
        public List<SitioDto> GetAllSitios(string deviceUniqueId)
        {
            var lista = new List<SitioDto>();
            var listaDom = new List<Sitio>();

            using (var db = new TourEntities())
            {
                listaDom = (from s in db.Sitio
                         select s).ToList();

                foreach (var dom in listaDom)
                {
                    bool rankeadoYa = false;
                    if (!string.IsNullOrWhiteSpace(deviceUniqueId))
                    {
                        rankeadoYa = (from r in db.SitioRanking
                                      where r.deviceUniqueId == deviceUniqueId
                                      && r.sitioId == dom.id
                                      select r.id)
                                      .Count() > 0;
                    }

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
                        videos = new List<string>(),
                        rankear = !rankeadoYa
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

        public List<SitioDto> GetTopSitios(string deviceUniqueId, int number)
        {
            var lista = new List<SitioDto>();
            var listaDom = new List<Sitio>();

            using (var db = new TourEntities())
            {
                listaDom = (from s in db.Sitio
                            orderby s.ranking descending
                            select s)
                            .Take(number)
                            .ToList();

                foreach (var dom in listaDom)
                {
                    bool rankeadoYa = false;
                    if (!string.IsNullOrWhiteSpace(deviceUniqueId))
                    {
                        rankeadoYa = (from r in db.SitioRanking
                                      where r.deviceUniqueId == deviceUniqueId
                                      && r.sitioId == dom.id
                                      select r.id)
                                      .Count() > 0;
                    }

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
                        videos = new List<string>(),
                        rankear = !rankeadoYa
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

        public SitioDto GetSitioById(string deviceUniqueId, int sitioId)
        {
            SitioDto sitio = null;
            Sitio dom = null;

            using (var db = new TourEntities())
            {
                dom = (from s in db.Sitio
                            where s.id == sitioId
                            select s)
                            .FirstOrDefault();

                if(dom != null)
                {
                    bool rankeadoYa = false;
                    if (!string.IsNullOrWhiteSpace(deviceUniqueId))
                    {
                        rankeadoYa = (from r in db.SitioRanking
                                      where r.deviceUniqueId == deviceUniqueId
                                      && r.sitioId == sitioId
                                      select r.id)
                                      .Count() > 0;
                    }

                    sitio = new SitioDto()
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
                        videos = new List<string>(),
                        rankear = !rankeadoYa
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
                }
            }

            return sitio;
        }

        public RankDto Rankear(RankDto dto)
        {
            using(var db = new TourEntities())
            {
                var sitio = (from s in db.Sitio
                             where s.id == dto.SitioId
                             select s).FirstOrDefault();

                if (sitio != null)
                {
                    var rankActual = sitio.ranking;
                    var usersActual = sitio.rankingUsers + 1;
                    var rankDado = dto.Rank;

                    var querySumaRankings = (from r in db.SitioRanking
                                        where r.sitioId == dto.SitioId
                                        select r.ranking);

                    var cantidadActual = querySumaRankings.Count();
                    var sumaActual = 0;
                    if(cantidadActual > 0)
                    {
                        sumaActual = querySumaRankings.Sum();
                    }                    

                    //float newRank = Convert.ToSingle((rankActual * (usersActual - 1) + rankDado) / usersActual);
                    float newRank = (sumaActual + rankDado) / (cantidadActual + 1);
                    dto.RankingActual = newRank;
                    sitio.ranking = newRank;
                    sitio.rankingUsers = cantidadActual + 1;

                    db.Entry(sitio).State = System.Data.EntityState.Modified;
                    db.SaveChanges();

                    //SitioRanking
                    SitioRanking ranking = new SitioRanking();
                    ranking.deviceUniqueId = dto.DeviceId;
                    ranking.ranking = rankDado;
                    ranking.sitioId = sitio.id;

                    db.SitioRanking.Add(ranking);
                    db.Entry(ranking).State = System.Data.EntityState.Added;
                    db.SaveChanges();
                }
            }

            return dto;
        }

        public bool Comentar(ComentarioDto dto)
        {
            using (var db = new TourEntities())
            {
                var dom = new Comentario();
                dom.deviceUniqueId = dto.deviceUniqueId;
                dom.fecha = DateTime.Now;
                dom.sitioId = dto.sitioId;
                dom.Texto = dto.Texto;
                dom.Usuario = dto.Usuario;

                db.Comentario.Add(dom);
                db.Entry(dom).State = System.Data.EntityState.Added;
                db.SaveChanges();

            }

            return true;
        }

        public List<GeoSitioDto> GetSitiosCercanos(string deviceUniqueId, float latitud, float longitud, float distanciaKM)
        {
            List<GeoSitioDto> resultado = new List<GeoSitioDto>();
            using (var db = new TourEntities())
            {
                var lista = db.GetSitiosMasCercanos(Convert.ToDouble(latitud),
                    Convert.ToDouble(longitud),
                    Convert.ToDouble(distanciaKM)).ToList();

                foreach(var dom in lista)
                {
                    bool rankeadoYa = false;
                    if (!string.IsNullOrWhiteSpace(deviceUniqueId))
                    {
                        rankeadoYa = (from r in db.SitioRanking
                                      where r.deviceUniqueId == deviceUniqueId
                                      && r.sitioId == dom.id
                                      select r.id)
                                      .Count() > 0;
                    }

                    var sitio = new GeoSitioDto()
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
                        videos = new List<string>(),
                        rankear = !rankeadoYa,
                        DistanciaKm = Convert.ToDecimal(dom.distanciaKm.Value)
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

                    resultado.Add(sitio);
                    
                }
            }
            return resultado;
        }

        public SitioVideosDto GetVideosUrlBySitioId(int sitioId)
        {
            SitioVideosDto dto = new SitioVideosDto();
            List<string> resultado = new List<string>();
            using (var db = new TourEntities())
            {
                var sitio = (from s in db.Sitio
                             where s.id == sitioId
                             select s).FirstOrDefault();
                dto.SitioId = sitioId;
                dto.SitioTitulo = sitio.titulo;

                var query = from v in db.Video
                            where v.sitioId == sitioId
                            select v.path;
                resultado = query.ToList();
                dto.Videos = resultado;
            }
            return dto;
        }

        public List<ComentarioDto> GetComentariosSitios(int sitioId, int maximo = 30)
        {
            List<ComentarioDto> res = new List<ComentarioDto>();
            using (var db = new TourEntities())
            {
                var query = from c in db.Comentario
                            where c.sitioId == sitioId
                            orderby c.fecha descending
                            select c;
                var lista = query.Take(maximo).ToList();
                foreach(var dom in lista)
                {
                    var com = new ComentarioDto();
                    com.deviceUniqueId = dom.deviceUniqueId;
                    com.fecha = dom.fecha;
                    com.Id = dom.Id;
                    com.sitioId = dom.sitioId;
                    com.Texto = dom.Texto;
                    com.Usuario = dom.Usuario;

                    res.Add(com);
                }
            }
            return res;
        }
    }
}
