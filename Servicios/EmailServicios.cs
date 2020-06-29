using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class EmailServicios
    {
        ManagerRepository managerRepository = new ManagerRepository();

        public void sendEmail(string token, string email)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ayudandoalapandemia.19@gmail.com", "covid2020"),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress("ayudandoalapandemia.19@gmail.com"),
                Subject = "Validación de cuenta",
                Body = $"<h4>Por favor, clickear en el siguiente link, para poder validar su cuenta. <br/>Gracias. <br/><a href ='https://localhost:44306/Registro/activoUsuario?token={token}'> https://localhost:44306/Registro/activoUsuario?token={token} <h4/></a>",
                IsBodyHtml = true,
            };
             mailMessage.To.Add("gagustin.sk@gmail.com"); // Para testear 
             //mailMessage.To.Add(email); // Productivo

            smtpClient.Send(mailMessage);

        }
    }
}
