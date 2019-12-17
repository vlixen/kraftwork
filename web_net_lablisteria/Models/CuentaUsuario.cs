using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LaBlisteria.Models
{
    public class CuentaUsuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        [Compare("Contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmarContraseña { get; set; }
    }
}