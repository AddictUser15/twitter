using System.Net.Mail;

namespace ConsoleApp2
{
    class Email
    {
        public void EmailSend(string path)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("your mail@gmail.com");
            mail.To.Add("anshulagarwal129@gmail.com");
            mail.Subject = "Current Trending Report";
            mail.Body = "mail with attachment";

            var attachment = new Attachment(path);
            mail.Attachments.Add(attachment);

            smtpServer.Port = 587;
            smtpServer.Credentials = new System.Net.NetworkCredential("NwmTestAutothon@gmail.com", "Welcome@123");
            smtpServer.EnableSsl = true;

            smtpServer.Send(mail);

        }
    }
}
