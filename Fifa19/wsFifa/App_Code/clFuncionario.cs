using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clFuncionario
/// </summary>
[DataContract]
public class clFuncionario
{
    public clFuncionario()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoFuncionario { get; set; }
    [DataMember]
    public string nombre { get; set; }
    [DataMember]
    public DateTime fchNacimiento { get; set; }
    [DataMember]
    public int idClub { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clFuncionario(int codigoFuncionario, string nombre, DateTime fchNacimiento, int idClub, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoFuncionario = codigoFuncionario;
        this.nombre = nombre;
        this.fchNacimiento = fchNacimiento;
        this.idClub = idClub;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}