using System.Linq;
using System;
using Logica;
using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PagosTerceros.Models;
using Entidad;

namespace PagosTerceros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private PagoService personaService;
        public PagoController(PagoContext context)
        {
            personaService = new PagoService(context);
        }

        [HttpPost]
        public ActionResult<PagoViewModel> GuardarPago(PagoInputModel pagoInputModel)
        {
            var pago = MapearPago(pagoInputModel);
            var response = personaService.GuardarPago(pago);
            if (!response.Error)
            {
                return Ok(new PagoViewModel(pago));
            }
            return BadRequest(response.Mensaje);
        }

        [HttpPost("Tercero")]
        public ActionResult<TerceroViewModel> GuardarTercero(TerceroInputModel terceroDto)
        {
            var tercero = MapearTercero(terceroDto);
            var response = personaService.GuardarTercero(tercero);
            if (!response.Error)
            {
                return Ok(new TerceroViewModel(tercero));
            }
            return BadRequest(response.Mensaje);
        }

        private Tercero MapearTercero(TerceroInputModel terceroDto)
        {
            var tercero = new Tercero()
            {
                TerceroId = terceroDto.TerceroId,
                Nombre = terceroDto.Nombre,
                Telefono = terceroDto.Telefono,

            };
            return tercero;
        }

        private Pago MapearPago(PagoInputModel pagoInputModel)
        {
            var pago = new Pago()
            {
                PagoId = pagoInputModel.PagoId,
                TerceroId = pagoInputModel.TerceroId,
                Tercero = new Tercero { TerceroId = pagoInputModel.Tercero.TerceroId, Nombre = pagoInputModel.Tercero.Nombre, Telefono = pagoInputModel.Tercero.Telefono },
                Fecha = pagoInputModel.Fecha,
                Valor = pagoInputModel.Valor,
                PorcentajeIva = pagoInputModel.PorcentajeIva
            };
            return pago;
        }
        [HttpGet]
        public ActionResult<PagoViewModel> GetPagos()
        {
            var response = personaService.Consultar();
            if (!response.Error)
            {
                var PagoViewModel = response.Pagos.Select(p => new PagoViewModel(p));
                return Ok(PagoViewModel);
            }
            return BadRequest(response.Mensaje);
        }

           [HttpGet("Tercero/{id}")]
        public ActionResult<ConsultarTerceroPagos> GetTerceroPago(string id)
        {
            var response = personaService.ConsultarTerceroPagos(id);
            if (!response.Error)
            {
                var Tercero= new ConsultarTerceroPagos(response.Tercero);
                return Ok(Tercero);
            }
            return BadRequest(response.Mensaje);
        }
    }
}