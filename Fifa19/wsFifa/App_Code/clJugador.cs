using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clJugador
/// </summary>
[DataContract]
public class clJugador
{
    public clJugador()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoFuncionario { get; set; }
    [DataMember]
    public double Peso { get; set; }
    [DataMember]
    public double Altura { get; set; }
    [DataMember]
    public int nroCamiseta { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clJugador(int codigoFuncionario, double Peso, double Altura, int nroCamiseta,
        string usuarioCreacion, string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoFuncionario = codigoFuncionario;
        this.Peso = Peso;
        this.Altura = Altura;
        this.nroCamiseta = nroCamiseta;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}