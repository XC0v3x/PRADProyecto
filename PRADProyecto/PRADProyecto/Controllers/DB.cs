using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRADProyecto.Models;

namespace PRADProyecto.Controllers
{
    public static class DB
    {
        public static SQLiteAsyncConnection dbconexion;

        // Procedimiento Estatico
        public static void conexion(String dbpath)
        {
            dbconexion = new SQLiteAsyncConnection(dbpath);

            // Procedemos a crear las tablas de la base de datos
            dbconexion.CreateTableAsync<ContactoModel>();
            dbconexion.CreateTableAsync<SitesModel>();
        }
    }
}
