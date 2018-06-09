using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clTituloxEntrenador
/// </summary>
[DataContract]
public class clTituloxEntrenador
{
    public clTituloxEntrenador()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoEntrenador { get; set; }
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

    public clTituloxEntrenador(int codigoEntrenador, int idCompeticion, int anho, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoEntrenador = codigoEntrenador;
        this.idCompeticion = idCompeticion;
        this.anho = anho;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}