using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clClub
/// </summary>
[DataContract]
public class clClub
{
    public clClub()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idClub { get; set; }
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

    public clClub(int idClub, int idFederacion, string nombre, DateTime fchFundacion, 
        string usuarioCreacion, string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idClub = idClub;
        this.idFederacion = idFederacion;
        this.nombre = nombre;
        this.fchFundacion = fchFundacion;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}