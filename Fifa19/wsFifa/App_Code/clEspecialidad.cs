using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clEspecialidad
/// </summary>
[DataContract]
public class clEspecialidad
{
    public clEspecialidad()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idEspecialidad { get; set; }
    [DataMember]
    public string descripcion { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }
    public clEspecialidad(int idEspecialidad, string descripcion, string usuarioCreacion, 
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idEspecialidad = idEspecialidad;
        this.descripcion = descripcion;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }

}