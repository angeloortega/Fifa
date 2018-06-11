using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fifa19.Models
{
    public class posConColores
    {
        public int posicion { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> idEquipo { get; set; }
        public Nullable<decimal> partidosJugados { get; set; }
        public Nullable<decimal> partidosGanados { get; set; }
        public Nullable<decimal> partidosEmpatados { get; set; }
        public Nullable<decimal> partidosPedridos { get; set; }
        public Nullable<decimal> golesAFavor { get; set; }
        public Nullable<decimal> golesEnContra { get; set; }
        public Nullable<decimal> puntos { get; set; }
        public string colorBG { get; set; }
        public string colorFG { get; set; }

        public posConColores(sp_generarTablaPosiciones_Result f, int pos, int totalPos)
        {
            if (pos < 4) {
                colorBG = "green";
                colorFG = "white";

            }
            else if (totalPos - pos < 4) {
                colorBG = "red";
                colorFG = "white";
            }
            else
            {
                colorBG = "#white";
                colorFG = "#balck";
            }
            this.posicion = pos;
            this.nombre = f.nombre;
            this.idEquipo = f.idEquipo;
            this.partidosJugados = f.partidosJugados;
            this.partidosGanados = f.partidosGanados;
            this.partidosEmpatados = f.partidosEmpatados;
            this.partidosPedridos = f.partidosPedridos;
            this.golesAFavor = f.golesAFavor;
            this.golesEnContra = f.golesEnContra;
            this.puntos = f.puntos;
        }
    }
}