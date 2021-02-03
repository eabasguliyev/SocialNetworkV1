using System.Net;
using System.Net.Mail;

namespace Network
{
    // turn on less secure apps access.
    /// <link>
    /// https://support.google.com/accounts/answer/6010255?hl=en
    /// </link>
    
    static class Mail
    {
        private static SmtpClient SmtpClient { get; set; }
        private static string SenderAddress { get; } = "mail";
        private static string SenderPassword{ get; } = "pass";
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
