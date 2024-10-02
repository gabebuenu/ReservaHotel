# Reserva de Hotel
Projeto de um sistema de reservas de hotel que inclui validações para hóspedes, quartos, e envio de e-mails para confirmação de reservas.

# Funcionalidades
#Validações de Reservas e Quartos:

* Verificação se o hóspede já possui uma reserva em outro quarto.
* Verificação se o quarto já está reservado na data desejada.
* Apenas um hóspede pode reservar um quarto por vez.
# Seed Data:

O projeto inicializa automaticamente dados de exemplo para hóspedes e quartos através da classe SeedData.
# Validações em Hóspede:

* Impede que o hóspede reserve mais de um quarto ao mesmo tempo.
* Impede reserva em quartos já ocupados na mesma data.
* Tecnologias Usadas
* Banco de Dados: SQLite
* Ferramenta de Visualização: DBeaver
* Backend: ASP.NET Core com Entity Framework Core
* Logging: Microsoft.Extensions.Logging
* Envio de E-mails: SMTP Simulado para salvar e-mails localmente
* Como Executar
* Execute o projeto.
# Acesse o Swagger para testar as APIs de reserva:
# Swagger URL: https://localhost:7079/swagger

![image](https://github.com/user-attachments/assets/59c7a62b-65ea-484f-918d-c2abe72958cb)
![image](https://github.com/user-attachments/assets/e8642ad5-4771-45db-8df0-bdde99d3d0f6)
![image](https://github.com/user-attachments/assets/09ec7f32-00f3-4c38-bbc1-1eca39188e80)



