using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clContrato
/// </summary>
[DataContract]
public class clContrato
{
    public clContrato()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idClub { get; set; }
    [DataMember]
    public int codigoFuncionario { get; set; }
    [DataMember]
    public double importe { get; set; }
    [DataMember]
    public DateTime fchInicio { get; set; }
    [DataMember]
    public DateTime fchFinProgramado { get; set; }
    [DataMember]
    public DateTime fchFinReal { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clContrato(int codigoFuncionario, int idClub, double importe, DateTime fchInicio,
        DateTime fchFinProgramado, DateTime fchFinReal, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoFuncionario = codigoFuncionario;
        this.idClub = idClub;
        this.fchInicio = fchInicio;
        this.fchFinProgramado = fchFinProgramado;
        this.fchFinReal = fchFinReal;
        this.importe = importe;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}