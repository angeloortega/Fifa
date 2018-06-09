using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clTorneoxClub
/// </summary>
[DataContract]
public class clTorneoxClub
{
    public clTorneoxClub()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idClub { get; set; }
    [DataMember]
    public int idCompeticion { get; set; }
    [DataMember]
    public int anho { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clTorneoxClub(int idClub, int idCompeticion, int anho, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idCompeticion = idCompeticion;
        this.anho = anho;
        this.idClub = idClub;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}