using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CapaDeDatos.Modelados
{
    [Table("bodega")] // El nombre de la tabla es singular y minúscula
    public class Bodega : BaseModel
    {
        [PrimaryKey("id_bodega", false)] // false porque es autoincrementable
        public int IdBodega { get; set; }

        [Column("nombre_bodega")]
        public string NombreBodega { get; set; }

        [Column("estado_bodega")]
        public bool EstadoBodega { get; set; }

        [Column("id_estado")]
        public int IdEstado { get; set; }

        // OJO AQUÍ: En tu imagen se ve con Mayúsculas "Contrasenia_Bodega"
        [Column("Contrasenia_Bodega")]
        public string ContraseniaBodega { get; set; }
    }
}
