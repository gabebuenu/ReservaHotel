using ReservaHotel.Models;

namespace ReservaHotel.Repositories
{
    public interface IReservaRepository
    {
        Reserva CriarReserva(Reserva reserva);
        Quarto ObterQuartoDisponivelPorCategoria(string categoria);
        Quarto ObterQuartoPorId(string idQuarto);
        Hospede ObterHospedePorId(int idHospede);
        Reserva ObterReservaPorQuartoEData(string idQuarto, DateTime data);
        Reserva ObterReservaPorHospedeEData(int idHospede, DateTime data);
    }
}
