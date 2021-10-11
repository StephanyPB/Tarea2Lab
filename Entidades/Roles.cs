using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("RolId")]
        public virtual List<RolesDetalle> Detalle { get; set; }


        public Roles()
        {
            RolId = 0;
            FechaCreacion = DateTime.Now;
            Descripcion = string.Empty;
            Detalle = new List<RolesDetalle>();
        }

        public Roles(int rolId, DateTime fechaCreacion, string descripcion)
        {
            RolId = rolId;
            FechaCreacion = fechaCreacion;
            Descripcion = descripcion;
            Detalle = new List<RolesDetalle>();
        }

        public void AgregarDetalle(RolesDetalle detalle)
        {
            this.Detalle.Add(detalle);
        }
        public void AgregarDetalle(int RolId,int PermisoId,bool esAsignado)
        {
            this.Detalle.Add(new RolesDetalle(0,RolId,PermisoId,esAsignado));
        }
    }
}
