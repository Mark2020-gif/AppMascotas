using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace AppMascotas.Models
{
    public class Animales
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        [MaxLength(50)]

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
