using MimeKit;
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
        /// <summary>
        /// Way #1
        /// default tools
        /// </summary>
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


        /// <summary>
        /// Way #2
        /// nuget mailkit and mimekit
        /// </summary>
        public async Task SendMessage(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("BOT", "gostudymailsender@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("Someone", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 25, false);
                await client.AuthenticateAsync("gostudymailsender@mail.ru", "a3y-PGU-4jt-N4x");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
