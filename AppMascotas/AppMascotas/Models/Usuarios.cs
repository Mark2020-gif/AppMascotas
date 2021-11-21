using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace AppMascotas.Models
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        [MaxLength(50)]

        public string Nombre { get; set; }
        [MaxLength(225)]

        public string Usuario { get; set; }
        [MaxLength(225)]

        public string Contrasenia { get; set; }
        [MaxLength(20)]

        public string IdMascota { get; set; }
        [MaxLength(225)]

        public string NombreM { get; set; }
        [MaxLength(225)]

        public string Raza { get; set; }
        [MaxLength(225)]

        public string Sexo { get; set; }
        [MaxLength(225)]

        public string NombreD { get; set; }
        [MaxLength(225)]

        public string Direccion { get; set; }

    }
}
