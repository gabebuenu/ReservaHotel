Reserva de Hotel
Projeto de um sistema de reservas de hotel que inclui valida��es para h�spedes, quartos, e envio de e-mails para confirma��o de reservas.

Funcionalidades
Valida��es de Reservas e Quartos:

Verifica��o se o h�spede j� possui uma reserva em outro quarto.
Verifica��o se o quarto j� est� reservado na data desejada.
Apenas um h�spede pode reservar um quarto por vez.
Seed Data:

O projeto inicializa automaticamente dados de exemplo para h�spedes e quartos atrav�s da classe SeedData.
Valida��es em H�spede:

Impede que o h�spede reserve mais de um quarto ao mesmo tempo.
Impede reserva em quartos j� ocupados na mesma data.
Tecnologias Usadas
Banco de Dados: SQLite
Ferramenta de Visualiza��o: DBeaver
Backend: ASP.NET Core com Entity Framework Core
Logging: Microsoft.Extensions.Logging
Envio de E-mails: SMTP Simulado para salvar e-mails localmente
Como Executar
Execute o projeto.
Acesse o Swagger para testar as APIs de reserva:
Swagger URL: https://localhost:7079/swagger