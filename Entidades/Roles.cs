using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2Lab.Entidades
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }

        public Roles()
        {
            RolId = 0;
            FechaCreacion = DateTime.Now;
            Descripcion = string.Empty;
        }

        public Roles(int rolId, DateTime fechaCreacion, string descripcion)
        {
            RolId = rolId;
            FechaCreacion = fechaCreacion;
            Descripcion = descripcion;
        }
    }
}
