//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fifa19.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Entrenador
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entrenador()
        {
            this.TituloxEntrenador = new HashSet<TituloxEntrenador>();
        }
    
        public decimal codigoFuncionario { get; set; }
        public string nombre { get; set; }
        public System.DateTime fchInicioCarrera { get; set; }
        public string usuarioCreacion { get; set; }
        public string usuarioModificacion { get; set; }
        public System.DateTime fchCreacion { get; set; }
        public Nullable<System.DateTime> fchModificacion { get; set; }
    
        public virtual Funcionario Funcionario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TituloxEntrenador> TituloxEntrenador { get; set; }
    }
}
