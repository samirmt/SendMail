using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace EnviaEmail
{
    public static class Email
    {
        public static string Enviar(string destinatario, string anexo = "")
        {
            string retorno = "Email enviado com sucesso!";
            SmtpClient client = new SmtpClient();

            try
            {
                client.Host = "smtp server";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("user", "password");
                MailMessage mail = new MailMessage();
                mail.Sender = new MailAddress("mail senderr");
                mail.From = new MailAddress("mail sender");
                mail.To.Add(new MailAddress(destinatario));
                mail.Subject = "subject";
                mail.IsBodyHtml = true;

                if(anexo != "")
                {
                    Attachment attachment = new Attachment(anexo, MediaTypeNames.Application.Octet);
                    mail.Attachments.Add(attachment);
                }

                mail.Body += "<body><br /><br />body mail<br /></body>";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                mail.BodyEncoding = Encoding.UTF8;
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;

                client.Send(mail);
            }
            catch (Exception ex)
            {
                retorno = ex.Message.ToString();
            }

            return retorno;
        }
    }
}
