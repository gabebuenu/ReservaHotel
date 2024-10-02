namespace ReservaHotel.Models
{
    public class Reserva
    {
        public string Id { get; set; }
        public Hospede Hospede { get; set; }
        public Quarto Quarto { get; set; }
        public DateTime Data { get; set; }
    }
}
