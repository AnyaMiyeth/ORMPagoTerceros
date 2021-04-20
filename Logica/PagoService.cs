using System;
using System.Collections.Generic;
using System.Linq;
using Datos;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class PagoService
    {
        private readonly PagoContext _context;
        public PagoService(PagoContext context)
        {
            _context = context;
        }


        public ConsultaPagoResponse Consultar()
        {
            try
            {
                var query = _context.Pagos.Include(p => p.Tercero).ToQueryString();

                var pagos = _context.Pagos.Include(p => p.Tercero).ToList();

                return new ConsultaPagoResponse(pagos);
            }
            catch (Exception e)
            {
                return new ConsultaPagoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
        public ConsultarTerceroPagosResponse ConsultarTerceroPagos(string identificaion)
        {
            try
            {
                var query = _context.Terceros.Where(t => t.TerceroId.Equals(identificaion)).Include(p => p.Pagos).FirstOrDefault();

                var Tercero = _context.Terceros.Where(t => t.TerceroId.Equals(identificaion)).Include(p => p.Pagos).FirstOrDefault();
                if (Tercero == null)
                {
                    return new ConsultarTerceroPagosResponse("No se encontraron Pagos para el tercero solicitado");
                }
                return new ConsultarTerceroPagosResponse(Tercero);
            }
            catch (Exception e)
            {
                return new ConsultarTerceroPagosResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }
        public GuardarPagoResponse GuardarPago(Pago pago)
        {
            try
            {
                var tercero = _context.Terceros.Find(pago.Tercero.TerceroId);
                if (tercero == null)
                {
                    _context.Terceros.Add(pago.Tercero);

                }
                pago.Tercero = tercero;
                _context.Pagos.Add(pago);
                _context.SaveChanges();
                return new GuardarPagoResponse(pago);
            }
            catch (Exception e)
            {
                return new GuardarPagoResponse("Ocurrieron algunos Errores:" + e.Message);
            }
        }

        public GuardarTerceroResponse GuardarTercero(Tercero tercero)
        {
            try
            {
                _context.Terceros.Add(tercero);
                _context.SaveChanges();
                return new GuardarTerceroResponse(tercero);
            }
            catch (Exception e)
            {
                return new GuardarTerceroResponse("Ocurrieron algunos Errores:" + e.Message);
            }

        }
    }

    public class ConsultarTerceroPagosResponse
    {
        public Tercero Tercero { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarTerceroPagosResponse(Tercero tercero)
        {
            Tercero = tercero;
            Error = false;
        }

        public ConsultarTerceroPagosResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }


    public class GuardarPagoResponse
    {
        public Pago Pago { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarPagoResponse(Pago pago)
        {
            Pago = pago;
            Error = false;
        }

        public GuardarPagoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }

    public class GuardarTerceroResponse
    {
        public Tercero Tercero { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarTerceroResponse(Tercero tercero)
        {
            Tercero = tercero;
            Error = false;
        }

        public GuardarTerceroResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

    }

    public class ConsultaPagoResponse
    {
        public List<Pago> Pagos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultaPagoResponse(List<Pago> pagos)
        {
            Pagos = pagos;
            Error = false;
        }

        public ConsultaPagoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }


    }

}
