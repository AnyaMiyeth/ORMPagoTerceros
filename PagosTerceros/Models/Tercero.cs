using System.Linq;
using System.Collections.Generic;
using Entidad;

namespace PagosTerceros.Models
{
    public class TerceroViewModel
    {
        public string TerceroId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public TerceroViewModel()
        {

        }
        public TerceroViewModel(Tercero tercero)
        {
            TerceroId = tercero.TerceroId;
            Nombre = tercero.Nombre;
            Telefono = tercero.Telefono;

        }
    }
    public class TerceroInputModel
    {
        public string TerceroId { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }

        public TerceroInputModel()
        {

        }

    }

    
}