using Microsoft.AspNetCore.Mvc;
using ReservaHotel.Services;
using ReservaHotel.DTO;


namespace ReservaHotel.Controllers
{
    [ApiController]
    [Route("quartos/{idQuarto}/reservas")]
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public ReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost]
        public IActionResult CriarReservaPorQuarto(string idQuarto, [FromBody] ReservaDto reservaDto)
        {
            try
            {
                var reserva = _reservaService.CriarReservaPorQuarto(idQuarto, reservaDto.HospedeId, reservaDto.Data);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    [ApiController]
    [Route("categorias/{nomeCategoria}/reservas")]
    public class CategoriaReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;

        public CategoriaReservaController(ReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpPost]
        public IActionResult CriarReservaPorCategoria(string nomeCategoria, [FromBody] ReservaDto reservaDto)
        {
            try
            {
                var reserva = _reservaService.CriarReservaPorCategoria(nomeCategoria, reservaDto.HospedeId, reservaDto.Data);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
