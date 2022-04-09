using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PRADProyecto.Models
{
    public class SitesModel
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public Double Longitud { get; set; }
        public Double Latitud { get; set; }
        public string Pais { get; set; }
        public string Nota { get; set; }
        public byte[] Foto { get; set; }

    }
}
