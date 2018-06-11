
using System;

namespace Fifa19.Models
{
    public class FuncionarioImg
    {
        public decimal codigoFuncionario { get; set; }
        public string nombre { get; set; }
        public System.DateTime fchNacimiento { get; set; }
        public Nullable<decimal> idClub { get; set; }
        public string foto { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public System.DateTime fchCreacion { get; set; }
        public Nullable<System.DateTime> fchModificacion { get; set; }

        public FuncionarioImg(Funcionario f){
            this.codigoFuncionario = f.codigoFuncionario;
            this.nombre = f.nombre;
            this.fchNacimiento = f.fchNacimiento;
            this.idClub = f.idClub;
            this.foto = "~/Resources/"+f.foto;
            this.usuarioCreacion = f.usuarioCreacion;
            this.usuarioModificacion = f.usuarioModificacion;
            this.fchCreacion = f.fchCreacion;
            this.fchModificacion = f.fchModificacion;
        }
    }
}