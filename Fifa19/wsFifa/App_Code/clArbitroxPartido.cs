using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clArbitroxPartido
/// </summary>
[DataContract]
public class clArbitroxPartido
{
    public clArbitroxPartido()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int idArbitro { get; set; }
    [DataMember]
    public int idPartido { get; set; }
    [DataMember]
    public Char tipo { get; set; }
    [DataMember]
    public int desempenho { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clArbitroxPartido(int idArbitro, int idPartido, Char tipo, int desempenho,
        string usuarioCreacion, string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.idArbitro = idArbitro;
        this.idPartido = idPartido;
        this.tipo = tipo;
        this.desempenho = desempenho;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}