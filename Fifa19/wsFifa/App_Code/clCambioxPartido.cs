using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clCambioxPartido
/// </summary>
[DataContract]
public class clCambioxPartido
{
    public clCambioxPartido()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoJugadorEntra { get; set; }
    [DataMember]
    public int codigoJugadorSale { get; set; }
    [DataMember]
    public int idPartido { get; set; }
    [DataMember]
    public int minuto { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clCambioxPartido(int codigoJugadorEntra, int codigoJugadorSale, int idPartido, int minuto, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoJugadorEntra = codigoJugadorEntra;
        this.codigoJugadorSale = codigoJugadorSale;
        this.idPartido = idPartido;
        this.minuto = minuto;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}