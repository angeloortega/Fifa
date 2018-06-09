using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clDireccionxFuncionario
/// </summary>
[DataContract]
public class clDireccionxFuncionario
{
    public clDireccionxFuncionario()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoFuncionario { get; set; }
    [DataMember]
    public int codigoDireccion { get; set; }
    [DataMember]
    public string Pais { get; set; }
    [DataMember]
    public string estado { get; set; }
    [DataMember]
    public string ciudad { get; set; }
    [DataMember]
    public string distrito { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clDireccionxFuncionario(int codigoFuncionario, int codigoDireccion, string Pais,
        string estado, string ciudad, string distrito, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoFuncionario = codigoFuncionario;
        this.codigoDireccion = codigoDireccion;
        this.Pais = Pais;
        this.estado = estado;
        this.ciudad = ciudad;
        this.distrito = distrito;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}