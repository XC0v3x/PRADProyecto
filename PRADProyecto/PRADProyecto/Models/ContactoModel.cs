using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PRADProyecto.Models
{
    public class ContactoModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public double Telefono { get; set; }
        public string Pais { get; set; }
        public string Nota { get; set; }
        public byte[] Foto { get; set; }
    }
}
