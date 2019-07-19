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
                client.Host = "smtp.kinghost.net";
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("naoresponda@funmotors.com.br", "cfmotoBR369");
                MailMessage mail = new MailMessage();
                mail.Sender = new MailAddress("naoresponda@funmotors.com.br");
                mail.From = new MailAddress("naoresponda@funmotors.com.br");
                mail.To.Add(new MailAddress(destinatario));
                mail.Subject = "Contato";
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
