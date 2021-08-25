using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentaEN
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} tiene que tiene que tener como mínimo {2} carateres y como máximo {1} caracteres.", MinimumLength = 1)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido del cliente es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} tiene que tiene que tener como mínimo {2} carateres y como máximo {1} caracteres.", MinimumLength = 1)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La dirección del cliente es obligatoria")]
        [StringLength(50, ErrorMessage = "La {0} tiene que tiene que tener como mínimo {2} carateres y como máximo {1} caracteres.", MinimumLength = 1)]
        [Display(Name ="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El teléfono del cliente es obligatorio")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        //Relaciones uno a muchos
        public virtual ICollection<Venta>Ventas_list { get; set; }
    }
}
