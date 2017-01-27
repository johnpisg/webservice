﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chiquimula.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class TourEntities : DbContext
    {
        public TourEntities()
            : base("name=TourEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Sitio> Sitio { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Device> Device { get; set; }
        public DbSet<SitioRanking> SitioRanking { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
    
        public virtual ObjectResult<GetSitiosMasCercanos_Result> GetSitiosMasCercanos(Nullable<double> miLatitud, Nullable<double> miLongitud, Nullable<double> kmAlaRedonda)
        {
            var miLatitudParameter = miLatitud.HasValue ?
                new ObjectParameter("miLatitud", miLatitud) :
                new ObjectParameter("miLatitud", typeof(double));
    
            var miLongitudParameter = miLongitud.HasValue ?
                new ObjectParameter("miLongitud", miLongitud) :
                new ObjectParameter("miLongitud", typeof(double));
    
            var kmAlaRedondaParameter = kmAlaRedonda.HasValue ?
                new ObjectParameter("kmAlaRedonda", kmAlaRedonda) :
                new ObjectParameter("kmAlaRedonda", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSitiosMasCercanos_Result>("GetSitiosMasCercanos", miLatitudParameter, miLongitudParameter, kmAlaRedondaParameter);
        }
    }
}
