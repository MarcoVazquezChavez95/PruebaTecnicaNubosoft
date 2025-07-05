
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? FechaRegistro { get; set; } 
    }
}