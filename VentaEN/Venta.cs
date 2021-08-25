using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VentaEN
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        [Required(ErrorMessage = "El producto es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} tiene que tiene que tener como mínimo {2} carateres y como máximo {1} caracteres.", MinimumLength = 1)]
        public string Producto { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La {0} tiene que tiene que tener como mínimo {2} carateres y como máximo {1} caracteres.", MinimumLength = 1)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El precio es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int Cantidad { get; set; }

        //Relaciones uno a uno
        public int IdCliente { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente_en {get;set;}
    }
}
