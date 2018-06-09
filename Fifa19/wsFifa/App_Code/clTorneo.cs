using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clTorneo
/// </summary>
[DataContract]
public class clTorneo
{
    public clTorneo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int anho { get; set; }
    [DataMember]
    public int idCompeticion { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clTorneo(int anho, int idCompeticion, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idCompeticion = idCompeticion;
        this.anho = anho;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}