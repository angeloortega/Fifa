using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clSocio
/// </summary>
[DataContract]
public class clSocio
{
    public clSocio()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoSocio { get; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public DateTime fchNacimiento { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clSocio(int codigoSocio, string nombre, DateTime fchNacimiento,
        string usuarioCreacion, string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoSocio = codigoSocio;
        this.nombre = nombre;
        this.fchNacimiento = fchNacimiento;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}