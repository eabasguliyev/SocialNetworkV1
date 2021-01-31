using System.Net;
using System.Net.Mail;

namespace Network
{
    static class Mail
    {
        private static SmtpClient SmtpClient { get; set; }
        private static string SenderAddress { get; } = "valid@gmail.com";
        private static string SenderPassword{ get; } = "validPassword";
        static Mail()
        {
            SmtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(SenderAddress, SenderPassword),
                EnableSsl = true
            };
        }

        public static void SendMail(in string recipient, in string subject, in string body)
        {
            SmtpClient.Send(SenderAddress, recipient, subject, body);
        }
    }

}
