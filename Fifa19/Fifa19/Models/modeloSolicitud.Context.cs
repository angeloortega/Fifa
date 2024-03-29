﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fifa19.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class FootballEntities : DbContext
    {
        public FootballEntities()
            : base("name=FootballEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Arbitro> Arbitro { get; set; }
        public virtual DbSet<ArbitroxPartido> ArbitroxPartido { get; set; }
        public virtual DbSet<ArbitroxPartidoHistorico> ArbitroxPartidoHistorico { get; set; }
        public virtual DbSet<CambioxPartido> CambioxPartido { get; set; }
        public virtual DbSet<CambioxPartidoHistorico> CambioxPartidoHistorico { get; set; }
        public virtual DbSet<Club> Club { get; set; }
        public virtual DbSet<Competicion> Competicion { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<CorreoxFuncionario> CorreoxFuncionario { get; set; }
        public virtual DbSet<DireccionxFuncionario> DireccionxFuncionario { get; set; }
        public virtual DbSet<Entrenador> Entrenador { get; set; }
        public virtual DbSet<Especialidad> Especialidad { get; set; }
        public virtual DbSet<EspecialidadxJugador> EspecialidadxJugador { get; set; }
        public virtual DbSet<FechaTorneo> FechaTorneo { get; set; }
        public virtual DbSet<FechaTorneoHistorico> FechaTorneoHistorico { get; set; }
        public virtual DbSet<Federacion> Federacion { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<FuncionarioXClubXTorneo> FuncionarioXClubXTorneo { get; set; }
        public virtual DbSet<FuncionarioXClubXTorneoHistorico> FuncionarioXClubXTorneoHistorico { get; set; }
        public virtual DbSet<GolxPartido> GolxPartido { get; set; }
        public virtual DbSet<GolxPartidoHistorico> GolxPartidoHistorico { get; set; }
        public virtual DbSet<Jugador> Jugador { get; set; }
        public virtual DbSet<JugadorxPartido> JugadorxPartido { get; set; }
        public virtual DbSet<JugadorxPartidoHistorico> JugadorxPartidoHistorico { get; set; }
        public virtual DbSet<Oferta> Oferta { get; set; }
        public virtual DbSet<Partido> Partido { get; set; }
        public virtual DbSet<PartidoHistorico> PartidoHistorico { get; set; }
        public virtual DbSet<Socio> Socio { get; set; }
        public virtual DbSet<SocioxClub> SocioxClub { get; set; }
        public virtual DbSet<TelefonoxFuncionario> TelefonoxFuncionario { get; set; }
        public virtual DbSet<TituloxEntrenador> TituloxEntrenador { get; set; }
        public virtual DbSet<Torneo> Torneo { get; set; }
        public virtual DbSet<TorneoHistorico> TorneoHistorico { get; set; }
        public virtual DbSet<TorneoXClub> TorneoXClub { get; set; }
        public virtual DbSet<TorneoXClubHistorico> TorneoXClubHistorico { get; set; }
        public virtual DbSet<Imagenes> Imagenes { get; set; }
    
        public virtual ObjectResult<sp_generarTablaPosiciones_Result> sp_generarTablaPosiciones(Nullable<decimal> idCampeonato, Nullable<decimal> anho)
        {
            var idCampeonatoParameter = idCampeonato.HasValue ?
                new ObjectParameter("idCampeonato", idCampeonato) :
                new ObjectParameter("idCampeonato", typeof(decimal));
    
            var anhoParameter = anho.HasValue ?
                new ObjectParameter("anho", anho) :
                new ObjectParameter("anho", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_generarTablaPosiciones_Result>("sp_generarTablaPosiciones", idCampeonatoParameter, anhoParameter);
        }
    
        public virtual ObjectResult<sp_desempenhoArbitroTorneo_Result> sp_desempenhoArbitroTorneo(Nullable<decimal> idCampeonato, Nullable<decimal> anho)
        {
            var idCampeonatoParameter = idCampeonato.HasValue ?
                new ObjectParameter("idCampeonato", idCampeonato) :
                new ObjectParameter("idCampeonato", typeof(decimal));
    
            var anhoParameter = anho.HasValue ?
                new ObjectParameter("anho", anho) :
                new ObjectParameter("anho", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_desempenhoArbitroTorneo_Result>("sp_desempenhoArbitroTorneo", idCampeonatoParameter, anhoParameter);
        }
    
        public virtual ObjectResult<sp_obtenerEncuentrosHistoricos_Result> sp_obtenerEncuentrosHistoricos(Nullable<decimal> equipo1, Nullable<decimal> equipo2, Nullable<System.DateTime> fechaInicio)
        {
            var equipo1Parameter = equipo1.HasValue ?
                new ObjectParameter("equipo1", equipo1) :
                new ObjectParameter("equipo1", typeof(decimal));
    
            var equipo2Parameter = equipo2.HasValue ?
                new ObjectParameter("equipo2", equipo2) :
                new ObjectParameter("equipo2", typeof(decimal));
    
            var fechaInicioParameter = fechaInicio.HasValue ?
                new ObjectParameter("fechaInicio", fechaInicio) :
                new ObjectParameter("fechaInicio", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerEncuentrosHistoricos_Result>("sp_obtenerEncuentrosHistoricos", equipo1Parameter, equipo2Parameter, fechaInicioParameter);
        }
    
        public virtual ObjectResult<sp_obtenerListaEquiposEntrenador_Result> sp_obtenerListaEquiposEntrenador(Nullable<decimal> codigoFuncionario)
        {
            var codigoFuncionarioParameter = codigoFuncionario.HasValue ?
                new ObjectParameter("codigoFuncionario", codigoFuncionario) :
                new ObjectParameter("codigoFuncionario", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerListaEquiposEntrenador_Result>("sp_obtenerListaEquiposEntrenador", codigoFuncionarioParameter);
        }
    
        public virtual ObjectResult<sp_obtenerListaEquiposJugador_Result> sp_obtenerListaEquiposJugador(Nullable<decimal> codigoFuncionario)
        {
            var codigoFuncionarioParameter = codigoFuncionario.HasValue ?
                new ObjectParameter("codigoFuncionario", codigoFuncionario) :
                new ObjectParameter("codigoFuncionario", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_obtenerListaEquiposJugador_Result>("sp_obtenerListaEquiposJugador", codigoFuncionarioParameter);
        }
    
        public virtual int sp_simulacion(Nullable<decimal> idCompetencia, Nullable<decimal> anho)
        {
            var idCompetenciaParameter = idCompetencia.HasValue ?
                new ObjectParameter("idCompetencia", idCompetencia) :
                new ObjectParameter("idCompetencia", typeof(decimal));
    
            var anhoParameter = anho.HasValue ?
                new ObjectParameter("anho", anho) :
                new ObjectParameter("anho", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_simulacion", idCompetenciaParameter, anhoParameter);
        }
    
        public virtual int sorteoTabla(Nullable<decimal> idCampeonato, Nullable<decimal> anho, Nullable<System.DateTime> fchInicio)
        {
            var idCampeonatoParameter = idCampeonato.HasValue ?
                new ObjectParameter("idCampeonato", idCampeonato) :
                new ObjectParameter("idCampeonato", typeof(decimal));
    
            var anhoParameter = anho.HasValue ?
                new ObjectParameter("anho", anho) :
                new ObjectParameter("anho", typeof(decimal));
    
            var fchInicioParameter = fchInicio.HasValue ?
                new ObjectParameter("fchInicio", fchInicio) :
                new ObjectParameter("fchInicio", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sorteoTabla", idCampeonatoParameter, anhoParameter, fchInicioParameter);
        }
    }
}
