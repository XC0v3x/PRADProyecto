using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRADProyecto.Models;
using PRADProyecto.Controllers;
using System.Threading.Tasks;

namespace PRADProyecto.Controllers
{
    public class SitiosDB
    {
        // Procedimientos

        // Retorna todas las filas de la tabla Sites
        public static Task<List<SitesModel>> ObtenerListaSitios()
        {
            return DB.dbconexion.Table<SitesModel>().ToListAsync();
        }

        // OPERACIONES CRUD

        public static Task<int> AddSitio(SitesModel Sitio)
        {
            if (Sitio.ID != 0)
            {
                // Procedimiento de Actualizacion UPDATE
                return DB.dbconexion.UpdateAsync(Sitio);
            }
            else
            {
                // Procedimiento de INSERCCION
                return DB.dbconexion.InsertAsync(Sitio);
            }
        }

        // Obtenemos por el ID un registro
        public static Task<SitesModel> ObtenerSitio(int pid)
        {
            return DB.dbconexion.Table<SitesModel>()
                .Where(i => i.ID == pid)
                .FirstOrDefaultAsync();
        }

        // Eliminamos el registro
        public static Task<int> DelSitio(SitesModel Sitio)
        {
            return DB.dbconexion.DeleteAsync(Sitio);
        }
    }
}
