using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PRADProyecto.Models;
using PRADProyecto.Controllers;
using System.Threading.Tasks;

namespace PRADProyecto.Controllers
{
    public class ContactosDB
    {
        // Procedimientos

        // Retorna todas las filas de la tabla Contactos
        public static Task<List<ContactoModel>> ObtenerListaContactos()
        {
            return DB.dbconexion.Table<ContactoModel>().ToListAsync();
        }

        // OPERACIONES CRUD

        public static Task<int> AddContacto(ContactoModel Contacto)
        {
            if (Contacto.ID != 0)
            {
                // Procedimiento de Actualizacion UPDATE
                return DB.dbconexion.UpdateAsync(Contacto);
            }
            else
            {
                // Procedimiento de INSERCCION
                return DB.dbconexion.InsertAsync(Contacto);
            }
        }

        // Obtenemos por el ID un registro
        public static Task<ContactoModel> ObtenerContacto(int pid)
        {
            return DB.dbconexion.Table<ContactoModel>()
                .Where(i => i.ID == pid)
                .FirstOrDefaultAsync();
        }

        // Eliminamos el registro
        public static Task<int> DelContacto(ContactoModel Contacto)
        {
            return DB.dbconexion.DeleteAsync(Contacto);
        }
    }
}
