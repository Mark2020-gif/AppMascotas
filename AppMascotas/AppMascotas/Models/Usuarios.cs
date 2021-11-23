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

    }
}
