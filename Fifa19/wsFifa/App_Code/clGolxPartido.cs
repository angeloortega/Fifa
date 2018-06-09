using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clGolxPartido
/// </summary>
[DataContract]
public class clGolxPartido
{
    public clGolxPartido()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoJugador { get; set; }
    [DataMember]
    public int idPartido { get; set; }
    [DataMember]
    public int minuto { get; set; }
    [DataMember]
    public int segundo { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clGolxPartido(int codigoJugador, int idPartido, int minuto, int segundo, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoJugador = codigoJugador;
        this.idPartido = idPartido;
        this.minuto = minuto;
        this.segundo = segundo;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}