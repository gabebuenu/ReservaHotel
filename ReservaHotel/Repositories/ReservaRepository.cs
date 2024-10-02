using ReservaHotel.Models;
using ReservaHotel.Repositories.Data;

namespace ReservaHotel.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly HotelContext _context;

        public ReservaRepository(HotelContext context)
        {
            _context = context;
        }

        public Reserva CriarReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
            return reserva;
        }

        public Quarto ObterQuartoDisponivelPorCategoria(string categoria)
        {
            return _context.Quartos.FirstOrDefault(q => q.Categoria == categoria && q.Disponivel);
        }

        public Quarto ObterQuartoPorId(string idQuarto)
        {
            return _context.Quartos.FirstOrDefault(q => q.Id == idQuarto);
        }

        public Hospede ObterHospedePorId(int idHospede)
        {
            return _context.Hospedes.FirstOrDefault(h => h.Id == idHospede);
        }
        public Reserva ObterReservaPorQuartoEData(string idQuarto, DateTime data) 
        {
            return _context.Reservas.FirstOrDefault(r => r.Quarto.Id == idQuarto && r.Data == data);
        }
        public Reserva ObterReservaPorHospedeEData(int idHospede, DateTime data)
        {
            return _context.Reservas.FirstOrDefault(r => r.Hospede.Id == idHospede && r.Data == data);
        }
    }
}
