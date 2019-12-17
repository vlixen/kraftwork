using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaBlisteria.Models
{
    public class ProductoTipo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ProductoTipoID { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string ProductoTipoNombre { get; set; }

        public IEnumerable <Producto> Productos { get; set; }
}
}