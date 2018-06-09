using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for clFuncionarioxClubxTorneo
/// </summary>
[DataContract]
public class clFuncionarioxClubxTorneo
{
    public clFuncionarioxClubxTorneo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    [DataMember]
    public int codigoFuncionario { get; set; }
    [DataMember]
    public int idClub { get; set; }
    [DataMember]
    public int idCompeticion { get; set; }
    [DataMember]
    public int anho { get; set; }
    [DataMember]
    public int goles { get; set; }
    [DataMember]
    public string sinopsisRendimiento { get; set; }
    [DataMember]
    public int posicionTabla { get; set; }
    [DataMember]
    public string usuarioCreacion { get; set; }
    [DataMember]
    public string usuarioModificacion { get; set; }
    [DataMember]
    public DateTime fchCreacion { get; set; }
    [DataMember]
    public DateTime fchModificacion { get; set; }

    public clFuncionarioxClubxTorneo(int codigoFuncionario, int idClub, int idCompeticion, int anho, int goles,
        string sinopsisRendimiento, int posicionTabla, string usuarioCreacion,
        string usuarioModificacion, DateTime fchCreacion, DateTime fchModificacion)
    {
        this.codigoFuncionario = codigoFuncionario;
        this.idCompeticion = idCompeticion;
        this.anho = anho;
        this.goles = goles;
        this.idClub = idClub;
        this.sinopsisRendimiento = sinopsisRendimiento;
        this.posicionTabla = posicionTabla;
        this.usuarioCreacion = usuarioCreacion;
        this.usuarioModificacion = usuarioModificacion;
        this.fchCreacion = fchCreacion;
        this.fchModificacion = fchModificacion;
    }
}