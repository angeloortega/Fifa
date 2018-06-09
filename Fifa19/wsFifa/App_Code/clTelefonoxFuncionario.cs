using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clTelefonoxFuncionario
/// </summary>
[DataContract]
public class clTelefonoxFuncionario
{
    public clTelefonoxFuncionario()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoFuncionario { get; set; }
    [DataMember]
    public int Telefono { get; set; }
    [DataMember]
    public Char tipo { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clTelefonoxFuncionario(int codigoFuncionario, int Telefono, Char tipo, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoFuncionario = codigoFuncionario;
        this.Telefono = Telefono;
        this.tipo = tipo;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}