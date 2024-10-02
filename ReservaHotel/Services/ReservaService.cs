using ReservaHotel.Models;
using ReservaHotel.Repositories;
using System.IO;
using System.Net.Mail;

namespace ReservaHotel.Services
{
    public class ReservaService
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaService(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public Reserva CriarReservaPorQuarto(string idQuarto, int idHospede, DateTime data)
        {
            var quarto = _reservaRepository.ObterQuartoPorId(idQuarto);
            var hospede = _reservaRepository.ObterHospedePorId(idHospede);

            var reservaHospedeExistente = _reservaRepository.ObterReservaPorHospedeEData(idHospede, data.Date);
            if (reservaHospedeExistente != null)
            {
                EnviarEmail(hospede, false, "O hóspede já tem uma reserva para essa data.");
                throw new Exception("O hóspede já tem uma reserva para essa data.");
            }

            if (quarto == null || !quarto.Disponivel)
            {
                EnviarEmail(hospede, false, "Quarto não disponível.");
                throw new Exception("Quarto não disponível.");
            }

            if (hospede == null || !hospede.Ativo)
            {
                EnviarEmail(hospede, false, "Hóspede inativo.");
                throw new Exception("Hóspede inativo.");
            }

            var reservaExistente = _reservaRepository.ObterReservaPorQuartoEData(idQuarto, data.Date);
            if (reservaExistente != null)
            {
                EnviarEmail(hospede, false, "O quarto já está reservado para essa data.");
                throw new Exception("O quarto já está reservado para essa data.");
            }

            var reserva = new Reserva
            {
                Id = Guid.NewGuid().ToString(),
                Hospede = hospede,
                Quarto = quarto,
                Data = data.Date 
            };

            _reservaRepository.CriarReserva(reserva);

            EnviarEmail(hospede, true, "Reserva criada com sucesso.");
            return reserva;
        }



        public Reserva CriarReservaPorCategoria(string nomeCategoria, int idHospede, DateTime data)
        {
            var hospede = _reservaRepository.ObterHospedePorId(idHospede);
            if (hospede == null || !hospede.Ativo)
            {
                EnviarEmail(hospede, false, "Hóspede inativo ou inexistente.");
                throw new Exception("Hóspede inativo ou inexistente.");
            }

            var reservaHospedeExistente = _reservaRepository.ObterReservaPorHospedeEData(idHospede, data.Date);
            if (reservaHospedeExistente != null)
            {
                EnviarEmail(hospede, false, "O hóspede já tem uma reserva para essa data.");
                throw new Exception("O hóspede já tem uma reserva para essa data.");
            }

            var quarto = _reservaRepository.ObterQuartoDisponivelPorCategoria(nomeCategoria);
            if (quarto == null)
            {
                EnviarEmail(hospede, false, "Nenhum quarto disponível na categoria.");
                throw new Exception("Nenhum quarto disponível na categoria.");
            }

            var reservaExistenteNoQuarto = _reservaRepository.ObterReservaPorQuartoEData(quarto.Id, data.Date);
            if (reservaExistenteNoQuarto != null)
            {
                EnviarEmail(hospede, false, "O quarto já está reservado para essa data.");
                throw new Exception("O quarto já está reservado para essa data.");
            }

            var reserva = new Reserva
            {
                Id = Guid.NewGuid().ToString(),
                Hospede = hospede,
                Quarto = quarto,
                Data = data.Date 
            };

            _reservaRepository.CriarReserva(reserva);


            EnviarEmail(hospede, true, "Reserva criada com sucesso.");
            return reserva;
        }



        private void EnviarEmail(Hospede hospede, bool sucesso, string mensagem)
        {
            if (hospede != null)
            {
                try
                {
                    string emailDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Emails");

                    if (!Directory.Exists(emailDirectory))
                    {
                        Directory.CreateDirectory(emailDirectory);
                    }

                    var email = new MailMessage("no-reply@hotel.com", hospede.Email);
                    email.Subject = sucesso ? "Reserva Confirmada" : "Erro na Reserva";
                    email.Body = mensagem;

                    using (var smtp = new SmtpClient())
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                        smtp.PickupDirectoryLocation = emailDirectory; 
                        smtp.Send(email);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
                    throw;
                }
            }
            else
            {
                Console.WriteLine("Erro: Hóspede é nulo, e-mail não pode ser enviado.");
                throw new Exception("Hóspede é nulo, e-mail não pode ser enviado.");
            }
        }
    }
}
