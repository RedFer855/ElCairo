using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeDatos.Modelados
{
    [Table("formato")] 
    public class Formato : BaseModel 
    {
        
        [PrimaryKey("id_tipo_formato", false)]
        public int IdFormato { get; set; }

       
        [Column("nombre_tipo_formato")]
        public string NombreTipoFormato { get; set; } 
    }

}
