using System.Net;
using System.Net.Mail;

namespace EmailAPI
{
    public class MailHelper
    {
        //expéditeur : string
        //destinataire : string
        //objet : string
        //corps : string
        public static void SendMail(string expediteur, string[] destinataires, string objet, string corps)
        {
            try
            {
                MailMessage mail = new MailMessage();
                //ajouter les destinataires
                foreach (string adress in destinataires)
                {
                    mail.To.Add(adress);
                }

                mail.Subject = objet;
                mail.Body = corps;
                //définir l'expéditeur
                mail.From = new MailAddress(expediteur, "via WebServices ambassadeurs");
                //définir les paramètres smtp pour l'envoi
                SmtpClient smtpServer = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("ambassadeur.envoimails@gmail.com", "mot-de-passe")
                };
                //envoi du mail
                smtpServer.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
