using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clFederacion
/// </summary>
[DataContract]
public class clFederacion
{
    public clFederacion()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idFederacion { get; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public DateTime fchFundacion { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clFederacion(int idFederacion, string nombre, DateTime fchFundacion, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idFederacion = idFederacion;
        this.nombre = nombre;
        this.fchFundacion = fchFundacion;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }   
}