using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea2Lab.Entidades
{
    public class RolesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }
        public bool EsAsignado { get; set; }

        public RolesDetalle(int id, int rolId, int permisoId, bool esAsignado)
        {
            Id = id;
            RolId = rolId;
            PermisoId = permisoId;
            EsAsignado = esAsignado;
        }
    }
}
