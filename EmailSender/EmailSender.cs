using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailSender
{
    public class EmailSender
    {
        private async Task SendEmailAsync(MailMessage message)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("gostudymailsender@gmail.com", "daahodezlzbenqbo"),
                EnableSsl = true
            };
            await smtp.SendMailAsync(message);
        }

        public void SimpleSend(string email, string subject, string messege,  string recipientName = "Someone")
        {
            MailAddress from = new MailAddress("gostudymailsender@gmail.com", "BOT");
            MailAddress to = new MailAddress(email, recipientName);
            MailMessage mail = new MailMessage(from, to)
            {
                Subject = subject,
                Body = messege
            };
            Task.Factory.StartNew(() => SendEmailAsync(mail));
        }

    }
}
