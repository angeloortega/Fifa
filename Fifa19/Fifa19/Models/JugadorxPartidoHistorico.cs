//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class JugadorxPartidoHistorico
    {
        public decimal codigoJugador { get; set; }
        public decimal idPartido { get; set; }
        public string posicion { get; set; }
        public string tipo { get; set; }
        public Nullable<decimal> desempenho { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public System.DateTime fchCreacion { get; set; }
        public Nullable<System.DateTime> fchModificacion { get; set; }
    }
}
