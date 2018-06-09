using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clArbitro
/// </summary>
[DataContract]
public class clArbitro
{
    public clArbitro()
    {
    }

    [DataMember]
    public int idArbitro { get; set; }
    [DataMember]
    public string categoria { get; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clArbitro(int idArbitro, string categoria, string nombre,
        string usuarioCreacion, string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idArbitro = idArbitro;
        this.categoria = categoria;
        this.nombre = nombre;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}