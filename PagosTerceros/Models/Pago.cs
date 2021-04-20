using System;
using Entidad;

namespace PagosTerceros.Models
{
    public class PagoInputModel
    {
        public string PagoId { get; set; }
        public string TerceroId { get; set; }
        public TerceroInputModel Tercero { get; set; } = new TerceroInputModel();

        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }

        public decimal PorcentajeIva { get; set; }

    }

    public class PagoViewModel : PagoInputModel
    {
        public PagoViewModel(Pago pago)
        {
            PagoId = pago.PagoId;
            TerceroId = pago.TerceroId;
            Tercero.TerceroId = pago.Tercero.TerceroId;
            Tercero.Nombre = pago.Tercero.Nombre;
            Tercero.Telefono = pago.Tercero.Telefono;
            Fecha = pago.Fecha;
            PorcentajeIva = pago.PorcentajeIva;
            Valor = pago.Valor;
            IVA = pago.IVA;
            Total = pago.Total;
        }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }

    }


    }