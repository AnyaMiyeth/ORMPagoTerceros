using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;

namespace PagosTerceros.Models
{
    

    public class ConsultarTerceroPagos
    {
       
            public string TerceroId { get; set; }
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public ConsultarTerceroPagos(Tercero tercero)
            {
                TerceroId = tercero.TerceroId;
                Nombre = tercero.Nombre;
                Telefono = tercero.Telefono;
                Pagos = tercero.Pagos.Select(p => new ConsultarPagoViewModel(p)).ToList();
            }
            public List<ConsultarPagoViewModel> Pagos { get; set; }


        
    }
    public class ConsultarPagoViewModel
    {
        public string PagoId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public decimal PorcentajeIva { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

        public ConsultarPagoViewModel(Pago pago)
        {
            PagoId = pago.PagoId;
            Fecha = pago.Fecha;
            PorcentajeIva = pago.PorcentajeIva;
            Valor = pago.Valor;
            IVA = pago.IVA;
            Total = pago.Total;
        }
    }
}