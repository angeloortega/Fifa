using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clPartido
/// </summary>
[DataContract]
public class clPartido
{
    public clPartido()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idPartido { get; set; }
    [DataMember]
    public int idCompeticion { get; set; }
    [DataMember]
    public int anho { get; set; }
    [DataMember]
    public int nroFecha { get; set; }
    [DataMember]
    public int equipoVisita { get; set; }
    [DataMember]
    public int equipoCasa { get; set; }
    [DataMember]
    public DateTime fecha { get; set; }
    [DataMember]
    public int golesCasa { get; set; }
    [DataMember]
    public int golesVisita { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clPartido(int idPartido, int idCompeticion, int anho, int nroFecha,
        int equipoVisita, int equipoCasa, int golesCasa, int golesVisita, DateTime fecha, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idPartido = idPartido;
        this.idCompeticion = idCompeticion;
        this.anho = anho;
        this.nroFecha = nroFecha;
        this.equipoVisita = equipoVisita;
        this.equipoCasa = equipoCasa;
        this.golesCasa = golesCasa;
        this.golesVisita = golesVisita;
        this.fecha = fecha;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}