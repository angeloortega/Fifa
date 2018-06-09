using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clCompeticion
/// </summary>
[DataContract]
public class clCompeticion
{
    public clCompeticion()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idFederacion { get; set; }
    [DataMember]
    public int idCompeticion { get; set; }
    [DataMember]
    public string nbrCompeticion { get; set; }
    [DataMember]
    public Char tipo { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clCompeticion(int idFederacion, int idCompeticion, string nbrCompeticion, Char tipo, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idCompeticion = idCompeticion;
        this.nbrCompeticion = nbrCompeticion;
        this.idFederacion = idFederacion;
        this.tipo = tipo;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}