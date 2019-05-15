using System.Net;
using System.Net.Mail;

namespace Logic
{
    public static class MailHandler
    {
        public static void SendMail(string receiver, string subject, string body)
        {
            MailMessage mail = new MailMessage("munchkinsuper@gmail.com", receiver);

            SmtpClient client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("munchkinsuper@gmail.com", "SuperMunchkinNo.1")
            };
            mail.Subject = subject;
            mail.Body = body;
            client.Send(mail);
        }
    }
}
