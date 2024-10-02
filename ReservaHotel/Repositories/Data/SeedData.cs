using ReservaHotel.Models;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ReservaHotel.Repositories.Data
{
    public static class SeedData
    {
        public static void Initialize(HotelContext context)
        {
            var loggerFactory = LoggerFactory.Create(builder => {
                builder.AddConsole();
            });
            var logger = loggerFactory.CreateLogger("SeedData");

            try
            {
                logger.LogInformation("Iniciando seed de hóspedes.");
                var hospedes = new List<Hospede>
                {
                    new Hospede { Id = 1, Nome = "João", Email = "joao@example.com", Ativo = true },
                    new Hospede { Id = 2, Nome = "Maria", Email = "maria@example.com", Ativo = true },
                    new Hospede { Id = 3, Nome = "Bruno Bueno", Email = "brunobueno@example.com", Ativo = true },
                    new Hospede { Id = 4, Nome = "Caio Coneglian", Email = "caioconeglian@example.com", Ativo = true },
                    new Hospede { Id = 5, Nome = "Claudinei", Email = "claudinei@example.com", Ativo = true },
                    new Hospede { Id = 6, Nome = "Ettore", Email = "ettore@example.com", Ativo = true },
                    new Hospede { Id = 7, Nome = "Gustavo Barbosa", Email = "gustavo@example.com", Ativo = true },
                    new Hospede { Id = 8, Nome = "Gabriel Bueno", Email = "gabrielbueno@example.com", Ativo = true }
                };

                foreach (var hospede in hospedes)
                {
                    var existingHospede = context.Hospedes.FirstOrDefault(h => h.Id == hospede.Id);
                    if (existingHospede == null)
                    {
                        context.Hospedes.Add(hospede);
                    }
                    else
                    {
                        existingHospede.Nome = hospede.Nome;
                        existingHospede.Email = hospede.Email;
                        existingHospede.Ativo = hospede.Ativo;
                    }
                }

                logger.LogInformation("Iniciando seed de quartos.");
                var quartos = new List<Quarto>
                {
                    new Quarto { Id = "1", Numero = "101", Categoria = "Luxo", Disponivel = true },
                    new Quarto { Id = "2", Numero = "102", Categoria = "Simples", Disponivel = true },
                    new Quarto { Id = "3", Numero = "201", Categoria = "Premium", Disponivel = true },
                    new Quarto { Id = "4", Numero = "202", Categoria = "Cobertura", Disponivel = true },
                    new Quarto { Id = "5", Numero = "301", Categoria = "Suíte Presidencial", Disponivel = true },
                    new Quarto { Id = "6", Numero = "302", Categoria = "Standard", Disponivel = true },
                    new Quarto { Id = "7", Numero = "401", Categoria = "Quarto Família", Disponivel = true },
                    new Quarto { Id = "8", Numero = "402", Categoria = "Quarto Individual", Disponivel = true },
                    new Quarto { Id = "9", Numero = "501", Categoria = "Suíte Luxo", Disponivel = true },
                    new Quarto { Id = "10", Numero = "502", Categoria = "Quarto Econômico", Disponivel = true }
                };

                foreach (var quarto in quartos)
                {
                    var existingQuarto = context.Quartos.FirstOrDefault(q => q.Id == quarto.Id);
                    if (existingQuarto == null)
                    {
                        context.Quartos.Add(quarto);
                    }
                    else
                    {
                        existingQuarto.Numero = quarto.Numero;
                        existingQuarto.Categoria = quarto.Categoria;
                        existingQuarto.Disponivel = quarto.Disponivel;
                    }
                }

                context.SaveChanges();
                logger.LogInformation("Seed de dados concluído com sucesso.");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao inicializar os dados do banco.");
            }
        }
    }
}
