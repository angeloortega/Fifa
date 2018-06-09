using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clSocioxClub
/// </summary>
[DataContract]
public class clSocioxClub
{
    public clSocioxClub()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoSocio { get; set; }
    [DataMember]
    public int idClub { get; set; }
    [DataMember]
    public Char tipo { get; set; }
    [DataMember]
    public DateTime fchAsociacion { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clSocioxClub(int codigoSocio, int idClub, DateTime fchAsociacion, Char tipo,
        string usuarioCreacion, string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoSocio = codigoSocio;
        this.idClub = idClub;
        this.tipo = tipo;
        this.fchAsociacion = fchAsociacion;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}