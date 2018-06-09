using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


/// <summary>
/// Summary description for clEspecialidadxJugador
/// </summary>
[DataContract]
public class clEspecialidadxJugador
{
    public clEspecialidadxJugador()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idJugador { get; set; }
    [DataMember]
    public int idEspecialidad { get; set; }
    [DataMember]
    public string descripcionDominio { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }
    public clEspecialidadxJugador(int idJugador, int idEspecialidad, string descripcionDominio, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idJugador = idJugador;
        this.idEspecialidad = idEspecialidad;
        this.descripcionDominio = descripcionDominio;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}